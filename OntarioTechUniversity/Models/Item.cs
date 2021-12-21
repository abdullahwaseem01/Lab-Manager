using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OntarioTechUniversity.Models
{
    public class Item
    {
        
        public int ItemID { get; set; } //primary key won't be assigned by the user
        [Display(Name ="Item #")] 
        public string ItemNum { get; set; } //item Number newly added

        [Display(Name = "Item Name")] 
        public string ItemName { get; set; } // item name
        public int Quantity { get; set; } // quantity
        public string Manufacturer { get; set; } // name of the manufacturer
        public string Model { get; set; } // model name or number

        [Display(Name = "Item Comment")]
        public string ItemComment { get; set; } // Item comment

        [Display (Name = "Serial Number")]
        public string SerialNumber { get; set; } // serial number
        [Display (Name ="Tag Number")]
        public string TagNumber { get; set; } //tag nummber
        [Display (Name ="Product Overview")] 
        [Column(TypeName = "varchar(500)")]
        public string ProductOverview { get; set; } // product overview
        [Display(Name = "MSDS")]
        [Column(TypeName = "varchar(500)")]
        public string MSDS { get; set; } // MSDS - material safety data sheets
        [Display(Name = "Product Manual")]
        [Column(TypeName = "varchar(500)")]
        public string ProductManual { get; set; } // product manual
        [Display(Name = "Recommended Maintenance")]
        [Column(TypeName = "varchar(500)")]
        public string RecommendedMaintenance { get; set; } // recommended maintainenance
        [Display(Name = "Waste Management")]
        [Column(TypeName = "varchar(500)")]
        public string WasteManagement { get; set; } // waste management
        [Display(Name = "Certifications")]
        [Column(TypeName = "varchar(500)")]
        public string Certification { get; set; } // certification

        [Display(Name = "Date Modified")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateModified { get; set; }

        //Foreign key for Location
        [ForeignKey("Location")]
        [Display(Name ="Location")]
        public string LocationID { get; set; }
        public Location Location { get; set; }

    }
}
