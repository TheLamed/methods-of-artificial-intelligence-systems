using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using System.Linq;

namespace L3_ExpertSystem
{
    public partial class Form1 : Form
    {
        public Expert ExpertSystem { get; set; }

        public List<Question> Questions { get; set; }
        public List<QuestionAnswer> Answers { get; set; }
        public int QuestionIndex { get; set; }

        public Form1()
        {
            InitializeComponent();
            RefresSystem();
        }

        public void RefresSystem()
        {
            ExpertSystem = JsonSerializer.Deserialize<Expert>(File.ReadAllText("../../Expert.json"));
            Questions = new List<Question>(ExpertSystem.Default);
            Answers = new List<QuestionAnswer>();
            QuestionIndex = 0;

            UpdateQuestionGroup();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            foreach (var item in QuestionsGroup.Controls)
            {
                if (item is RadioButton rb && rb.Checked)
                {
                    Answers.Add(rb.Tag as QuestionAnswer);
                }
            }

            UpdateQuestions();

            QuestionIndex++;

            if (Questions.Count == QuestionIndex)
            {
                ShowResult();
                RefresSystem();
            }
            else
            {
                UpdateQuestionGroup();
            }
        }

        public void UpdateQuestions()
        {
            var include = ExpertSystem.All.Where(v => Answers.SelectMany(c => c.Include).Contains(v.Id) && !Questions.Select(c => c.Id).Contains(v.Id));

            Questions.AddRange(include);

            Questions = Questions.Where(v => !Answers.SelectMany(c => c.Exclude).Contains(v.Id)).ToList();
            //Questions = Questions.Where(v => Questions.Where(c => c.Id == v.Id).Count() <= 1).ToList();
        }

        public void UpdateQuestionGroup()
        {
            QuestionLabel.Text = Questions[QuestionIndex].Text;

            QuestionsGroup.Controls.Clear();

            var tm = 0;
            foreach (var item in Questions[QuestionIndex].Answers)
            {
                var rb = new RadioButton
                {
                    Text = item.Answer,
                    Tag = item,
                    Top = tm
                };
                tm += 25;
                QuestionsGroup.Controls.Add(rb);
            }
        }

        public void ShowResult()
        {
            var results = new List<Result>();
            var answers = Answers.Select(v => v.Id).ToList();

            foreach (var item in ExpertSystem.Results)
            {
                int count = 0;

                foreach (var result in item.Answers)
                    if (answers.Contains(result))
                        count++;

                if (count == item.Answers.Count)
                {
                    results.Add(item);
                }
            }

            MessageBox.Show(string.Join("\n", results.Select(v => v.Text)));
        }
    }
}
