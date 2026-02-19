using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationManagementSystem
{
    internal class MCQ : Questions
    {
        public string[] Choices { get; set; }
        public string CorrectAnswer { get; set; }
        public override int CheckAnswer()
        {
            Console.WriteLine("Enter the number of choice: ");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > Choices.Length)
            {
                Console.Write("Invalid choice, try again: ");
            }
            return Choices[choice - 1] == CorrectAnswer ? Marks : 0;
        }

        public override string GetCorrectAnswer()
        {
            return CorrectAnswer;
        }

        public override void ShowQuestion()
        {
            Console.WriteLine($"{Body} \t ({Marks} marks, ({Difficulty}))");
            for (int i = 0; i < Choices.Length; i++)
            {
                Console.WriteLine($"{i+1}. {Choices[i]}");
            }
        }
    }
}
