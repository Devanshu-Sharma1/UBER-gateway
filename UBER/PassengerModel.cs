using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UBER
{
    public class PassengerModel
    {
        public int PassengerId { get; set; }
        public string PassengerName { get; set; }
        public string Location { get; set; }
        public string Gender  { get; set; }
        public int Phone  { get; set; }
    }
}