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
        public static DeviceTableEntity ToTableEntity(this Device device)
        {
            return new DeviceTableEntity
            {
                PartitionKey = "Machine",
                RowKey = device.Id,
                Name = device.Name,
                Type = device.Type,
                Location = device.Location,
                IsActive = device.IsActive,
            };
        }

        public static Device ToDevice(this DeviceTableEntity deviceTableEntity)
        {
            return new Device
            {
                Id = deviceTableEntity.RowKey,
                IsActive = deviceTableEntity.IsActive,
                StartDate = deviceTableEntity.StartDate,
                EndDate = deviceTableEntity.EndDate,
                Location = deviceTableEntity.Location,
                Type = deviceTableEntity.Type
            };
        }
    }
}
