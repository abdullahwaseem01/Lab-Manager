
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OntarioTechUniversity.Models

{
    public class SafetyDataSheet
    {
        [Key]
        public string Name { get; set; }
        [Display(Name = "Model")]
        public string Model { get; set; }
        public string Manufacturer{ get; set; }

        [Display(Name = "Date of Issue")]
        public DateTime DateOfIssue { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Revision")]
        public DateTime RevisionDate { get; set; }


        [ForeignKey("Location")]
        [Display(Name ="Location")]
        public string LocationID { get; set; }
        public string Status { get; set; }
        [Column(TypeName ="varchar(500)")]
        [Display(Name = "Link")]
        public string Url { get; set; }
        public Location Location { get; set; }
    }
}