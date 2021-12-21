using OntarioTechUniversity.Models;
using System;
using System.Linq;

namespace OntarioTechUniversity.Data
{
    public class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            //look for any items
            if (context.Items.Any())
            {
                return; //DB has been seeded
            }

            var items = new Item[]
            {
                new Item{ItemID = 1,
                         ItemNum = "Some alpha-numeric item number", 
                         ItemName = "something",
                         Quantity = 5, 
                         Manufacturer = "some manufacturer", 
                         Model = "some model", 
                         ItemComment = "some comment regarding the description of the item", 
                         SerialNumber = "some Alpha-numeric serialNumber", 
                         TagNumber = "some Alpha-numeric tagNumber", 
                         ProductOverview = "some link to the product view of the item",
                         MSDS = "some link to MSDS of item", 
                         ProductManual = "some link to the product manual",
                         RecommendedMaintenance = "Some link to recommended maintenance of the item",
                         WasteManagement = "some link/text about waste managemnent of the item",
                         Certification = "certification associated with the item",
                         DateModified = DateTime.Parse("2021-05-31"), 
                         LocationID = "ENGR 1050", 
                    }
            };

            foreach (Item i in items)
            {
                context.Items.Add(i);
            }
            context.SaveChanges();
           
            var locations = new Location[]
            {
                new Location{Comment = "across Polonsky Commons"}

            };

            foreach (Location b in locations)
            {
                context.Locations.Add(b);
            }

            context.SaveChanges();

            var safetyDataSheets = new SafetyDataSheet[]
            {
                new SafetyDataSheet{Name = "some name", 
                                    Model = "some model", 
                                    Manufacturer = "some manufacturer",
                                    DateOfIssue = DateTime.Parse("2021-05-31"),
                                    RevisionDate = DateTime.Parse("2021-05-31"), Status = "no status available",
                                    LocationID = "ENGR", 
                                    Url = "some hyperlink which would lead to the item's manual"} 
            };

            foreach (SafetyDataSheet i in safetyDataSheets)
            {
                context.SafetyDataSheets.Add(i);
            }
            context.SaveChanges();

        }
    }
}
