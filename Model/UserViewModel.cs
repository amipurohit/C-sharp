using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3_Bank.Model
{
    public class UserViewModel
    {
        UserDBContext context = new UserDBContext();
        public  const string TRANSACTION_TYPE_DEPOSIT = "Deposite";
        public  const string TRANSACTION_TYPE_WITHDRAW = "Withdraw";

        //Get All Users from User table 
        public List<User>   GetAllUsers()
        {
            return context.Users.ToList();
        }

        //Get all users  with account information
        public List<User> GetAllUsersData()
        {
            return context.Users.Include("Account").ToList();
        }

        //check user exist by id and password 
        public bool CheckUserExistByIdAndPassword(int _id, string _password)
        {
            int count = (from u in context.Users
                         where u.ID == _id && u.Password == _password
                        select u).Count();
            return  (count >0) ?  true : false;
        }

        // Get user data and return user Object
        public User GetUserByIdAndPassword(int _id, string _password)
        {
            var user = (from u in context.Users.Include("Account")
                        where u.ID == _id && u.Password == _password
                        select u) .SingleOrDefault();
            return user;
        }


        // update User balance to data base
        public void UpdateUserBalance(User _oldUser , string transType, double _amount)
        {
            // save old balance  
            double oldBalance = _oldUser.Account.Balance;

            //deposit add amount from balance
            if (transType == TRANSACTION_TYPE_DEPOSIT)
            {
                _oldUser.Account.Balance += _amount;

            // remove amount from balance
            } else if (transType == TRANSACTION_TYPE_WITHDRAW)
            {
                _oldUser.Account.Balance -= _amount;
            }

            // find record in DbContext
            User CurrentUser = (from u in context.Users
                                where u.ID == _oldUser.ID && u.Account.Id == _oldUser.Account.Id
                                select u).SingleOrDefault();
            // setup current record
            CurrentUser.ID = _oldUser.ID;
            //CurrentUser.Name = _oldUser.Name;
            //CurrentUser.Password = _oldUser.Password;
             //CurrentUser.Account = _oldUser.Account;
            //CurrentUser.UserAccount.Id = _oldUser.UserAccount.Id;
            CurrentUser.Account.Balance = _oldUser.Account.Balance;

            // save to database
            context.SaveChanges();

            // save log information
            SaveDataToLogFile( CurrentUser.Account.Id,
                               transType,
                               oldBalance,
                               CurrentUser.Account.Balance);
        }


        // save changes to log file
        public void SaveDataToLogFile(int accountNumber,
                                      String transType,
                                      double oldBalance,
                                      double newBalance)
        {
            StringBuilder record = new StringBuilder();

            record.Append("  ");
            record.Append(DateTime.Now.ToString());
            record.Append($" # {accountNumber.ToString()}");
            record.Append(" | " + transType + " |");
            record.Append( oldBalance.ToString("C") + " |");
            record.Append( newBalance.ToString("C") );
            record.AppendLine();
            try
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                currentDirectory += "/Log";
               
                if (!Directory.Exists(currentDirectory))
                    Directory.CreateDirectory(currentDirectory);

                String file = currentDirectory + "/LogFile.txt";

                File.AppendAllText(file, record.ToString());
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
               
            }
        }


        //Delete Employee Record
        public void DeleteUserRecord(int ID)
        {
            //Retrive User DBContext Object  
            User toBeDeleted = (from u in context.Users.Include("Account")
                                where u.ID == ID
                                select u).SingleOrDefault();
            // Retrive Account DBContext Object  
            Account AccountToBeDelete = (from acct in context.Accounts
                                         where acct.Id == toBeDeleted.Account.Id
                                         select acct).SingleOrDefault();

            // Delete account record 
            context.Accounts.Remove(AccountToBeDelete);

            // Delete User record
            context.Users.Remove(toBeDeleted);
            context.SaveChanges();
        }


        public void AddNewUser(User newUser)
        {
            context.Users.Add(newUser);
            context.SaveChanges();
        }


        // update User balance to data base
        public void UpdateUser(User _oldUser)
        {
       
            // find record in DbContext
            User CurrentUser = (from u in context.Users
                                where u.ID == _oldUser.ID && u.Account.Id == _oldUser.Account.Id
                                select u).SingleOrDefault();
            // setup current record
            //CurrentUser.ID = _oldUser.ID;
            CurrentUser.Name = _oldUser.Name;
            CurrentUser.Password = _oldUser.Password;
            //CurrentUser.Account = _oldUser.Account;
            //CurrentUser.Account.Balance = _oldUser.Account.Balance;

            // save to database
            context.SaveChanges();
        }
    }
}
