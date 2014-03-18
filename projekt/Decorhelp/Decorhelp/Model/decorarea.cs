using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Decorhelp.Model
{
    public class Decorarea
    {
        public int decorAreaID { get; set; }

        [StringLength(40, ErrorMessage = "Namn på yta kan max ha 40 tecken"), Required(ErrorMessage = "Namn på yta måste anges")]
        public string decorAreaName { get; set; }

        //ej obligatorisk
        [StringLength(40, ErrorMessage = "Beskrivning av yta kan max ha 40 tecken")]
        public string decorAreaDescription { get; set; }

        //ska hårdkodas då det kommer från tabell utanför projektet
        [Required(ErrorMessage = "Rum måste anges")]
        public int roomID { get; set; }
    }
}