using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationManagementSystem
{
    public enum DifficultyLevel
    {
        Easy = 1,
        Medium = 2,
        Hard = 3
    }

    internal abstract class Questions
    {
        public string Body { get; set; }
        public int Marks { get; set; }
        public DifficultyLevel Difficulty { get; set; }
        public abstract void ShowQuestion();
        public abstract int CheckAnswer();
        public abstract string GetCorrectAnswer();
    }
}
