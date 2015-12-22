namespace IBetApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicatonDbContext : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bet", "UserFirstId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bet", "UserSecondId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bet", "WinnerUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Bet", new[] { "UserFirstId" });
            DropIndex("dbo.Bet", new[] { "UserSecondId" });
            DropIndex("dbo.Bet", new[] { "WinnerUserId" });
            DropColumn("dbo.Bet", "UserFirstId");
            DropColumn("dbo.Bet", "UserSecondId");
            DropColumn("dbo.Bet", "WinnerUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bet", "WinnerUserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Bet", "UserSecondId", c => c.String(maxLength: 128));
            AddColumn("dbo.Bet", "UserFirstId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Bet", "WinnerUserId");
            CreateIndex("dbo.Bet", "UserSecondId");
            CreateIndex("dbo.Bet", "UserFirstId");
            AddForeignKey("dbo.Bet", "WinnerUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Bet", "UserSecondId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Bet", "UserFirstId", "dbo.AspNetUsers", "Id");
        }
    }
}
