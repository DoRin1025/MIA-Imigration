namespace MIA_Immigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Requests", "ToDo5");
            DropColumn("dbo.Requests", "ToDo6");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requests", "ToDo6", c => c.String(nullable: false));
            AddColumn("dbo.Requests", "ToDo5", c => c.String(nullable: false));
        }
    }
}
