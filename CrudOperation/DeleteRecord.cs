using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperation
{
    class DeleteRecord
    {
        public void DeleteStudentData(int studentid)
        
        {
            using (SqlConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                String query = $" DELETE FROM Student WHERE id = {studentid}";
                // String query = $" DELETE FROM Student WHERE id = {student.id}";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    int result = command.ExecuteNonQuery();

                   // return result;

                }
            }
        }
    }
}
