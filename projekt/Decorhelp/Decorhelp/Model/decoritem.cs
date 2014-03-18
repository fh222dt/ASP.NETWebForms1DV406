using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Decorhelp.Model
{
    public class Decoritem
    {
        public int decorItemID { get; set; }

        [StringLength(40, ErrorMessage = "Namn på föremål kan max ha 40 tecken"), Required(ErrorMessage = "Namn på föremål måste anges")]
        public string decorItemName { get; set; }

        //ej obligatorisk
        [StringLength(40, ErrorMessage = "Beskrivning av föremål kan max ha 40 tecken")]
        public string decorItemDescription { get; set; }

        [Required(ErrorMessage = "Inredningsyta måste anges")]
        public int decorAreaID { get; set; }

        //nedan används endast för att visa en lista av alla föremål via en vy i db
        [StringLength(40, ErrorMessage = "Namn på rum kan max ha 40 tecken"), Required(ErrorMessage = "Rum måste anges")]
        public string roomName { get; set; }

        [StringLength(40, ErrorMessage = "Namn på yta kan max ha 40 tecken"), Required(ErrorMessage = "Namn på yta måste anges")]
        public string decorAreaName { get; set; }
    }
}