namespace MIA_Immigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Moneys",
                c => new
                    {
                        MoneyID = c.Int(nullable: false, identity: true),
                        Price = c.String(),
                    })
                .PrimaryKey(t => t.MoneyID);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        ProvinceID = c.Int(nullable: false, identity: true),
                        ProvinceName = c.String(),
                    })
                .PrimaryKey(t => t.ProvinceID);
            
            AddColumn("dbo.Requests", "ProvinceID", c => c.Int(nullable: false));
            AddColumn("dbo.Requests", "MoneyID", c => c.Int(nullable: false));
            CreateIndex("dbo.Requests", "ProvinceID");
            CreateIndex("dbo.Requests", "MoneyID");
            AddForeignKey("dbo.Requests", "MoneyID", "dbo.Moneys", "MoneyID", cascadeDelete: true);
            AddForeignKey("dbo.Requests", "ProvinceID", "dbo.Provinces", "ProvinceID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "ProvinceID", "dbo.Provinces");
            DropForeignKey("dbo.Requests", "MoneyID", "dbo.Moneys");
            DropIndex("dbo.Requests", new[] { "MoneyID" });
            DropIndex("dbo.Requests", new[] { "ProvinceID" });
            DropColumn("dbo.Requests", "MoneyID");
            DropColumn("dbo.Requests", "ProvinceID");
            DropTable("dbo.Provinces");
            DropTable("dbo.Moneys");
        }
    }
}
