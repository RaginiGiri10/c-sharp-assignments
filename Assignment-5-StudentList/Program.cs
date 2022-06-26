using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5_StudentList
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Marks { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("***STUDENT MANAGEMENT***"); Console.WriteLine();
                string n;
                List<Student> studentList = new List<Student>();
                do
                {
                    int userInput = OperationSelection();
                    switch (userInput)
                    {
                        case 1:
                            AddStudent(studentList);
                            break;
                        case 2:
                            ViewAllStudentDetails(studentList);
                            break;
                        case 3:
                            ViewAllStudentDetails(studentList, true);
                            break;
                        case 4:
                            studentList.Clear();
                            Console.WriteLine("Student's records deleted successfully!!!");
                            break;
                        default:
                            Console.WriteLine("Invalid Option");
                            break;

                    }
                    Console.WriteLine();
                    Console.WriteLine("Press Y to continue");
                    n = Console.ReadLine();
                }
                while (n == "y" || n == "Y");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
        private static int OperationSelection()
        {
            Console.WriteLine("Press 1 to add student details ");
            Console.WriteLine("Press 2 to view all student's details ");
            Console.WriteLine("Press 3 to view all student's details with marks more than 60 ");
            Console.WriteLine("Press 4 to remove all student's details ");
            return Convert.ToInt32(Console.ReadLine());
        }
        private static void ViewAllStudentDetails(List<Student> studentList, bool checkMarkAbovesixty = false)
        {
            if (studentList.Count == 0)
            Console.WriteLine("No student details found.");
            else
            {
                Console.WriteLine("Student Details :");
            if (checkMarkAbovesixty)
                studentList = studentList.Where(x => x.Marks > 60).ToList();
                foreach (var student in studentList)
                {
                    var studentDetail = string.Format("ID : {0} Name : {1} Age : {2} Marks : {3}", student.Id, student.Name, student.Age, student.Marks);
                    Console.WriteLine(studentDetail);
                }
            }
        }
        private static void AddStudent(List<Student> studentList)
        {
            var student = new Student();
            Console.WriteLine("Enter your name :");
            student.Name = Console.ReadLine();
            Console.WriteLine("Enter your age :");
            student.Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your marks :");
            student.Marks = Convert.ToInt32(Console.ReadLine());
            student.Id = studentList.Count == 0 ? 100 : studentList.Max(x => x.Id) + 1;
            studentList.Add(student);
        }
    }
}

