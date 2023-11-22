using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperation
{
   public class UpdateDbRecord
    {
        public int UpdateStudentData(Student student)
        {
            using (SqlConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                String query = $" update Student set FullName = '{student.FullName}', FatherName ='{student.FatherName}', PhoneNo='{student.PhoneNo}',  ClassName ='{student.ClassName}' , StudentAge ={student.StudentAge} "+
                                    $"where Id = {student.Id}";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    int result = command.ExecuteNonQuery();

                    return result;

                }
            }
        }
    }
}
