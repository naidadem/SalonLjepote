using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHairdresserSalon_PCL.Model
{
    public class Usluge
    {
        public int UslugaID { get; set; }

        public string NazivUsluge { get; set; }

        public int TrajanjeMinute { get; set; }

        public decimal CijenaUsluge { get; set; }

        public int VrstaUslugeID { get; set; }
    }
}