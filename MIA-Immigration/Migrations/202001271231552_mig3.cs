namespace MIA_Immigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Requests", "Country_of_Residence");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requests", "Country_of_Residence", c => c.String(nullable: false));
        }
    }
}
