using System.Data.Entity;

namespace ClassActivity.Models
    {
    //The DbContext class has a method called OnModelCreating that takes an instance of ModelBuilder as a parameter.
    //This method is called by the framework when your context is first created to build the model and its mappings in memory.
    public class ListDbContext : DbContext
        {
        //A DbContext instance represents a session with the database and can be used to query and save instances of your entities
        public DbSet<List> Lists { get; set; } //Table 1
        public DbSet<ListItemType> ListItemTypes { get; set; } //Table 2
        public DbSet<NewModel> NewModels { get; set; } //Table 3

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<ListItemType>()
                .HasMany(zz => zz.Lists)
                .WithOptional(zz => zz.ListItemType)
                .HasForeignKey(zz => zz.ListItemTypeID)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NewModel>()
                .HasMany(zz => zz.Lists)
                .WithOptional(zz => zz.NewModel)
                .HasForeignKey(zz => zz.NewModelId)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }

    }
    }