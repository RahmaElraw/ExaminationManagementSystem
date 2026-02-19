using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationManagementSystem
{
    internal class Students : Users
    {
        public void TakeExam(Exams exam)
        {
            Console.WriteLine($"Student Name is: {this.Name}");
            exam.ShowExamDetails();
            exam.StartExam();
        }
    }
}
