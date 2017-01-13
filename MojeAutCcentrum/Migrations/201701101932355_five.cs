namespace MojeAutCcentrum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class five : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Avatars", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.RatingCars", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Avatars", new[] { "User_Id" });
            DropIndex("dbo.RatingCars", new[] { "User_Id" });
            AddColumn("dbo.Avatars", "UserId", c => c.String());
            AddColumn("dbo.RatingCars", "UserId", c => c.String());
            DropColumn("dbo.Avatars", "User_Id");
            DropColumn("dbo.RatingCars", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RatingCars", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Avatars", "User_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.RatingCars", "UserId");
            DropColumn("dbo.Avatars", "UserId");
            CreateIndex("dbo.RatingCars", "User_Id");
            CreateIndex("dbo.Avatars", "User_Id");
            AddForeignKey("dbo.RatingCars", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Avatars", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
