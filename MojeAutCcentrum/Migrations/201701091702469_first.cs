namespace MojeAutCcentrum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bodies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Generation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Generations", t => t.Generation_Id)
                .Index(t => t.Generation_Id);
            
            CreateTable(
                "dbo.Motors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Body_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bodies", t => t.Body_Id)
                .Index(t => t.Body_Id);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Brand_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.Brand_Id)
                .Index(t => t.Brand_Id);
            
            CreateTable(
                "dbo.Generations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Model_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Models", t => t.Model_Id)
                .Index(t => t.Model_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Models", "Brand_Id", "dbo.Brands");
            DropForeignKey("dbo.Generations", "Model_Id", "dbo.Models");
            DropForeignKey("dbo.Bodies", "Generation_Id", "dbo.Generations");
            DropForeignKey("dbo.Motors", "Body_Id", "dbo.Bodies");
            DropIndex("dbo.Generations", new[] { "Model_Id" });
            DropIndex("dbo.Models", new[] { "Brand_Id" });
            DropIndex("dbo.Motors", new[] { "Body_Id" });
            DropIndex("dbo.Bodies", new[] { "Generation_Id" });
            DropTable("dbo.Generations");
            DropTable("dbo.Models");
            DropTable("dbo.Brands");
            DropTable("dbo.Motors");
            DropTable("dbo.Bodies");
        }
    }
}
