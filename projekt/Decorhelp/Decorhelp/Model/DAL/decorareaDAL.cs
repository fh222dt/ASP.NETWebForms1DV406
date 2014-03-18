using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Decorhelp.Model.DAL
{
    public class DecorareaDAL : DALBase
    {   
        public void DeleteDecorArea(int decorAreaID)
        {   
            // Skapar och initierar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("app.DeleteDecorArea", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till parameter för lagrade proceduren
                    cmd.Parameters.Add("@decorareaID", SqlDbType.Int, 4).Value = decorAreaID;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }

                catch
                {
                    throw new ApplicationException("Ett fel inträffade när data skulle hämtas från databasen");
                }
            }      
        }

        public Decorarea GetDecorAreaById(int decorAreaID)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("app.GetDecorArea", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till parameter för lagrade proceduren
                    cmd.Parameters.Add("@decorareaID", SqlDbType.Int, 4).Value = decorAreaID;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var areaIDIndex = reader.GetOrdinal("decorAreaID");
                            var areaNameIndex = reader.GetOrdinal("decorAreaName");
                            var areaDescriptionIndex = reader.GetOrdinal("decorAreaDescription");
                            var roomIDIndex = reader.GetOrdinal("roomID");

                            return new Decorarea
                            {
                                decorAreaID = reader.GetInt32(areaIDIndex),
                                decorAreaName = reader.GetString(areaNameIndex),
                                decorAreaDescription = reader.GetValue(areaDescriptionIndex).ToString(), //för att kunna hantera ev. null-värde                               
                                roomID = reader.GetInt32(roomIDIndex)
                            };
                        }
                    }

                    return null;
                }

                catch
                {
                    throw new ApplicationException("Ett fel inträffade när data skulle hämtas från databasen");
                }
            }
        }

        public void InsertDecorArea(Decorarea decorarea)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("app.NewDecorArea", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver. 
                    cmd.Parameters.Add("@decorAreaName", SqlDbType.VarChar, 40).Value = decorarea.decorAreaName;
                    cmd.Parameters.Add("@decorAreaDesc", SqlDbType.VarChar, 40).Value = decorarea.decorAreaDescription;
                    cmd.Parameters.Add("@RoomID", SqlDbType.Int, 4).Value = decorarea.roomID;

                    cmd.Parameters.Add("@decorAreaID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    // Hämtar primärnyckelns värde för den nya posten och tilldelar objektet värdet.
                    decorarea.decorAreaID = (int)cmd.Parameters["@decorAreaID"].Value;
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade när data skulle hämtas från databasen");
                }
            }
        }

        public void UpdateDecorArea(Decorarea decorarea)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("app.UpdateDecorArea", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver. 
                    cmd.Parameters.Add("@decorareaID", SqlDbType.Int, 4).Value = decorarea.decorAreaID;
                    cmd.Parameters.Add("@decorAreaName", SqlDbType.VarChar, 40).Value = decorarea.decorAreaName;
                    cmd.Parameters.Add("@decorAreaDescription", SqlDbType.VarChar, 40).Value = decorarea.decorAreaDescription;
                    cmd.Parameters.Add("@roomID", SqlDbType.Int, 4).Value = decorarea.roomID;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        public IEnumerable<Decorarea> GetDecorAreas()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var items = new List<Decorarea>(100);

                    var cmd = new SqlCommand("app.GetAllDecorAreas", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var areaIDIndex = reader.GetOrdinal("decorAreaID");
                        var areaNameIndex = reader.GetOrdinal("decorAreaName");
                        var areaDescriptionIndex = reader.GetOrdinal("decorAreaDescription");
                        var roomIDIndex = reader.GetOrdinal("RoomID");

                        while (reader.Read())
                        {
                            items.Add(new Decorarea
                            {
                                decorAreaID = reader.GetInt32(areaIDIndex),
                                decorAreaName = reader.GetString(areaNameIndex),
                                decorAreaDescription = reader.GetValue(areaDescriptionIndex).ToString(), //för att kunna hantera ev. null-värde                                
                                roomID = reader.GetInt32(areaIDIndex)
                            });
                        }
                    }

                    items.TrimExcess();

                    return items;
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade när data skulle hämtas från databasen");
                }
            }        
        }
    }
}