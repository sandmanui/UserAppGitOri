using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserApplication.WebApi.Domain
{
    public class Address
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public Geo Geo { get; set; }
    }
}
