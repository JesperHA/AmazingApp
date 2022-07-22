using AmazingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;

namespace AmazingApp.Services
{
    class RelationDataStore : IRelationDataStore<Relation>
    {
        string connectionString = @"Data Source=bhs-sql3;Initial Catalog=transform_lookup;" + "Integrated Security=true;";
        public async Task<IEnumerable<Relation>> GetRelationList()
        {
            List<Relation> relationList = new List<Relation>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM relation_information_350", con))
                {
                    con.Open();
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int relationId = (int)reader["relation_id"];
                            string name = reader["name"].ToString();
                            int department = (int)reader["department"];
                            string incoterm = reader["incoterm"].ToString();

                            relationList.Add(new Relation { RelationId = relationId, Name = name, Department = department, Incoterm = incoterm });
                        }
                    }
                    con.Close();
                }
            }
            return relationList;
        }

        public async Task UpdateRelation(Relation relation)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "UPDATE relation_information_350 SET name = @name, department = @department, incoterm = @incoterm WHERE relation_id = @relationId ";
                    command.Parameters.AddWithValue("@relationId", relation.RelationId);
                    command.Parameters.AddWithValue("@name", relation.Name);
                    command.Parameters.AddWithValue("@department", relation.Department);
                    command.Parameters.AddWithValue("@incoterm", relation.Incoterm);
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }

            }

        }

        public async Task CreateRelation(Relation relation)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string insertQuery = "INSERT INTO relation_information_350 (relation_id,name,department,incoterm) VALUES (@relationId,@name,@department, @incoterm)";
                string identQuery = "SET IDENTITY_INSERT Transform_lookup.dbo.relation_information_350 ON";
                SqlTransaction trans = null;

                try
                {
                    con.Open();
                    Debug.WriteLine("Connection opened!");
                    trans = con.BeginTransaction();
                    Debug.WriteLine("Transaction beginning!");
                    SqlCommand identCmd = new SqlCommand(identQuery, con, trans);
                    identCmd.ExecuteNonQuery();
                    Debug.WriteLine("Identity set! now committing!");
                    SqlCommand insertCmd = new SqlCommand(insertQuery, con, trans);
                    insertCmd.Parameters.AddWithValue("@relationId", relation.RelationId);
                    insertCmd.Parameters.AddWithValue("@name", relation.Name);
                    insertCmd.Parameters.AddWithValue("@department", relation.Department);
                    insertCmd.Parameters.AddWithValue("@incoterm", relation.Incoterm);
                    insertCmd.ExecuteNonQuery();
                    Debug.WriteLine("Parameters Added!");


                    trans.Commit();
                    Debug.WriteLine("Comitted!");
                }
                catch (Exception e)
                {

                    trans.Rollback();
                    Debug.WriteLine("Transaction failed!");
                    throw;
                }
                finally
                {
                    con.Close();
                    Debug.WriteLine("Connection closed!");
                }

            }

        }

    }
}
