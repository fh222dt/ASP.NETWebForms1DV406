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
    {   //TODO: fixa alla metoder
        public void DeleteDecorItem(int decorItemID)
        {
            throw new NotImplementedException();
        }

        public decoritem GetDecorItemById(int decorItemID)
        {
            throw new NotImplementedException();
        }

        public void InsertDecorItem(decoritem decoritem)
        {
            throw new NotImplementedException();
        }

        public void UpdateDecorItem(decoritem decoritem)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<decoritem> GetDecorItems()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var items = new List<decoritem>(100);

                    var cmd = new SqlCommand("Person.uspGetContacts", conn);    //ändra namn
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
                                decorItemDescription = reader.GetString(itemDescriptionIndex),
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

            //throw new NotImplementedException();
        }
    }
}