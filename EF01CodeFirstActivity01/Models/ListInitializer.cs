using System.Collections.Generic;
using System.Data.Entity;

namespace ClassActivity.Models
{
    public class ListInitializer : DropCreateDatabaseIfModelChanges<ListDbContext>
    {
        protected override void Seed(ListDbContext context)
        {
            //var NewModels = new List<NewModel>
            //{
            //    new NewModel{
            //       NewModelId = 1,
            //       Description = "Hello"
            //        },
            //    new NewModel{
            //       NewModelId = 2,
            //       Description = "Wassuuuuup"
            //        },
            //};


            var Lists = new List<List>
            {
                new List{
                    ListID=1,
                    ListCode="Example 01",
                    Name="Example 01",
                    Description="Example 01",
                    ListItemTypeID=1,
                    Id=1,
                    },
                new List{
                    ListID=1,
                    ListCode="Example 02",
                    Name="Example 02",
                    Description="Example 02",
                    ListItemTypeID=2,
                    Id=2,   
                    },
                new List{
                    ListID=1,
                    ListCode="Example 03",
                    Name="Example 03",
                    Description="Example 03",
                    ListItemTypeID=2,
                    Id =3,
                    },
            };

            {
                var ListItemTypes = new List<ListItemType>
                {
                    new ListItemType{
                    ListItemTypeID=1,
                    ListItemTypeDescription="ExampleType 01"},
                    new ListItemType{
                    ListItemTypeID=2,
                    ListItemTypeDescription="ExampleType 02"}
                };

                    {
                    Lists.ForEach(xx => context.Lists.Add(xx));
                    ListItemTypes.ForEach(yy => context.ListItemTypes.Add(yy));

                    context.SaveChanges();
                    }
            }



            {
                var NewModels = new List<NewModel>
                {
                    new NewModel{
                   NewModelId = 1,
                    Description= "Hello"},

                };

                {
                    Lists.ForEach(xx => context.Lists.Add(xx));
                    NewModels.ForEach(yy => context.NewModels.Add(yy));

                    context.SaveChanges();
                }
            }
        }
    }
}