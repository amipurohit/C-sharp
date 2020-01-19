namespace Test3_Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeForiegnKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "AccountId", "dbo.Accounts");
            DropIndex("dbo.Users", new[] { "AccountId" });
            RenameColumn(table: "dbo.Users", name: "AccountId", newName: "Account_Id");
            AlterColumn("dbo.Users", "Account_Id", c => c.Int());
            CreateIndex("dbo.Users", "Account_Id");
            AddForeignKey("dbo.Users", "Account_Id", "dbo.Accounts", "Account Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Account_Id", "dbo.Accounts");
            DropIndex("dbo.Users", new[] { "Account_Id" });
            AlterColumn("dbo.Users", "Account_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Users", name: "Account_Id", newName: "AccountId");
            CreateIndex("dbo.Users", "AccountId");
            AddForeignKey("dbo.Users", "AccountId", "dbo.Accounts", "Account Id", cascadeDelete: true);
        }
    }
}
