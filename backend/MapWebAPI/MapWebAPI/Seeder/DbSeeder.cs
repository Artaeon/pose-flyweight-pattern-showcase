namespace MapWebAPI.Seeder
{
    using MapWebAPI.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using Attribute = Models.Attribute;

    public static class DbSeeder
    {
        public static void Seed(MapAppDbContext context)
        {
            context.Reviews.ExecuteDelete();
            context.Attributes.ExecuteDelete();
            context.Locations.ExecuteDelete();
            context.LocationTypes.ExecuteDelete();


            context.Database.EnsureCreated();
            
            if (!context.LocationTypes.Any())
            {                
                var locationTypes = new LocationType[]
                {
                new LocationType { LocationTypeId = 1, TypeName = "Café", IconPath = "http://maps.gstatic.com/mapfiles/ms2/micons/coffeehouse.png" },
                new LocationType { LocationTypeId = 2, TypeName = "Bibliothek", IconPath = "http://maps.gstatic.com/mapfiles/ms2/micons/red-pushpin.png" },
                new LocationType { LocationTypeId = 3, TypeName = "Grocery Store", IconPath = "http://maps.gstatic.com/mapfiles/ms2/micons/grocerystore.png" },
                new LocationType { LocationTypeId = 4, TypeName = "Park", IconPath = "http://maps.gstatic.com/mapfiles/ms2/micons/picnic.png" },
                new LocationType { LocationTypeId = 5, TypeName = "Museum", IconPath = "http://maps.gstatic.com/mapfiles/ms2/micons/homegardenbusiness.png" },
                new LocationType { LocationTypeId = 6, TypeName = "Hospital", IconPath = "http://maps.gstatic.com/mapfiles/ms2/micons/helicopter.png" },
                new LocationType { LocationTypeId = 7, TypeName = "Bookstore", IconPath = "http://maps.gstatic.com/mapfiles/ms2/micons/purple-pushpin.png" }
                };

                context.LocationTypes.AddRange(locationTypes);
                context.SaveChanges();
            }

            if (!context.Locations.Any())
            {
                var locations = new Location[]
                {
                new Location { LocationId = 1, Name = "Bestes Café", Latitude = 52.520008M, Longitude = 13.404954M, LocationTypeId = 1 },
                new Location { LocationId = 2, Name = "Stadtbibliothek", Latitude = 52.516041M, Longitude = 13.378727M, LocationTypeId = 2 },
                new Location { LocationId = 3, Name = "Grocery Store", Latitude = 52.523405M, Longitude = 13.411399M, LocationTypeId = 3 },
                new Location { LocationId = 4, Name = "Park", Latitude = 52.517036M, Longitude = 13.388860M, LocationTypeId = 4 },
                new Location { LocationId = 5, Name = "Museum", Latitude = 52.520645M, Longitude = 13.387412M, LocationTypeId = 5 },
                new Location { LocationId = 6, Name = "Hospital", Latitude = 52.523292M, Longitude = 13.394440M, LocationTypeId = 6 },
                new Location { LocationId = 7, Name = "Bookstore", Latitude = 52.521384M, Longitude = 13.409605M, LocationTypeId = 7 }
                };

                context.Locations.AddRange(locations);
                context.SaveChanges();
            }

            if (!context.Attributes.Any())
            {                
                var attributes = new Models.Attribute[]
                {
                new Attribute { AttributeId = 1, LocationTypeId = 1, Name = "WLAN", Value = "Ja" },
                new Attribute { AttributeId = 2, LocationTypeId = 2, Name = "Öffnungszeiten", Value = "08:00 - 19:00" },
                new Attribute { AttributeId = 3, LocationTypeId = 3, Name = "Delivery", Value = "Yes" },
                new Attribute { AttributeId = 4, LocationTypeId = 4, Name = "Playground", Value = "Yes" },
                new Attribute { AttributeId = 5, LocationTypeId = 5, Name = "Guided Tours", Value = "Available on request" },
                new Attribute { AttributeId = 6, LocationTypeId = 6, Name = "Emergency Room", Value = "24/7" },
                new Attribute { AttributeId = 7, LocationTypeId = 7, Name = "Coffee Shop", Value = "Yes" }
                };

                context.Attributes.AddRange(attributes);
                context.SaveChanges();
            }

            if (!context.Reviews.Any())
            {
                var reviews = new Review[]
                {
                new Review { ReviewId = 1, LocationId = 1, UserId = 1, Rating = 5, Comment = "Toller Ort zum Entspannen!" },
                new Review { ReviewId = 2, LocationId = 2, UserId = 2, Rating = 4, Comment = "Sehr ruhige und angenehme Atmosphäre." },
                new Review { ReviewId = 3, LocationId = 3, UserId = 3, Rating = 4, Comment = "Great selection and friendly staff." },
                new Review { ReviewId = 4, LocationId = 4, UserId = 4, Rating = 5, Comment = "Beautiful park with lots of greenery." },
                new Review { ReviewId = 5, LocationId = 5, UserId = 5, Rating = 3, Comment = "Interesting exhibits but could use more interactive displays." },
                new Review { ReviewId = 6, LocationId = 6, UserId = 6, Rating = 5, Comment = "Excellent medical care and attentive staff." },
                new Review { ReviewId = 7, LocationId = 7, UserId = 7, Rating = 4, Comment = "Cozy bookstore with a nice selection of books." }
                };

                context.Reviews.AddRange(reviews);
                context.SaveChanges();
            }
        }
    }

}
