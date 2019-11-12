using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExam2
{
    public class User
    {
        private string fname;
        private string lname;
        private string tel;

        public User(string firstName, string lastName, string telephone)
        {
            fname = firstName;
            lname = lastName;
            tel = telephone;
        }

        public bool CreateUserFile()
        {

            try
            {
                string fpath = @"c:\temp\Users.txt";

                using (FileStream fileStream = new FileStream(fpath, FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fpath, true))
                    {
                        sw.Write("First name:" + fname + "Last name:" + lname + "Telephone" + tel);
                    }
                }
                return true;

            }
            catch (Exception exp)
            {
                Console.WriteLine("Message: {0}", exp.Message);
                return false;
            }


        }

        public int CountNumberOfUser()
        {
            int count = 0;

            try
            {
                string fpath = @"c:\temp\Users.txt";

                using (FileStream fileStream = new FileStream(fpath, FileMode.Create))
                {
                    using (StreamReader sr = new StreamReader(fpath))
                    {
                        String s;

                        while ((s = sr.ReadLine()) != null)
                        {
                            count++;
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("Message: {0}", exp.Message);

            }

            return count;
        }

        public void DeleteUsersFile()
        {
            string fpath = @"c:\temp\Users.txt";
            try {
                if (File.Exists(fpath))
                {
                    File.Delete(fpath);
                   
                } 
                   
            }    
                catch (Exception exp)
            {
                Console.WriteLine("Message: {0}", exp.Message);

            }

        }



    }
}
