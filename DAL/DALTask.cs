using Entity.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALTask
    {
        string constr = ConfigurationManager.ConnectionStrings["PilottaskDB"].ToString();
        public List<task> List()
        {
            List<task> taskList = new List<task>();

            using (SqlConnection Connection = new SqlConnection(constr))
            {
                SqlCommand com = new SqlCommand("GetAlltasks", Connection);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                Connection.Open();
                da.Fill(dt);
                Connection.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    taskList.Add(
                        new task
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            FkprofileId = Convert.ToInt32(dr["FkprofileId"]),
                            Status = Convert.ToInt32(dr["Status"]),
                            TaskName = Convert.ToString(dr["TaskName"]),
                            TaskDescription = Convert.ToString(dr["TaskDescription"]),
                            StartTime = Convert.ToDateTime(dr["StartTime"])
                        }
                        );
                }
                return taskList;
            }

        }
        public task GET(int Id)
        {
            List<task> taskList = new List<task>();

            using (SqlConnection Connection = new SqlConnection(constr))
            {
                SqlCommand com = new SqlCommand("GetByIDTask", Connection);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", Id);
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                Connection.Open();
                da.Fill(dt);
                Connection.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    taskList.Add(
                        new task
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            FkprofileId = Convert.ToInt32(dr["FkprofileId"]),
                            Status = Convert.ToInt32(dr["Status"]),
                            TaskName = Convert.ToString(dr["TaskName"]),
                            TaskDescription = Convert.ToString(dr["TaskDescription"]),
                            StartTime = Convert.ToDateTime(dr["StartTime"])
                        }
                        );
                }
                return taskList.FirstOrDefault();
            }



        }
        //To Create task details    
        public bool Create(task task)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(constr))
                {
                    SqlCommand com = new SqlCommand("[InsertTask]", Connection);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@TaskName", task.TaskName);
                    com.Parameters.AddWithValue("@FKProfileId", task.FkprofileId);
                    com.Parameters.AddWithValue("@TaskDescription", task.TaskDescription);
                    com.Parameters.AddWithValue("@StartTime", task.StartTime);
                    com.Parameters.AddWithValue("@Status", task.Status);
                    Connection.Open();
                    int i = com.ExecuteNonQuery();
                    Connection.Close();
                    if (i >= 1)
                    {
                        return true;
                    }
                    else
                    {

                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        //To Update task details    
        public bool Update(task task)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(constr))
                {
                    SqlCommand com = new SqlCommand("UpdateTask", Connection);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Id", task.Id);
                    com.Parameters.AddWithValue("@TaskName", task.TaskName);
                    com.Parameters.AddWithValue("@FKProfileId", task.FkprofileId);
                    com.Parameters.AddWithValue("@TaskDescription", task.TaskDescription);
                    com.Parameters.AddWithValue("@StartTime", task.StartTime);
                    com.Parameters.AddWithValue("@Status", task.Status);
                    Connection.Open();
                    int i = com.ExecuteNonQuery();
                    Connection.Close();
                    if (i >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        //To delete task details    
        public bool Delete(int Id)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(constr))
                {
                    SqlCommand com = new SqlCommand("DeleteTask", Connection);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Id", Id);
                    Connection.Open();
                    int i = com.ExecuteNonQuery();
                    Connection.Close();
                    if (i >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}