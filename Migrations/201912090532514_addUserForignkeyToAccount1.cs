namespace Test3_Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserForignkeyToAccount1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "UserAccount_Id", "dbo.Accounts");
            DropIndex("dbo.Users", new[] { "UserAccount_Id" });
            RenameColumn(table: "dbo.Users", name: "UserAccount_Id", newName: "AccountId");
            AlterColumn("dbo.Users", "AccountId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "AccountId");
            AddForeignKey("dbo.Users", "AccountId", "dbo.Accounts", "Account Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "AccountId", "dbo.Accounts");
            DropIndex("dbo.Users", new[] { "AccountId" });
            AlterColumn("dbo.Users", "AccountId", c => c.Int());
            RenameColumn(table: "dbo.Users", name: "AccountId", newName: "UserAccount_Id");
            CreateIndex("dbo.Users", "UserAccount_Id");
            AddForeignKey("dbo.Users", "UserAccount_Id", "dbo.Accounts", "Account Id");
        }
    }
}
