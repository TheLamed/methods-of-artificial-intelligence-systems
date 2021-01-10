﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using Microsoft.ML;
using L10_MachineVision.YoloParser;
using L10_MachineVision.DataStructures;

namespace L10_MachineVision
{
    class Program
    {
        static void Main(string[] args)
        {
            var modelFilePath = Path.Combine("assets", "Model", "TinyYolo2_model.onnx");

            Console.WriteLine("Image path: ");
            var imgPath = Console.ReadLine();

            var path = Path.GetDirectoryName(imgPath);
            //var outputImgPath = Path.Combine(imgPath, Path.GetFileNameWithoutExtension(imgPath) + "-output" + Path.GetExtension(imgPath));

            var img = new ImageNetData
            {
                ImagePath = imgPath,
                Label = Path.GetFileName(imgPath)
            };

            MLContext mlContext = new MLContext();

            var imageDataView = mlContext.Data.LoadFromEnumerable(new List<ImageNetData> { img });

            var modelScorer = new OnnxModelScorer(modelFilePath, mlContext);
            var probabilities = modelScorer.Score(imageDataView);
            var parser = new YoloOutputParser();

            var boundingBoxes = probabilities
                .Select(probability => parser.ParseOutputs(probability))
                .Select(boxes => parser.FilterBoundingBoxes(boxes, 5, .5F));

            IList<YoloBoundingBox> detectedObjects = boundingBoxes.ElementAt(0);

            DrawBoundingBox(path, path, Path.GetFileName(imgPath), detectedObjects);
            LogDetectedObjects(imgPath, detectedObjects);

            //var assetsRelativePath = @"assets";
            //string assetsPath = GetAbsolutePath(assetsRelativePath);
            //var modelFilePath = Path.Combine(assetsPath, "Model", "TinyYolo2_model.onnx");
            //var imagesFolder = Path.Combine(assetsPath, "images");
            //var outputFolder = Path.Combine(assetsPath, "images", "output");


            //MLContext mlContext = new MLContext();

            //try
            //{
            //    var images = ImageNetData.ReadFromFile(imagesFolder);
            //    var imageDataView = mlContext.Data.LoadFromEnumerable(images);

            //    var modelScorer = new OnnxModelScorer(imagesFolder, modelFilePath, mlContext);

            //    var probabilities = modelScorer.Score(imageDataView);

            //    var parser = new YoloOutputParser();

            //    var boundingBoxes = probabilities
            //        .Select(probability => parser.ParseOutputs(probability))
            //        .Select(boxes => parser.FilterBoundingBoxes(boxes, 5, .5F));

            //    for (var i = 0; i < images.Count(); i++)
            //    {
            //        string imageFileName = images.ElementAt(i).Label;
            //        IList<YoloBoundingBox> detectedObjects = boundingBoxes.ElementAt(i);

            //        DrawBoundingBox(imagesFolder, outputFolder, imageFileName, detectedObjects);
            //        LogDetectedObjects(imageFileName, detectedObjects);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}

            //Console.WriteLine("========= End of Process..Hit any Key ========");
            //Console.ReadLine();
        }

        public static string GetAbsolutePath(string relativePath)
        {
            FileInfo _dataRoot = new FileInfo(typeof(Program).Assembly.Location);
            string assemblyFolderPath = _dataRoot.Directory.FullName;

            string fullPath = Path.Combine(assemblyFolderPath, relativePath);

            return fullPath;
        }

        private static void DrawBoundingBox(string inputImageLocation, string outputImageLocation, string imageName, IList<YoloBoundingBox> filteredBoundingBoxes)
        {
            var image = Image.FromFile(Path.Combine(inputImageLocation, imageName));

            var originalImageHeight = image.Height;
            var originalImageWidth = image.Width;

            foreach (var box in filteredBoundingBoxes)
            {
                var x = (uint)Math.Max(box.Dimensions.X, 0);
                var y = (uint)Math.Max(box.Dimensions.Y, 0);
                var width = (uint)Math.Min(originalImageWidth - x, box.Dimensions.Width);
                var height = (uint)Math.Min(originalImageHeight - y, box.Dimensions.Height);

                x = (uint)originalImageWidth * x / OnnxModelScorer.ImageNetSettings.imageWidth;
                y = (uint)originalImageHeight * y / OnnxModelScorer.ImageNetSettings.imageHeight;
                width = (uint)originalImageWidth * width / OnnxModelScorer.ImageNetSettings.imageWidth;
                height = (uint)originalImageHeight * height / OnnxModelScorer.ImageNetSettings.imageHeight;

                string text = $"{box.Label} ({(box.Confidence * 100).ToString("0")}%)";

                using (Graphics thumbnailGraphic = Graphics.FromImage(image))
                {
                    thumbnailGraphic.CompositingQuality = CompositingQuality.HighQuality;
                    thumbnailGraphic.SmoothingMode = SmoothingMode.HighQuality;
                    thumbnailGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    Font drawFont = new Font("Arial", 12, FontStyle.Bold);
                    SizeF size = thumbnailGraphic.MeasureString(text, drawFont);
                    SolidBrush fontBrush = new SolidBrush(Color.Black);
                    Point atPoint = new Point((int)x, (int)y - (int)size.Height - 1);

                    Pen pen = new Pen(box.BoxColor, 3.2f);
                    SolidBrush colorBrush = new SolidBrush(box.BoxColor);

                    thumbnailGraphic.FillRectangle(colorBrush, (int)x, (int)(y - size.Height - 1), (int)size.Width, (int)size.Height);
                    thumbnailGraphic.DrawString(text, drawFont, fontBrush, atPoint);
                    thumbnailGraphic.DrawRectangle(pen, x, y, width, height);
                }

                if (!Directory.Exists(outputImageLocation))
                    Directory.CreateDirectory(outputImageLocation);

                var pth = Path.GetFileNameWithoutExtension(imageName) + "-output" + Path.GetExtension(imageName);
                image.Save(Path.Combine(outputImageLocation, pth));
            }
        }

        private static void LogDetectedObjects(string imageName, IList<YoloBoundingBox> boundingBoxes)
        {
            Console.WriteLine($".....The objects in the image {imageName} are detected as below....");

            foreach (var box in boundingBoxes)
            {
                Console.WriteLine($"{box.Label} and its Confidence score: {box.Confidence}");
            }

            Console.WriteLine("");
        }
    }
}
