using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakWcfService.Air.Models
{
    public class Airport
    {
        public Airport()
        { }

        public Airport(string Code, string Name, string CountryCode)
        {
            this.Code = Code;
            this.Name = Name;
            this.CountryCode = CountryCode;
            this.IsCity = false;
        }

        public Airport(string Code, string Name, string CountryCode, bool IsCity)
        {
            this.Code = Code;
            this.Name = Name;
            this.CountryCode = CountryCode;
            this.IsCity = IsCity;
        }

        public string Code;
        public string Name;
        public string CountryCode;
        public bool IsCity;

        public override string ToString()
        {
            return string.Format("{0}/{1}", this.Code, this.Name);
        }
    }
}