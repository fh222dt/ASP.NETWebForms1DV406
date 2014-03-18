using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Decorhelp.Model
{
    public class Placed
    {
        public int placedID { get; set; }

        [Required(ErrorMessage = "Föremål måste anges")]
        public int decorItemID { get; set; }
        
        [Required(ErrorMessage = "Period måste anges")]
        public int periodID { get; set; }

        [Required(ErrorMessage = "Du måste välja om föremålet ska placeras.")]
        public bool isPlaced { get; set; }
    }
}