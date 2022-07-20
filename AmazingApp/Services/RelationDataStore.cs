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
                            //Debug.WriteLine(String.Format("{0}, {1}, {2}, {3}", reader[0], reader[1], reader[2], reader[3]));
                        }
                    }
                    //cmd.CommandType = CommandType.Text;
                    //using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    //{
                    //    using (DataTable dt = new DataTable())
                    //    {
                    //        sda.Fill(dt);
                    //        dataGridView1.DataSource = dt;
                    //    }
                    //}
                }
            }





            return relationList;
        }
    }
}
