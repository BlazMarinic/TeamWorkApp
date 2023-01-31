using System.Data.Entity;
using TeamWorkApp.Models;


namespace TeamWorkApp.Data
{
    public class TeamWorkAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TeamWorkAppContext() : base("name=TeamWorkAppContext")
        {
        }

        public DbSet<TeamMember> TeamMembers { get; set; }

        public DbSet<Task> Tasks { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Task>()
                .HasMany<TeamMember>(s => s.TeamMembers)
                .WithMany(c => c.Tasks)
                .Map(cs =>
                {
                    cs.MapLeftKey("TaskRefId"); 
                    cs.MapRightKey("TeamMemberRefId");
                    cs.ToTable("TaskTeamMember");
                });
        }
    }
}
