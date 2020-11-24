using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3_ExpertSystem
{
    public class Expert
    {
        public List<Question> Default { get; set; }
        public List<Question> All { get; set; }
        public List<Result> Results { get; set; }
    }

    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<QuestionAnswer> Answers { get; set; }

        public override string ToString()
        {
            return Id.ToString();
        }
    }

    public class QuestionAnswer
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public List<int> Exclude { get; set; }
        public List<int> Include { get; set; }

        public override string ToString()
        {
            return Id.ToString();
        }
    }

    public class Result
    {
        public string Text { get; set; }
        public List<int> Answers { get; set; }
    }
}
