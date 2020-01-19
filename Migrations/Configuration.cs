namespace Test3_Bank.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Test3_Bank.Model;


    internal sealed class Configuration : DbMigrationsConfiguration<Test3_Bank.Model.UserDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

         

        protected override void Seed(Test3_Bank.Model.UserDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Users.RemoveRange(context.Users);
            context.Accounts.RemoveRange(context.Accounts);

            List<User> users = new List<User>
            {
                new User()
                {
                    Name = "admin",
                    Password = "1234",
                    Account = new Account
                    {
                        Balance = 0,
                    }
                },

                new User()
                {
                    Name = "Test",
                    Password = "1111",
                    Account = new Account
                    {
                        Balance = 1110,
                    }
                }
            };

            context.Users.AddRange(users);
            base.Seed(context);

        }
    }
}
