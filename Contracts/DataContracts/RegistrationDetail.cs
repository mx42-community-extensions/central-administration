using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralAdministration.Contracts.DataContracts
{
    public class RegistrationDetail
    {
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string CompanyName { get; set; }
        public string ContactPhone { get; set; }
        public string M42CustomerNumber { get; set; }
    }
}
