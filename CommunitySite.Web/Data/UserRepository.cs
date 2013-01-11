using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.Table.DataServices;

namespace CommunitySite.Web.Data
{
    public class EventRepository
    {
        public CloudTableClient ConnectTableStorage()
        {
            var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("CommunitySite.StorageConnectionString"));


            var tableClient = storageAccount.CreateCloudTableClient();

            var table = tableClient.GetTableReference("Events");
            table.CreateIfNotExists();

            return tableClient;
        }

        public IEnumerable<Event> GetAll(Func<Event, bool> expression)
        {
            var tableClient = ConnectTableStorage();
            using (var tableServiceContext = new TableServiceContext(tableClient))
            {
                return tableServiceContext.CreateQuery<Event>("Events")
                                        .Where(x => x.PartitionKey.Equals("dotnetkk"))
                                        .Where(expression);
            }
        }


        public Event GetNextEvent()
        {
            var tableClient = ConnectTableStorage();
            using (var tableServiceContext = new TableServiceContext(tableClient))
            {
                return tableServiceContext.CreateQuery<Event>("Events")
                                          .Where(x => x.PartitionKey.Equals("dotnetkk"))
                                          .Where(x => x.FromDate >= DateTime.Now)
                                          .ToList()
                                          .OrderBy(x => x.FromDate)
                                          .FirstOrDefault();
            }
            return new Event();
        }
    }

    public class Event : TableEntity
    {
        public string Title { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string Teaser { get; set; }
    }
}