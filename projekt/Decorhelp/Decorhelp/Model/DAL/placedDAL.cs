using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Decorhelp.Model.DAL
{
    public class PlacedDAL : DALBase
    {   
        //TODO: sprocen finns ej
        public Placed GetPlacedById(int decorItemID)
        {// Skapar och initierar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("app.GetPlaced", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till parameter för lagrade proceduren
                    cmd.Parameters.Add("@decorItemID", SqlDbType.Int, 4).Value = decorItemID;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var placedIDIndex = reader.GetOrdinal("placedID");
                            var itemIndex = reader.GetOrdinal("decorItemID");
                            var periodIDIndex = reader.GetOrdinal("periodID");  //hur lösa?? fr tabell utanför projektet
                            var isPlacedIndex = reader.GetOrdinal("isPlaced");      

                            return new Placed
                            {
                                placedID = reader.GetInt32(placedIDIndex),
                                decorItemID = reader.GetInt32(itemIndex),
                                periodID = reader.GetInt32(periodIDIndex),                                
                                isPlaced = reader.GetBoolean(isPlacedIndex)
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

        //TODO: sprocen finns ej
        public IEnumerable<Placed> GetAllPlaced()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var items = new List<Placed>(100);

                    var cmd = new SqlCommand("app.GetAllPlaced", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var placedIDIndex = reader.GetOrdinal("placedID");
                        var itemIndex = reader.GetOrdinal("decorItemID");
                        var periodIDIndex = reader.GetOrdinal("periodID");  //hur lösa?? fr tabell utanför projektet
                        var isPlacedIndex = reader.GetOrdinal("isPlaced");

                        while (reader.Read())
                        {
                            items.Add(new Placed
                            {
                                placedID = reader.GetInt32(placedIDIndex),
                                decorItemID = reader.GetInt32(itemIndex),
                                periodID = reader.GetInt32(periodIDIndex),
                                isPlaced = reader.GetBoolean(isPlacedIndex)
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