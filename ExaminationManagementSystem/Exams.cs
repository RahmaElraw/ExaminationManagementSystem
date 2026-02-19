using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationManagementSystem
{
    internal abstract class Exams
    {
        public int Time { get; set; }
        public List<Questions> questions { get; set; }
        public void ShowExamDetails()
        {
            Console.WriteLine($"\nExam started and you should answer in {this.Time} minutes");
        }

        public abstract void StartExam();

        public int CalculateMarks()
        {
            int total = 0;
            for (int i = 0; i < questions.Count; i++)
            {
                total += questions[i].Marks;
            }
            return total;
        }
    }
}
