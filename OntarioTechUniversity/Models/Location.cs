using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace OntarioTechUniversity.Models
{
    public class Location
    {
        [Key]
        [Display(Name = "Location")]
        public string LocationID { get; set; }
        [Display(Name = "Comment")]
        public string Comment { get; set; }

        public List<Item> Items { get; set; }
        public List<SafetyDataSheet>SafetyDataSheets { get; set; }
    }
}
