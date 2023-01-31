namespace TeamWorkApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskID = c.Int(nullable: false, identity: true),
                        TaskDescription = c.String(),
                        TaskDueDate = c.DateTime(nullable: false),
                        TaskStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskID);
            
            CreateTable(
                "dbo.TeamMembers",
                c => new
                    {
                        TeamMemberID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TeamMemberID);
            
            CreateTable(
                "dbo.TeamMemberTasks",
                c => new
                    {
                        TeamMember_TeamMemberID = c.Int(nullable: false),
                        Task_TaskID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TeamMember_TeamMemberID, t.Task_TaskID })
                .ForeignKey("dbo.TeamMembers", t => t.TeamMember_TeamMemberID, cascadeDelete: true)
                .ForeignKey("dbo.Tasks", t => t.Task_TaskID, cascadeDelete: true)
                .Index(t => t.TeamMember_TeamMemberID)
                .Index(t => t.Task_TaskID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeamMemberTasks", "Task_TaskID", "dbo.Tasks");
            DropForeignKey("dbo.TeamMemberTasks", "TeamMember_TeamMemberID", "dbo.TeamMembers");
            DropIndex("dbo.TeamMemberTasks", new[] { "Task_TaskID" });
            DropIndex("dbo.TeamMemberTasks", new[] { "TeamMember_TeamMemberID" });
            DropTable("dbo.TeamMemberTasks");
            DropTable("dbo.TeamMembers");
            DropTable("dbo.Tasks");
        }
    }
}
