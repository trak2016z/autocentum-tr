namespace MojeAutCcentrum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tree : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RatingCars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Body_Id = c.Int(),
                        Brand_Id = c.Int(),
                        Conveniences_Id = c.Int(),
                        Failure_Id = c.Int(),
                        Generation_Id = c.Int(),
                        Maintenance_Id = c.Int(),
                        Model_Id = c.Int(),
                        Motor_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bodies", t => t.Body_Id)
                .ForeignKey("dbo.Brands", t => t.Brand_Id)
                .ForeignKey("dbo.Ratings", t => t.Conveniences_Id)
                .ForeignKey("dbo.Ratings", t => t.Failure_Id)
                .ForeignKey("dbo.Generations", t => t.Generation_Id)
                .ForeignKey("dbo.Ratings", t => t.Maintenance_Id)
                .ForeignKey("dbo.Models", t => t.Model_Id)
                .ForeignKey("dbo.Motors", t => t.Motor_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Body_Id)
                .Index(t => t.Brand_Id)
                .Index(t => t.Conveniences_Id)
                .Index(t => t.Failure_Id)
                .Index(t => t.Generation_Id)
                .Index(t => t.Maintenance_Id)
                .Index(t => t.Model_Id)
                .Index(t => t.Motor_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Value = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RatingCars", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.RatingCars", "Motor_Id", "dbo.Motors");
            DropForeignKey("dbo.RatingCars", "Model_Id", "dbo.Models");
            DropForeignKey("dbo.RatingCars", "Maintenance_Id", "dbo.Ratings");
            DropForeignKey("dbo.RatingCars", "Generation_Id", "dbo.Generations");
            DropForeignKey("dbo.RatingCars", "Failure_Id", "dbo.Ratings");
            DropForeignKey("dbo.RatingCars", "Conveniences_Id", "dbo.Ratings");
            DropForeignKey("dbo.RatingCars", "Brand_Id", "dbo.Brands");
            DropForeignKey("dbo.RatingCars", "Body_Id", "dbo.Bodies");
            DropIndex("dbo.RatingCars", new[] { "User_Id" });
            DropIndex("dbo.RatingCars", new[] { "Motor_Id" });
            DropIndex("dbo.RatingCars", new[] { "Model_Id" });
            DropIndex("dbo.RatingCars", new[] { "Maintenance_Id" });
            DropIndex("dbo.RatingCars", new[] { "Generation_Id" });
            DropIndex("dbo.RatingCars", new[] { "Failure_Id" });
            DropIndex("dbo.RatingCars", new[] { "Conveniences_Id" });
            DropIndex("dbo.RatingCars", new[] { "Brand_Id" });
            DropIndex("dbo.RatingCars", new[] { "Body_Id" });
            DropTable("dbo.Ratings");
            DropTable("dbo.RatingCars");
        }
    }
}
