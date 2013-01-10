using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.Table.DataServices;

namespace CommunitySite.Data
{
    public class EventRepository
    {
        public CloudTableClient ConnectTableStorage()
        {
            var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));


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



    }

    public class Event : TableEntity
    {

    }
}