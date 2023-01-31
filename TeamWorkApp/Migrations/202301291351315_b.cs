namespace TeamWorkApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TeamMemberTasks", newName: "TeamMemberTask");
            RenameColumn(table: "dbo.TeamMemberTask", name: "TeamMember_TeamMemberID", newName: "TaskRefId");
            RenameColumn(table: "dbo.TeamMemberTask", name: "Task_TaskID", newName: "TeamMemberRefId");
            RenameIndex(table: "dbo.TeamMemberTask", name: "IX_Task_TaskID", newName: "IX_TeamMemberRefId");
            RenameIndex(table: "dbo.TeamMemberTask", name: "IX_TeamMember_TeamMemberID", newName: "IX_TaskRefId");
            DropPrimaryKey("dbo.TeamMemberTask");
            AddPrimaryKey("dbo.TeamMemberTask", new[] { "TeamMemberRefId", "TaskRefId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.TeamMemberTask");
            AddPrimaryKey("dbo.TeamMemberTask", new[] { "TeamMember_TeamMemberID", "Task_TaskID" });
            RenameIndex(table: "dbo.TeamMemberTask", name: "IX_TaskRefId", newName: "IX_TeamMember_TeamMemberID");
            RenameIndex(table: "dbo.TeamMemberTask", name: "IX_TeamMemberRefId", newName: "IX_Task_TaskID");
            RenameColumn(table: "dbo.TeamMemberTask", name: "TeamMemberRefId", newName: "Task_TaskID");
            RenameColumn(table: "dbo.TeamMemberTask", name: "TaskRefId", newName: "TeamMember_TeamMemberID");
            RenameTable(name: "dbo.TeamMemberTask", newName: "TeamMemberTasks");
        }
    }
}
