namespace AuthApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdditionalFieldsToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsBlocked", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "LastVisited", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "LastVisited");
            DropColumn("dbo.AspNetUsers", "IsBlocked");
        }
    }
}
