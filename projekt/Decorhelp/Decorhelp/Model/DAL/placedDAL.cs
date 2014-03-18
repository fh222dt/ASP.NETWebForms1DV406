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
        public IEnumerable<Placed> GetAllPlaced(int periodID)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var items = new List<Placed>(100);

                    var cmd = new SqlCommand("app.GetAllPlaced", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till parameter för lagrade proceduren
                    cmd.Parameters.Add("@periodID", SqlDbType.Int, 4).Value = periodID;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var placedIDIndex = reader.GetOrdinal("placedID");
                        var itemIndex = reader.GetOrdinal("decorItemID");
                        var periodIDIndex = reader.GetOrdinal("periodID");
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
                    throw new ApplicationException("Ett fel inträffade när data skulle hämtas från databasen");
                }
            }
        }
    }
}