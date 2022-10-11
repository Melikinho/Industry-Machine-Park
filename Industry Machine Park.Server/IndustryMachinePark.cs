using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Industry_Machine_Park.Server.Entities;
using System.Linq;
using Microsoft.WindowsAzure.Storage.Table;
using Industry_Machine_Park.Server.Extensions;
using Industry_Machine_Park.Shared;

namespace Industry_Machine_Park.Server
{
    public static class IndustryMachinePark
    {
        [FunctionName("Get Device")]
        public static async Task<IActionResult> Get(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [Table("items", Connection = "AzureWebJobsStorage")] CloudTable itemTable,
            ILogger log)
        {
            log.LogInformation("Device");

            var query = new TableQuery<DeviceTableEntity>();
            var result = await itemTable.ExecuteQuerySegmentedAsync(query, null);

            var response = result.Select(Mapper.ToDevice).ToList();
            return new OkObjectResult(response);
        }

        [FunctionName("Delete Device")]
        public static async Task<IActionResult> Delete(
            [HttpTrigger(AuthorizationLevel.Anonymous, "Delete", Route = "IndustriMachinePark/{id}")] HttpRequest req,
            [Table("Items","Machine", "{id}", Connection = "AzureWebJobsStorage")] DeviceTableEntity deviceTableToDelete,
            [Table("Items", Connection = "AzureWebJobsStorage")] CloudTable itemTable,
            ILogger log, string Id)
        {
            log.LogInformation("Delete Device");

            var operation = TableOperation.Delete(deviceTableToDelete);
            await itemTable.ExecuteAsync(operation);
            return new NoContentResult();
        }

        [FunctionName("CreateDevice")]
        public static async Task<IActionResult> Create(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "IndustryMachinePark")] HttpRequest req,
            [Table("Items", Connection = "AzureWebJobsStorage")] CloudTable itemTable,
            ILogger log)
        {
            log.LogInformation("Create Device");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var CreateDevice = JsonConvert.DeserializeObject<DeviceTableEntity>(requestBody);

            var device = new Device
            {
                Name = CreateDevice.Name,
                Type = CreateDevice.Type,
                IsActive = CreateDevice.IsActive,
                Location = CreateDevice.Location,
                StartDate = CreateDevice.StartDate,
                EndDate = CreateDevice.EndDate,
            };

            var operation = TableOperation.Insert(device.ToTableEntity());
            await itemTable.ExecuteAsync(operation);
            return new NoContentResult();   
        }
    }
}
