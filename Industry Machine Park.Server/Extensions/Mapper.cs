using Industry_Machine_Park.Server.Entities;
using Industry_Machine_Park.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Industry_Machine_Park.Server.Extensions
{
    public static class Mapper
    {
        public static MachineTableEntity ToTableEntity(this Device device)
        {
            return new MachineTableEntity
            {
                Name = device.Name,
                Type = device.Type,
                Location = device.Location,
                IsActive = device.IsActive,


            };
        }

        public static Device ToDevice(this MachineTableEntity machineTableEntity)
        {
            return new Device
            {
                Id = machineTableEntity.RowKey,
                IsActive = machineTableEntity.IsActive,
                StartDate = machineTableEntity.StartDate,
                EndDate = machineTableEntity.EndDate,
                Location = machineTableEntity.Location,
                Type = machineTableEntity.Type
            };
        }
    }
}
