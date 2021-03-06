﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Labb2Steg2.Model.DAL
{
    public class ContactDAL: DALBase
    {
        public void DeleteContact(int contactId)
        { 
            // Skapar och initierar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Person.uspRemoveContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till parameter för lagrade proceduren
                    cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Value = contactId;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                                        
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade när data skulle hämtas från databasen");
                }
            }

        }

        public Contact GetContactById(int contactId)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Person.uspGetContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till parameter för lagrade proceduren
                    cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Value = contactId;
                                        
                    conn.Open();
                                        
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {                        
                        if (reader.Read())
                        {                            
                            var contactIdIndex = reader.GetOrdinal("ContactId");
                            var firstNameIndex = reader.GetOrdinal("FirstName");
                            var lastNameIndex = reader.GetOrdinal("LastName");
                            var emailAddressIndex = reader.GetOrdinal("EmailAddress");
                                                        
                            return new Contact
                            {
                                ContactId = reader.GetInt32(contactIdIndex),
                                FirstName = reader.GetString(firstNameIndex),
                                LastName = reader.GetString(lastNameIndex),
                                EmailAddress = reader.GetString(emailAddressIndex)
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

        public IEnumerable<Contact> GetContacts()
        {
            
            using (var conn = CreateConnection())
            {
                try
                {                    
                    var contacts = new List<Contact>(100);
                                        
                    var cmd = new SqlCommand("Person.uspGetContacts", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                                        
                    using (var reader = cmd.ExecuteReader())
                    {
                        var contactIdIndex = reader.GetOrdinal("ContactId");
                        var firstNameIndex = reader.GetOrdinal("FirstName");
                        var lastNameIndex = reader.GetOrdinal("LastName");
                        var emailAddressIndex = reader.GetOrdinal("EmailAddress");
                                                
                        while (reader.Read())
                        {                            
                            contacts.Add(new Contact
                            {
                                ContactId = reader.GetInt32(contactIdIndex),
                                FirstName = reader.GetString(firstNameIndex),
                                LastName = reader.GetString(lastNameIndex),
                                EmailAddress = reader.GetString(emailAddressIndex)
                            });
                        }
                    }
                                        
                    contacts.TrimExcess();

                    return contacts;
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade när data skulle hämtas från databasen");
                }
            }
        }
        
        public IEnumerable<Contact> GetContactsPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            
            using (var conn = CreateConnection())
            {
                try
                {
                    var contacts = new List<Contact>(maximumRows);

                    var cmd = new SqlCommand("Person.uspGetContactsPageWise", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //sidnr
                    var pageNo = startRowIndex / maximumRows +1;

                    // Lägger till de paramterar den lagrade proceduren kräver. 
                    cmd.Parameters.Add("@PageIndex", SqlDbType.Int, 4).Value = pageNo; //vilket sidnr vi börjar på
                    cmd.Parameters.Add("@PageSize", SqlDbType.Int, 4).Value = maximumRows;      //hur många rader per sida (20st)

                    cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    var allContacts = GetContacts();
                    
                    totalRowCount = allContacts.Count();

                    return allContacts.Skip(startRowIndex).Take(maximumRows);
                    
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade när data skulle hämtas från databasen");
                }
            }
            
        }

        public void InsertContact(Contact contact)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("Person.uspAddContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver. 
                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = contact.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = contact.LastName;
                    cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50).Value = contact.EmailAddress;
                                        
                    cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                                        
                    conn.Open();
                                        
                    cmd.ExecuteNonQuery();

                    // Hämtar primärnyckelns värde för den nya posten och tilldelar objektet värdet.
                    contact.ContactId = (int)cmd.Parameters["@ContactId"].Value;
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade när data skulle hämtas från databasen");
                }
            }
        }

        public void UpdateContact(Contact contact)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("Person.uspUpdateContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lägger till de paramterar den lagrade proceduren kräver. 
                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = contact.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = contact.LastName;
                    cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50).Value = contact.EmailAddress;
                    cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Value = contact.ContactId;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                    
                }
                catch
                {                    
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
    }
}