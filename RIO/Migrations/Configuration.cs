namespace RIO.Migrations
{
    using RIO.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RIO.Models.RIOContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(RIO.Models.RIOContext context)
        {
            //  This method will be called after migrating to the latest version.            
            context.Category.AddOrUpdate(
                      p => p.CategoryName,
                      new Category { CategoryName = "Electronics", SortOrder = 0, HierarchyLevel = 0, IsActive = true },
                      new Category { CategoryName = "Camera", SortOrder = 0, HierarchyLevel = 0, IsActive = true },
                      new Category { CategoryName = "Sports", SortOrder = 0, HierarchyLevel = 0, IsActive = true }
                    );

            context.Brand.AddOrUpdate(
                     p => p.BrandName,
                     new Brand { BrandName = "Bose", SortOrder = 0, IsActive = true },
                     new Brand { BrandName = "Canon", SortOrder = 0, IsActive = true },
                     new Brand { BrandName = "Yonex", SortOrder = 0, IsActive = true }
                   );

            context.Country.AddOrUpdate(
                    p => p.CountryName,
                    new Country { CountryName = "India", IsActive = true },
                    new Country { CountryName = "USA", IsActive = true },
                    new Country { CountryName = "UK", IsActive = true }
                  );
            context.SaveChanges();

            context.State.AddOrUpdate(
                   p => p.StateName,
                   new State { CountryId = context.Country.FirstOrDefault(p => p.CountryName == "India").CountryId, StateName = "Kerala", IsActive = true },
                   new State { CountryId = context.Country.FirstOrDefault(p => p.CountryName == "India").CountryId, StateName = "Tamilnadu", IsActive = true },
                   new State { CountryId = context.Country.FirstOrDefault(p => p.CountryName == "India").CountryId, StateName = "Karnataka", IsActive = true }
                 );
            context.SaveChanges();

            context.City.AddOrUpdate(
                  p => p.CityName,
                  new City { StateId = context.State.FirstOrDefault(p => p.StateName == "Kerala").StateId, CityName = "Kochi", IsActive = true },
                  new City { StateId = context.State.FirstOrDefault(p => p.StateName == "Tamilnadu").StateId, CityName = "Chennai", IsActive = true },
                  new City { StateId = context.State.FirstOrDefault(p => p.StateName == "Karnataka").StateId, CityName = "Bangalore", IsActive = true }
                );
            context.SaveChanges();

            context.User.AddOrUpdate(
                     p => p.UserName,
                     new User
                     {
                         UserName = "TestUser1",
                         FirstName = "Test",
                         LastName = "User",
                         EmailId = "test@test.com",
                         DateOfBirth = DateTime.Now.AddYears(-40),
                         Phone = 123456789,
                         IsActive = true
                     });
            context.SaveChanges();

            context.Address.AddOrUpdate(
                      p => p.AddressLine1,
                      new Address
                      {
                          CountryId = context.Country.FirstOrDefault(p => p.CountryName == "India").CountryId,
                          StateId = context.State.FirstOrDefault(p => p.StateName == "Kerala").StateId,
                          CityId = context.City.FirstOrDefault(p => p.CityName == "Kochi").CityId,
                          UserId = context.User.FirstOrDefault().UserId,
                          AddressLine1 = "AddressLine1",
                          AddressLine2 = "AddressLine2",
                          PinCode = 682030,
                          IsDefault = true,
                          IsActive = true
                      });
            context.SaveChanges();

            context.Item.AddOrUpdate(
              p => p.ItemName,
              new Item
              {
                  CategoryId = context.Category.FirstOrDefault(p => p.CategoryName == "Electronics").CategoryId,
                  BrandId = context.Brand.FirstOrDefault(p => p.BrandName == "Bose").BrandId,
                  AddressId = context.Address.FirstOrDefault().AddressId,
                  ItemName = "5.1 Speaker System",
                  ItemDescription = "Bose Imported",
                  Phone = 123456789,
                  PostedDate = DateTime.Now,
                  IsActive = true
              },
              new Item
              {
                  CategoryId = context.Category.FirstOrDefault(p => p.CategoryName == "Camera").CategoryId,
                  BrandId = context.Brand.FirstOrDefault(p => p.BrandName == "Canon").BrandId,
                  AddressId = context.Address.FirstOrDefault().AddressId,
                  ItemName = "EOS 1000D",
                  ItemDescription = "EOS 1000D with 18-55 kit lens and 55-250 telephoto",
                  Phone = 123456789,
                  PostedDate = DateTime.Now,
                  IsActive = true
              },
               new Item
               {
                   CategoryId = context.Category.FirstOrDefault(p => p.CategoryName == "Sports").CategoryId,
                   BrandId = context.Brand.FirstOrDefault(p => p.BrandName == "Yonex").BrandId,
                   AddressId = context.Address.FirstOrDefault().AddressId,
                   ItemName = "Voltric 7",
                   ItemDescription = "Racket",
                   Phone = 123456789,
                   PostedDate = DateTime.Now,
                   IsActive = true
               });

            context.SaveChanges();

        }
    }
}
