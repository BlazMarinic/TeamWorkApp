namespace TeamWorkApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TeamMemberTask", name: "TeamMemberRefId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.TeamMemberTask", name: "TaskRefId", newName: "TeamMemberRefId");
            RenameColumn(table: "dbo.TeamMemberTask", name: "__mig_tmp__0", newName: "TaskRefId");
            RenameIndex(table: "dbo.TeamMemberTask", name: "IX_TaskRefId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.TeamMemberTask", name: "IX_TeamMemberRefId", newName: "IX_TaskRefId");
            RenameIndex(table: "dbo.TeamMemberTask", name: "__mig_tmp__0", newName: "IX_TeamMemberRefId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.TeamMemberTask", name: "IX_TeamMemberRefId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.TeamMemberTask", name: "IX_TaskRefId", newName: "IX_TeamMemberRefId");
            RenameIndex(table: "dbo.TeamMemberTask", name: "__mig_tmp__0", newName: "IX_TaskRefId");
            RenameColumn(table: "dbo.TeamMemberTask", name: "TaskRefId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.TeamMemberTask", name: "TeamMemberRefId", newName: "TaskRefId");
            RenameColumn(table: "dbo.TeamMemberTask", name: "__mig_tmp__0", newName: "TeamMemberRefId");
        }
    }
}
