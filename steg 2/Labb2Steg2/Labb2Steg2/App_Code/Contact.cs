using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Labb2Steg2.App_Code
{
    public class Contact
    {   
        //ska valideras med data annotations


        //Egenskaper
        public int ContactId { get; set; }

        public string EmailAddress { get; set; }

        public string FirstName { get; set; }

        public string LastName {get; set;}

    }
}