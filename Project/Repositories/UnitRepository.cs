using RecipeModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Repositories.Interfaces;

namespace Repositories
{
    public class UnitRepository : IUnitRepository
    {
        //string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString.ToString(); //Ligação à base de dados
        private static Generic _generic = new Generic();
        private static string connectionString = _generic.GetConnectionString();

        public DataTable GetAllUnits()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Unit";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    if (con.State != ConnectionState.Open) //Ligação for diferente de aberto Abre
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    if (con.State != ConnectionState.Open)
                        con.Open();

                }
            }

            return dt;
        }



        public DataTable GetUnitById(int id)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Unit Where id = @unitId";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@unitId", SqlDbType.Int).Value = id;  //Definimos o formato neste caso é um INT

                    if (con.State != ConnectionState.Open) //Ligação for diferente de aberto Abre
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }// Comando/Instrução/Faz isto

            }
            return dt;
        }



        public void InsertNewUnit(Unit unit)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "INSERT INTO Unit(name) VALUES(@name)";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    #region Insert query values
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = unit.Name;
                    #endregion

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void UpdateUnit(Unit unit)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "UPDATE Unit SET name= @name WHERE id = @id" + Environment.NewLine;

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    #region Insert query values
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = unit.Id;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = unit.Name;

                    #endregion

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();


                }
            }
        }


        public DataTable GetUnitByName(string name)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Unit WHERE name = @name";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }
            return dt;
        }

    }
}
