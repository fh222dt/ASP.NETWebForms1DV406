using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Decorhelp.Model.DAL
{
    public class decoritemDAL: DALBase
    {   
        public void DeleteDecorItem(int decorItemID)
        {   // Skapar och initierar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("app.DeleteDecoritem", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till parameter för lagrade proceduren
                    cmd.Parameters.Add("@decoritemID", SqlDbType.Int, 4).Value = decorItemID;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }

                catch
                {
                    throw; // new ApplicationException("Ett fel inträffade när data skulle hämtas från databasen");
                }
            }            
        }

        public decoritem GetDecorItemById(int decorItemID)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("app.GetDecorItem", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till parameter för lagrade proceduren
                    cmd.Parameters.Add("@decoritemID", SqlDbType.Int, 4).Value = decorItemID;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var itemIDIndex = reader.GetOrdinal("decorItemID");
                            var itemNameIndex = reader.GetOrdinal("decorItemName");
                            var itemDescriptionIndex = reader.GetOrdinal("decorItemDescription");
                            var areaIDIndex = reader.GetOrdinal("decorAreaID");

                            return new decoritem
                            {
                                decorItemID = reader.GetInt32(itemIDIndex),
                                decorItemName = reader.GetString(itemNameIndex),
                                decorItemDescription = reader.GetValue(itemDescriptionIndex).ToString(), //är detta vettigt för att hantera ev. null-värde??                                
                                decorAreaID = reader.GetInt32(areaIDIndex)
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
        
        //TODO: parametrar ej komplett i sprocen (in & ut)
        public void InsertDecorItem(decoritem decoritem)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("app.NewDecorItem", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver. 
                    cmd.Parameters.Add("@decorAreaID", SqlDbType.Int, 4).Value = decoritem.decorAreaID; //väljs fr drop-down
                    cmd.Parameters.Add("@decorItemName", SqlDbType.VarChar, 40).Value = decoritem.decorItemName;
                    //cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50).Value = contact.EmailAddress;

                    //cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    // Hämtar primärnyckelns värde för den nya posten och tilldelar objektet värdet.
                    decoritem.decorItemID = (int)cmd.Parameters["@ContactId"].Value; //ej rätt!!!
                }
                catch
                {
                    throw; // new ApplicationException("Ett fel inträffade när data skulle hämtas från databasen");
                }
            }
        }

        //TODO: osäker på vad som hände m fk decorareaid?? Vill man ju kunna byta!
        public void UpdateDecorItem(decoritem decoritem)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("app.UpdateDecorItem", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver. 
                    cmd.Parameters.Add("@decoritemID", SqlDbType.Int, 4).Value = decoritem.decorItemID;
                    cmd.Parameters.Add("@decoritemName", SqlDbType.VarChar, 40).Value = decoritem.decorItemName;
                    cmd.Parameters.Add("@decoritemDescription", SqlDbType.VarChar, 40).Value = decoritem.decorItemDescription;                    

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw; // new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        public IEnumerable<decoritem> GetDecorItems()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var items = new List<decoritem>(100);

                    var cmd = new SqlCommand("app.GetAllDecorItems", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var itemIDIndex = reader.GetOrdinal("decorItemID");
                        var itemNameIndex = reader.GetOrdinal("decorItemName");
                        var itemDescriptionIndex = reader.GetOrdinal("decorItemDescription");
                        var areaIDIndex = reader.GetOrdinal("decorAreaID");

                        while (reader.Read())
                        {
                            items.Add(new decoritem
                            {
                                decorItemID = reader.GetInt32(itemIDIndex),
                                decorItemName = reader.GetString(itemNameIndex),
                                decorItemDescription = reader.GetValue(itemDescriptionIndex).ToString(), //är detta vettigt för att hantera ev. null-värde??                                
                                decorAreaID = reader.GetInt32(areaIDIndex)
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