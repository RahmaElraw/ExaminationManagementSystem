using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationManagementSystem
{
    internal class PracticeExam : Exams
    {
        public override void StartExam()
        {
            Console.WriteLine("Practice Exam Starts");
            int totalGrade = 0;
            for (int i = 0; i < questions.Count; i++)
            {
                questions[i].ShowQuestion();
                int grade = questions[i].CheckAnswer();
                totalGrade += grade;
                if (grade > 0)
                    Console.WriteLine("Correct");
                else
                {
                    Console.WriteLine("Wrong");
                    Console.WriteLine("Correct Answer: " + questions[i].GetCorrectAnswer());
                }
            }
            int totalMarks = CalculateMarks();
            Console.WriteLine($"Your Practice Total Grade is {totalGrade} / {totalMarks}");
            Console.WriteLine("Practice Exam Finished.");
        }
    }
}
