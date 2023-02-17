namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryType = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        FeedbackId = c.Int(nullable: false, identity: true),
                        RecipeId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Ratings = c.Int(nullable: false),
                        ReviewText = c.String(),
                    })
                .PrimaryKey(t => t.FeedbackId)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RecipeId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        RecipeId = c.Int(nullable: false, identity: true),
                        RecipeName = c.String(nullable: false, maxLength: 50),
                        CategoryId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                        IngredientId = c.Int(nullable: false),
                        QuantityId = c.Int(nullable: false),
                        MeasurmentId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        RecipeDescription = c.String(),
                    })
                .PrimaryKey(t => t.RecipeId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: false)
                .ForeignKey("dbo.Ingredients", t => t.IngredientId, cascadeDelete: false)
                .ForeignKey("dbo.Measurments", t => t.MeasurmentId, cascadeDelete: false)
                .ForeignKey("dbo.Quantities", t => t.QuantityId, cascadeDelete: false)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.Id, cascadeDelete: false)
                .Index(t => t.CategoryId)
                .Index(t => t.StateId)
                .Index(t => t.IngredientId)
                .Index(t => t.QuantityId)
                .Index(t => t.MeasurmentId)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        IngredientId = c.Int(nullable: false, identity: true),
                        IngredientName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IngredientId);
            
            CreateTable(
                "dbo.Measurments",
                c => new
                    {
                        MeasurmentId = c.Int(nullable: false, identity: true),
                        MeasurmentName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.MeasurmentId);
            
            CreateTable(
                "dbo.Quantities",
                c => new
                    {
                        QuantityId = c.Int(nullable: false, identity: true),
                        IngredientId = c.Int(nullable: false),
                        MeasurmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuantityId)
                .ForeignKey("dbo.Measurments", t => t.MeasurmentId, cascadeDelete: true)
                .Index(t => t.MeasurmentId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        StateName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.StateId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 10),
                        LastName = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false, maxLength: 50),
                        MobileNo = c.String(maxLength: 10),
                        Gender = c.String(nullable: false, maxLength: 10),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RollName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId_RoleId = c.Int(),
                        UserId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId_RoleId)
                .ForeignKey("dbo.Users", t => t.UserId_Id)
                .Index(t => t.RoleId_RoleId)
                .Index(t => t.UserId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "UserId_Id", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId_RoleId", "dbo.Roles");
            DropForeignKey("dbo.Feedbacks", "UserId", "dbo.Users");
            DropForeignKey("dbo.Recipes", "Id", "dbo.Users");
            DropForeignKey("dbo.Recipes", "StateId", "dbo.States");
            DropForeignKey("dbo.Recipes", "QuantityId", "dbo.Quantities");
            DropForeignKey("dbo.Quantities", "MeasurmentId", "dbo.Measurments");
            DropForeignKey("dbo.Recipes", "MeasurmentId", "dbo.Measurments");
            DropForeignKey("dbo.Recipes", "IngredientId", "dbo.Ingredients");
            DropForeignKey("dbo.Feedbacks", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.Recipes", "CategoryId", "dbo.Categories");
            DropIndex("dbo.UserRoles", new[] { "UserId_Id" });
            DropIndex("dbo.UserRoles", new[] { "RoleId_RoleId" });
            DropIndex("dbo.Quantities", new[] { "MeasurmentId" });
            DropIndex("dbo.Recipes", new[] { "Id" });
            DropIndex("dbo.Recipes", new[] { "MeasurmentId" });
            DropIndex("dbo.Recipes", new[] { "QuantityId" });
            DropIndex("dbo.Recipes", new[] { "IngredientId" });
            DropIndex("dbo.Recipes", new[] { "StateId" });
            DropIndex("dbo.Recipes", new[] { "CategoryId" });
            DropIndex("dbo.Feedbacks", new[] { "UserId" });
            DropIndex("dbo.Feedbacks", new[] { "RecipeId" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.States");
            DropTable("dbo.Quantities");
            DropTable("dbo.Measurments");
            DropTable("dbo.Ingredients");
            DropTable("dbo.Recipes");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Categories");
        }
    }
}
