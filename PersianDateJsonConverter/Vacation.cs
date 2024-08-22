using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersianDateJsonConverter
{
    internal class Vacation
    {
        public int PersonnelId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Vacation(int personnelId, string name, int Age, DateTime startDate, DateTime EndDate)
        {
            this.PersonnelId = personnelId;
            this.Name = name;
            this.Age = Age;
            this.StartDate = startDate;
            this.EndDate = EndDate;
        }

        public override string ToString()
        {
            return $"PersonnelId: {PersonnelId}\n" +
               $"Name: {Name}\n" +
               $"Age: {Age}\n" +
               $"StartDate: {StartDate:yyyy/MM/dd}\n" +
               $"EndDate: {EndDate:yyyy/MM/dd}";
        }
    }
}
