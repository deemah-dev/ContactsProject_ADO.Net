using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules
{
    public class Country
    {
        public Country()
        {

        }
        public Country(int iD)
        {
            ID = iD;
        }

        public int ID { get; }



        public string Name { get; set; }

        public string Code { get; set; }

        public string PhoneCall { get; set; }
    }
}
