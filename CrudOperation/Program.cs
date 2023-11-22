using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperation
{
    class Program
    {
        public static void DeleteData()
        {
            DeleteRecord student = new DeleteRecord();
            Console.Write("Enter id to be deleted: ");
            int stid = int.Parse(Console.ReadLine());
            student.DeleteStudentData(stid);
        }

        public static void InsertRecordStudent()
        {
            Student objStudent = new Student();
            Console.WriteLine("Enter Student Name");
            objStudent.FullName = Console.ReadLine();

            //Console.WriteLine($"Full Name Of Student: {objStudent.FullName}");

            Console.WriteLine("Enter Father Name");
            objStudent.FatherName = Console.ReadLine();

            Console.WriteLine("Enter Phone Number");
            objStudent.PhoneNo = Console.ReadLine();
            Console.WriteLine("Enter Class Name");
            objStudent.ClassName = Console.ReadLine();
            Console.WriteLine("Enter Student Age");
            objStudent.StudentAge = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("---------------------------------");


            StudentDbOperation objStudentOperation = new StudentDbOperation();
            int result = objStudentOperation.SaveStudentData(objStudent);
            if (result > 0)
                Console.WriteLine("Data Saved Successfuly....!");
        }

        public static void UpdateRecordStudent()

        {
            StudentDbOperation objStudentOperation = new StudentDbOperation();
            Student objStudent = new Student();

            Console.WriteLine("Enter Student Id first:");
            objStudent.Id =Convert.ToInt32( Console.ReadLine());

            Student student = objStudentOperation.GetStudents(objStudent.Id);
            if (student == null)
            {
                Console.WriteLine("Invalid Student Id Provided....!");

            }
            else
            {
                Console.WriteLine("Enter Student Name");

                objStudent.FullName = Console.ReadLine();

                //Console.WriteLine($"Full Name Of Student: {objStudent.FullName}");

                Console.WriteLine("Enter Father Name");
                objStudent.FatherName = Console.ReadLine();

                Console.WriteLine("Enter Phone Number");
                objStudent.PhoneNo = Console.ReadLine();
                Console.WriteLine("Enter Class Name");
                objStudent.ClassName = Console.ReadLine();
                Console.WriteLine("Enter Student Age");
                objStudent.StudentAge = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("---------------------------------");



                int result = objStudentOperation.UpdateStudentData(objStudent);
                if (result > 0)
                    Console.WriteLine("Data Updated Successfuly....!");
                else
                    Console.WriteLine("Data Not Updated Successfuly....!");
            }
        }

        public static void GetStudents()
        {
            StudentDbOperation objStudentOperation = new StudentDbOperation();
            var students = objStudentOperation.GetStudents();
            foreach (var student in students)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine($"{student.FullName} ");
                Console.WriteLine($"{student.FatherName} ");
                Console.WriteLine($"{student.ClassName} ");
                Console.WriteLine($"{student.PhoneNo} ");
                Console.WriteLine($"{student.StudentAge} ");
                Console.WriteLine("----------------------");
            }
        }
        static void Main(string[] args)
        {
            // InsertRecordStudent();
            // UpdateRecordStudent();
            // GetStudents();
            DeleteData();

            Console.ReadLine();

        }
    }
}
