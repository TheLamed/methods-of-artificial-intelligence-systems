using Microsoft.ML.Data;

namespace L10_MachineVision.DataStructures
{
    public class ImageNetPrediction
    {
        [ColumnName("grid")]
        public float[] PredictedLabels;
    }
}
