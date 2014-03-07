using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Decorhelp.Model.DAL
{
    public class decorareaDAL : DALBase
    {   
        //TODO: finns för många parametrar i sprocen
        public void DeleteDecorArea(int decorAreaID)
        {// Skapar och initierar ett anslutningsobjekt.
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
                    throw; // new ApplicationException("Ett fel inträffade när data skulle hämtas från databasen");
                }
            }      
        }

        public decorarea GetDecorAreaById(int decorAreaID)
        {// Skapar och initierar ett anslutningsobjekt.
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
                            var roomIDIndex = reader.GetOrdinal("RoomID");      //hur lösa?? fr tabell utanför projektet

                            return new decorarea
                            {
                                decorAreaID = reader.GetInt32(areaIDIndex),
                                decorAreaName = reader.GetString(areaNameIndex),
                                decorAreaDescription = reader.GetValue(areaDescriptionIndex).ToString(), //är detta vettigt för att hantera ev. null-värde??                                
                                roomID = reader.GetInt32(areaIDIndex)
                            };
                        }
                    }

                    return null;
                }

                catch
                {
                    throw; // new ApplicationException("Ett fel inträffade när data skulle hämtas från databasen");
                }
            }
        }

        //TODO: underlig param @roomName, inte rätt i övrigt heller, samma fel som i  motsv. item-sprocen
        //decorAreaID, decorAreaName, decorAreaDescription, roomID
        public void InsertDecorArea(decorarea decorarea)
        {// Skapar och initierar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("app.NewDecorArea", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver. 
                    cmd.Parameters.Add("@decorAreaName", SqlDbType.VarChar, 40).Value = decorarea.decorAreaName; //väljs fr drop-down
                    cmd.Parameters.Add("@decorAreaDesc", SqlDbType.VarChar, 40).Value = decorarea.decorAreaDescription;
                    cmd.Parameters.Add("@RoomID", SqlDbType.VarChar, 50).Value = decorarea.roomID; //fr tabell utanför projektet

                    cmd.Parameters.Add("@decorAreaID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    // Hämtar primärnyckelns värde för den nya posten och tilldelar objektet värdet.
                    decorarea.decorAreaID = (int)cmd.Parameters["@decorAreaID"].Value;
                }
                catch
                {
                    throw; // new ApplicationException("Ett fel inträffade när data skulle hämtas från databasen");
                }
            }
        }

        //TODO: osäker på vad som hände m fk roomid?? Vill man ju kunna byta!
        public void UpdateDecorArea(decorarea decorarea)
        {// Skapar och initierar ett anslutningsobjekt.
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
                    throw; // new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        public IEnumerable<decorarea> GetDecorAreas()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var items = new List<decorarea>(100);

                    var cmd = new SqlCommand("app.GetAllDecorAreas", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var areaIDIndex = reader.GetOrdinal("decorAreaID");
                        var areaNameIndex = reader.GetOrdinal("decorAreaName");
                        var areaDescriptionIndex = reader.GetOrdinal("decorAreaDescription");
                        var roomIDIndex = reader.GetOrdinal("RoomID");      //hur lösa?? fr tabell utanför projektet

                        while (reader.Read())
                        {
                            items.Add(new decorarea
                            {
                                decorAreaID = reader.GetInt32(areaIDIndex),
                                decorAreaName = reader.GetString(areaNameIndex),
                                decorAreaDescription = reader.GetValue(areaDescriptionIndex).ToString(), //är detta vettigt för att hantera ev. null-värde??                                
                                roomID = reader.GetInt32(areaIDIndex)
                            });
                        }
                    }

                    items.TrimExcess();

                    return items;
                }
                catch
                {
                    throw;// new ApplicationException("Ett fel inträffade när data skulle hämtas från databasen");
                }
            }        
        }
    }
}