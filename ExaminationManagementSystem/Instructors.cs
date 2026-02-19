using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationManagementSystem
{
    internal class Instructors : Users
    {
        public static List<Questions> QuestionBank = new List<Questions>();
        public void AddQuestion()
        {
            Console.WriteLine("Choose Question Type:");
            Console.WriteLine("1 - MCQ");
            Console.WriteLine("2 - True/False");
            Console.WriteLine("Enter Number of Type");
            int type;
            while (!int.TryParse(Console.ReadLine(), out type) || (type != 1 && type != 2))
            {
                Console.WriteLine("Invalid choice, try again: ");
            }

            Console.Write("Enter Question Body: ");
            string body = Console.ReadLine();

            Console.Write("Enter Question Marks: ");
            int marks;
            while(!int.TryParse(Console.ReadLine(),out marks) || marks<=0)
            {
                Console.WriteLine("Invalid mark, try again: ");
            }

            Console.WriteLine("Choose Difficulty Level:");
            Console.WriteLine("1 - Easy");
            Console.WriteLine("2 - Medium");
            Console.WriteLine("3 - Hard");
            int diff;
            while (!int.TryParse(Console.ReadLine(), out diff) || diff < 1 || diff > 3)
            {
                Console.Write("Invalid difficulty, try again: ");
            }

            DifficultyLevel difficulty=(DifficultyLevel)diff;
            if (type == 1)
            {
                string[] choices = new string[4];
                for (int i = 0; i < 4; i++)
                {
                    Console.Write($"Choice {i + 1}: ");
                    choices[i] = Console.ReadLine();
                }
                Console.Write("Enter Correct Answer exactly as written: ");
                string correct = Console.ReadLine();

                QuestionBank.Add(new MCQ
                {
                   Body=body,
                   Marks=marks,
                   Difficulty=difficulty,
                   Choices=choices,
                   CorrectAnswer=correct
                });
            }
            else
            {
                Console.Write("Enter Correct Answer (true/false): ");
                bool correct;
                while (!bool.TryParse(Console.ReadLine(), out correct))
                    Console.Write("Invalid input, enter true or false: ");

                QuestionBank.Add(new TrueFalse
                {
                    Body = body,
                    Marks = marks,
                    Difficulty = difficulty,
                    CorrectAnswer = correct,
                });
            }
            Console.WriteLine("Question Added Successfully ");
        }
        public Exams SetExam(int choice)
        {
            Exams exam = choice == 1 ? new PracticeExam() : new FinalExam();

            exam.Time = 30;
            exam.questions = QuestionBank;
            return exam;
        }
    }
}
