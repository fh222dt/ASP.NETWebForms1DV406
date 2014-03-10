using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Decorhelp.Model
{
    public class Decoritem
    {
        //Egenskaper
        public int decorItemID { get; set; }

        [StringLength(40, ErrorMessage = "Namn på yta kan max ha 40 tecken"), Required(ErrorMessage = "Namn på föremål måste anges")]
        public string decorItemName { get; set; }

        //ej obligatorisk
        [StringLength(40, ErrorMessage = "Beskrivning av yta kan max ha 40 tecken")]
        public string decorItemDescription { get; set; }

        //fk, hur validera?
        public int decorAreaID { get; set; }
    }
}