using System;
using System.Collections.Generic;

namespace CentralAdministration.Contracts.DataContracts
{
    public class Extension
    {
        public Guid Id { get; set; }
        public License License { get; set; }
        public Package Package { get; set; }

    }

    public class Package
    {
        public string Version { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public DateTime? InstalledDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid UpdatedBy { get; set; }
    }
}