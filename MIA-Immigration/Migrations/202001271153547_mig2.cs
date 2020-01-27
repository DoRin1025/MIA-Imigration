namespace MIA_Immigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CountryResidences",
                c => new
                    {
                        CountryRID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CountryRID);
            
            AddColumn("dbo.Requests", "CountryRID", c => c.Int(nullable: false));
            CreateIndex("dbo.Requests", "CountryRID");
            AddForeignKey("dbo.Requests", "CountryRID", "dbo.CountryResidences", "CountryRID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "CountryRID", "dbo.CountryResidences");
            DropIndex("dbo.Requests", new[] { "CountryRID" });
            DropColumn("dbo.Requests", "CountryRID");
            DropTable("dbo.CountryResidences");
        }
    }
}
