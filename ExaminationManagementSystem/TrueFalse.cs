using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationManagementSystem
{
    internal class TrueFalse : Questions
    {
        public bool CorrectAnswer { get; set; }
        public override int CheckAnswer()
        {
            Console.WriteLine("Enter number of answer");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
            {
                Console.Write("Invalid choice, try again: ");
            }
            bool studentAnswer = choice == 1;
            return studentAnswer == CorrectAnswer ? Marks : 0;
            // لو الطالب اختار 1 يبقى اختار ترو ونسجلها لو مش واحد يبقى اختار فولس ونقارن مع الاجابه الصحيحه لو زى بعض رجع الدرجه كامله مش قد بعض رجع زيرو
        }

        public override string GetCorrectAnswer()
        {
            return CorrectAnswer ? "true" : "false";
        }

        public override void ShowQuestion()
        {
            Console.WriteLine($"{Body} \t ({Marks} marks, ({Difficulty}))");
            Console.WriteLine("1. true \n2. false");
        }
    }
}
