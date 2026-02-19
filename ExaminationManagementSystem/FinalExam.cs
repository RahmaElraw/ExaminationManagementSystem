using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationManagementSystem
{
    internal class FinalExam : Exams
    {
        public override void StartExam()
        {
            Console.WriteLine("Final Exam Starts");
            int totalGrade = 0;
            for (int i = 0; i < questions.Count; i++)
            {
                questions[i].ShowQuestion();
                totalGrade += questions[i].CheckAnswer();
            }
            int totalMarks = CalculateMarks();
            double percentage = (double)totalGrade / totalMarks * 100;

            Console.WriteLine($"Your Final Total Grade is {totalGrade} / {totalMarks}");
            Console.WriteLine($"Percentage = {percentage}%");
            Console.WriteLine("Final Exam Finished.");
        }
    }
}
