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
    public class DALProfile
    {
        string constr = ConfigurationManager.ConnectionStrings["PilotTaskDB"].ToString();
        public List<Profile> List()
        {
            List<Profile> ProfileList = new List<Profile>();

            using (SqlConnection Connection = new SqlConnection(constr))
            {
                SqlCommand com = new SqlCommand("GetAllProfiles", Connection);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                Connection.Open();
                da.Fill(dt);
                Connection.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    ProfileList.Add(
                        new Profile
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            FirstName = Convert.ToString(dr["FirstName"]),
                            LastName = Convert.ToString(dr["LastName"]),
                            Email = Convert.ToString(dr["Email"]),
                            DateBirth = Convert.ToDateTime(dr["DateBirth"]),
                            Phone = Convert.ToString(dr["Phone"])
                        }
                        );
                }
                return ProfileList;
            }

        }
        public Profile GET(int Id)
        {
            List<Profile> ProfileList = new List<Profile>();

            using (SqlConnection Connection = new SqlConnection(constr))
            {
                SqlCommand com = new SqlCommand("GetByIDProfile", Connection);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", Id);
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                Connection.Open();
                da.Fill(dt);
                Connection.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    ProfileList.Add(
                        new Profile
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            FirstName = Convert.ToString(dr["FirstName"]),
                            LastName = Convert.ToString(dr["LastName"]),
                            Email = Convert.ToString(dr["Email"]),
                            DateBirth = Convert.ToDateTime(dr["DateBirth"]),
                            Phone = Convert.ToString(dr["Phone"])
                        }
                        );
                }
                return ProfileList.FirstOrDefault();
            }



        }
        //To Create Profile details    
        public bool Create(Profile Profile)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(constr))
                {
                    SqlCommand com = new SqlCommand("InsertProfile", Connection);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@FirstName", Profile.FirstName);
                    com.Parameters.AddWithValue("@LastName", Profile.LastName);
                    com.Parameters.AddWithValue("@DateBirth", Profile.DateBirth);
                    com.Parameters.AddWithValue("@Email", Profile.Email);
                    com.Parameters.AddWithValue("@Phone", Profile.Phone);
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

        //To Update Profile details    
        public bool Update(Profile Profile)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(constr))
                {
                    SqlCommand com = new SqlCommand("UpdateProfile", Connection);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Id", Profile.Id);
                    com.Parameters.AddWithValue("@FirstName", Profile.FirstName);
                    com.Parameters.AddWithValue("@LastName", Profile.LastName);
                    com.Parameters.AddWithValue("@DateBirth", Profile.DateBirth);
                    com.Parameters.AddWithValue("@Email", Profile.Email);
                    com.Parameters.AddWithValue("@Phone", Profile.Phone);
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

        //To delete Profile details    
        public string Delete(int Id)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(constr))
                {
                    SqlCommand com = new SqlCommand("DeleteProfile", Connection);

                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Id", Id);
                    com.Parameters.Add("@Message",SqlDbType.NVarChar,50).Direction=ParameterDirection.Output;

                    Connection.Open();
                    int i = com.ExecuteNonQuery();
                    Connection.Close();
                    if (i >= 1)
                    {
                        return com.Parameters["@Message"].Value.ToString();
                    }
                    else
                    {

                        return "false";
                    }

                }
            }
            catch (Exception ex)
            {
                return "false";
            }
        }
    }
}