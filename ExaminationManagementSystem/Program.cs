namespace ExaminationManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Instructors instructor = new Instructors { Name = "Dr.Ali" };
            Students student = new Students { Name = "Rahma" };
            char decision = 'y';
            while (decision=='y')
            {
                Console.WriteLine("Choose Mode:");
                Console.WriteLine("1 - Doctor Mode");
                Console.WriteLine("2 - Student Mode");

                int mode;
                while (!int.TryParse(Console.ReadLine(), out mode) || (mode != 1 && mode != 2))
                {
                    Console.Write("Invalid mode, try again: ");
                }

                if (mode == 1)
                {
                    Console.WriteLine($"\nHello {instructor.Name}");
                    char more;
                    do
                    {
                        instructor.AddQuestion();
                        Console.Write("Add another question? (y/n): ");
                        more = Convert.ToChar(Console.ReadLine());
                        while (more != 'y' && more != 'n')
                        {
                            Console.Write("invalid choice, try again: ");
                            more = Convert.ToChar(Console.ReadLine());
                        }
                        Console.WriteLine();
                    }
                    while (more == 'y');
                    Console.WriteLine("\nAll Questions Added");
                }
                else
                {
                    if (Instructors.QuestionBank.Count == 0)
                    {
                        Console.WriteLine("No questions available. wait the doctor to add questions.");
                        continue;
                    }
                    Console.WriteLine("\nChoose Exam Type:");
                    Console.WriteLine("1 - Practice Exam");
                    Console.WriteLine("2 - Final Exam");

                    int choice;
                    while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
                        Console.Write("Invalid input, try again: ");

                    Exams exam = instructor.SetExam(choice);

                    student.TakeExam(exam);
                }
                Console.WriteLine("Do you want to enter again any mode? (y/n)");
                decision = Convert.ToChar(Console.ReadLine());
                while (decision != 'y' && decision != 'n')
                {
                    Console.Write("invalid choice, try again: ");
                    decision = Convert.ToChar(Console.ReadLine());
                }
            }
            Console.WriteLine("Program Exited. Goodbye!");
        }
    }
}
