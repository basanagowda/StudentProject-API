using Student.Models;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace Student.Repository
{
    public class StudentHubRepository
    {

        //ado codee//

        public List<studentHubModel> GetAllStudents()
        {
            List<studentHubModel> students = new List<studentHubModel>();
            using (SqlConnection cn = new SqlConnection(Utility.GetConnection()))
            {
                using (SqlCommand cmd = new SqlCommand("getallstudent", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        cn.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            studentHubModel student = new studentHubModel();
                            student.student_id = Convert.ToInt32(sdr["student_id"]);
                            student.student_name = sdr["student_name"].ToString();
                            student.student_city = sdr["student_city"].ToString();
                            student.student_email = sdr["student_Email"].ToString();
                            students.Add(student);
                        }
                        sdr.Close();
                    }
                    catch (SqlException e)
                    {
                        throw e;
                    }
                    finally
                    {
                        if (cn.State == ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                }
            }
            return students;
        }



        //for inserting student data method//

        public int insertstudent(studentHubModel student) //general method//
        {

            using (SqlConnection cn = new SqlConnection(Utility.GetConnection()))
            {
                using (SqlCommand cmd = new SqlCommand("Studentinsert", cn)) //stored procedure name//
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    
                    cmd.Parameters.AddWithValue("@student_id", student.student_id);
                    cmd.Parameters.AddWithValue("@student_name", student.student_name);
                    cmd.Parameters.AddWithValue("@student_Email", student.student_email);
                    cmd.Parameters.AddWithValue("@student_city", student.student_city);
                    try
                    {
                        cn.Open();
                        int count = cmd.ExecuteNonQuery();
                        return count;
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (cn.State == ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }

                    


                }
                
            }
           
           
        }



        public int UpdateStudent(studentHubModel student)
        {
            using (SqlConnection cn = new SqlConnection(Utility.GetConnection()))
            {
                using (SqlCommand cmd = new SqlCommand("Studentupdate", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@student_id", student.student_id);
                    cmd.Parameters.AddWithValue("@student_name", student.student_name);
                    cmd.Parameters.AddWithValue("@student_Email", student.student_email);
                    cmd.Parameters.AddWithValue("@student_city", student.student_city);
                    try
                    {
                        cn.Open();
                        int count = cmd.ExecuteNonQuery();
                        return count;
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (cn.State == ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                }
            }
        }


        public int DeleteStudent(int id)
        {
            using (SqlConnection cn = new SqlConnection(Utility.GetConnection()))
            {
                using (SqlCommand cmd = new SqlCommand("Studentdelete", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@student_id", id);
                    try
                    {
                        cn.Open();
                        int count = cmd.ExecuteNonQuery();
                        return count;
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (cn.State == ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                }
            }
        }





        public studentHubModel GetStudentById(int id)
        {
            studentHubModel student = new studentHubModel();
            using (SqlConnection cn = new SqlConnection(Utility.GetConnection()))
            {
                using (SqlCommand cmd = new SqlCommand("getbystudentid", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@student_Id", id);
                    try
                    {
                        cn.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            student.student_id = Convert.ToInt32(sdr["Student_Id"]);
                            student.student_name = sdr["student_name"].ToString();
                            student.student_city = sdr["student_city"].ToString();
                            student.student_email= sdr["student_email"].ToString();
                        }
                        sdr.Close();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (cn.State == ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                }
            }
            return student;
        }





    }
}







    



