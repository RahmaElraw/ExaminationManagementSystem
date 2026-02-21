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
            Console.WriteLine("3 - Multiple Choice (Multiple Answers)");
            Console.WriteLine("Enter Number of Type");
            int type;
            while (!int.TryParse(Console.ReadLine(), out type) || (type != 1 && type != 2 && type!=3))
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
                    Body = body,
                    Marks = marks,
                    Difficulty = difficulty,
                    Choices = choices,
                    CorrectAnswer = correct
                });
            }
            else if (type == 2)
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
            else if (type == 3)
            {
                Console.Write("Enter number of choices: ");
                int numChoices;
                while (!int.TryParse(Console.ReadLine(), out numChoices) || numChoices <= 1)
                    Console.Write("Invalid number, try again: ");

                string[] choices = new string[numChoices];
                for (int i = 0; i < numChoices; i++)
                {
                    Console.Write($"Choice {i + 1}: ");
                    choices[i] = Console.ReadLine();
                }

                Console.WriteLine("Enter correct answers as numbers separated by , ");
                List<int> correctAnswers=new List<int>();
                while (true)
                {
                    correctAnswers.Clear();
                    string input = Console.ReadLine();
                    string[] parts = input.Split(',');

                    bool valid = true;

                    for (int i = 0; i < parts.Length; i++)
                    {
                        int num;

                        if (int.TryParse(parts[i].Trim(), out num))
                        {
                            if (num >= 1 && num <= numChoices)
                            {
                                if (!correctAnswers.Contains(num))
                                    correctAnswers.Add(num);
                                else
                                {
                                    valid = false;
                                    break;
                                }
                            }
                            else
                            {
                                valid = false;
                                break;
                            }
                        }
                        else
                        {
                            valid = false;
                            break;
                        }
                    }

                    if (valid && correctAnswers.Count > 0)
                        break;

                    Console.Write("Invalid input, try again: ");
                }

                QuestionBank.Add(new MultipleChoiceQuestions
                {
                    Body = body,
                    Marks = marks,
                    Difficulty = difficulty,
                    Choices = choices,
                    CorrectAnswers = correctAnswers
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
