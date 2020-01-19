using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBDemo
{
    public class Conference
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public string ContactNum { get; set; }
        public DateTime ConfDate { get; set; }

        public string AllData
        {
            get
            {
                return string.Format($"{Id}, {Name},{ContactNum},{ConfDate}");
            }
            set
            {
                //string command seperated and set the fields of the visitor
                string[] allData = value.Split(',');
                try
                {
                    Id   = int.Parse(allData[0]);
                    Name = allData[1];
                    ContactNum = allData[2];
                    ConfDate = DateTime.Parse(allData[3]);
                }
                catch (Exception ex)
                {
                    throw new Exception("All Data Property value not valid " + ex.Message);
                }
            }
        }

        public override string ToString()
        {
            return string.Format($"{Id.ToString()} | {Name}| {ContactNum} | {ConfDate.ToShortDateString()}");
        }
    }
}
