using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakWcfService.Air.Models
{
    public class Booking
    {
        public Booking()
        { }

        public Booking(string Code, string Name)
        {
            this.Code = Code;
            this.Name = Name;
        }

        public string Code;
        public string Name;
    }
}
