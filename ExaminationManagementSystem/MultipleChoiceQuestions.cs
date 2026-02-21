using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationManagementSystem
{
    internal class MultipleChoiceQuestions : Questions
    {
        public string[] Choices { get; set; } 
        public List<int> CorrectAnswers { get; set; }

        public override int CheckAnswer()
        {
            string input = Console.ReadLine();
            string[] studentAnswers = input.Split(',');
            List<int> studentNums = new List<int>();

            for (int i = 0; i < studentAnswers.Length; i++)
            {
                if (int.TryParse(studentAnswers[i].Trim(), out int num))
                    studentNums.Add(num);
            }

            studentNums.Sort();
            CorrectAnswers.Sort();

            if (studentNums.Count != CorrectAnswers.Count)
                return 0;

            for (int i = 0; i < studentNums.Count; i++)
            {
                if (studentNums[i] != CorrectAnswers[i])
                    return 0;
            }

            return Marks;
        }
        public override string GetCorrectAnswer()
        {
            string result = "";

            for (int i = 0; i < CorrectAnswers.Count; i++)
            {
                int index = CorrectAnswers[i] - 1; 
                result += Choices[index];

                if (i != CorrectAnswers.Count - 1) 
                    result += ", ";
            }

            return result;
        }

        public override void ShowQuestion()
        {
            Console.WriteLine($"{Body} \t ({Marks} marks, ({Difficulty}))");
            for (int i = 0; i < Choices.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Choices[i]}");
            }
            Console.WriteLine("Choose all correct answers separated by ,");
        }
    }
}
