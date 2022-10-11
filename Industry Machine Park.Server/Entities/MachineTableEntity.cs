using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Industry_Machine_Park.Server.Entities
{
    public class MachineTableEntity : TableEntity
    {
        public string Name { get; set; } = String.Empty;
        public string Type { get; set; } = String.Empty;
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime EndDate { get; set; } = DateTime.UtcNow.AddDays(Random.Shared.Next(50));
        public string Location { get; set; } = String.Empty;
        public bool IsActive { get; set; } = false;
    }
}

