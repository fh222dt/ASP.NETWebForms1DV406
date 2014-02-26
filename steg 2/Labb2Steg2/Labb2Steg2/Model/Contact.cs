using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Labb2Steg2.Model
{
    public class Contact
    {           
        //Egenskaper
        public int ContactId { get; set; }

        [StringLength(50, ErrorMessage="Epost kan max ha 50 tecken"), Required(ErrorMessage="Epost måste anges"), EmailAddressAttribute(ErrorMessage="Epost har fel format")]
        public string EmailAddress { get; set; }

        [StringLength(50, ErrorMessage = "Förnamn kan max ha 50 tecken"), Required(ErrorMessage = "Förnamn måste anges")]
        public string FirstName { get; set; }
        
        [StringLength(50, ErrorMessage = "efternamn kan max ha 50 tecken"), Required(ErrorMessage = "Efternamn måste anges")]
        public string LastName {get; set;}

    }
}