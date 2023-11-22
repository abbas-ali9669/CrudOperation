using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperation
{
    public class StudentDbOperation : UpdateDbRecord
    {
        public int SaveStudentData(Student student)
        {
            using (SqlConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                String query = $"insert into Student(FullName, FatherName, PhoneNo, ClassName, StudentAge) "+
                                $"values('{student.FullName}', '{student.FatherName}', '{student.PhoneNo}', '{student.ClassName}', {student.StudentAge})";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    int result = command.ExecuteNonQuery();
                    
                    return result;
                    
                }
            }
        }
        public Student GetStudents(int Id)
        {
            Student student =null;
            using (SqlConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                string oString = $"Select * from Student where Id={Id}";
                SqlCommand oCmd = new SqlCommand(oString, connection);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    if (oReader.HasRows)
                    {
                        student = new Student();
                        while (oReader.Read())
                        {
                            student.FullName = oReader["FullName"].ToString();
                            student.FatherName = oReader["FatherName"].ToString();
                            student.ClassName = oReader["ClassName"].ToString();
                            student.PhoneNo = oReader["PhoneNo"].ToString();
                            student.StudentAge = Convert.ToInt32(oReader["StudentAge"]);
                        }
                    }
                   

                }
            }
            return student;
        }

        public List<Student> GetStudents()
        {
            List<Student> listStudent = new List<Student>() ;
            using (SqlConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                string oString = $"Select * from Student ;";
                SqlCommand oCmd = new SqlCommand(oString, connection);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    if (oReader.HasRows)
                    {
                        Student student=null;
                        while (oReader.Read())
                        {
                            student = new Student();
                            student.FullName = oReader["FullName"].ToString();
                            student.FatherName = oReader["FatherName"].ToString();
                            student.ClassName = oReader["ClassName"].ToString();
                            student.PhoneNo = oReader["PhoneNo"].ToString();
                            student.StudentAge = Convert.ToInt32(oReader["StudentAge"]);

                            listStudent.Add(student);
                        }
                    }


                }
            }
            return listStudent;
        }
    }
}
