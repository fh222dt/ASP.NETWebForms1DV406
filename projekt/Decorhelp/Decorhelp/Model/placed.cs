using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Decorhelp.Model
{
    public class placed
    {
        //Egenskaper
        public int placedID { get; set; }

        //[StringLength(40, ErrorMessage = "Namn på yta kan max ha 40 tecken"), Required(ErrorMessage = "Namn på yta måste anges")]
        public int decorItemID { get; set; }

        //ska hårdkodas då det kommer från tabell utanför projektet
        [Required(ErrorMessage = "Period måste anges")]
        public int periodID { get; set; }

        [Required(ErrorMessage = "Du måste välja om föremålet ska placeras.")]
        public bool placed { get; set; }
    }
}