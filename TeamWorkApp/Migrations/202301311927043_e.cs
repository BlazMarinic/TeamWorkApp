namespace TeamWorkApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class e : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TeamMemberTask", newName: "TaskTeamMember");
            DropPrimaryKey("dbo.TaskTeamMember");
            AddPrimaryKey("dbo.TaskTeamMember", new[] { "TaskRefId", "TeamMemberRefId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.TaskTeamMember");
            AddPrimaryKey("dbo.TaskTeamMember", new[] { "TeamMemberRefId", "TaskRefId" });
            RenameTable(name: "dbo.TaskTeamMember", newName: "TeamMemberTask");
        }
    }
}
