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
        public Vacation(int personnelID, string name, int Age, DateTime startDate, DateTime EndDate)
        {
            this.PersonnelId = personnelID;
            this.Name = name;
            this.Age = Age;
            this.StartDate = startDate;
            this.EndDate = EndDate;
        }

        public Vacation() { }
    }
}
