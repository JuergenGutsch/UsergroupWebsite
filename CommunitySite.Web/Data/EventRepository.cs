using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.Table.DataServices;

namespace CommunitySite.Web.Data
{
    public class UserRepository
    {
        public CloudTableClient ConnectTableStorage()
        {
            var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("CommunitySite.StorageConnectionString"));


            var tableClient = storageAccount.CreateCloudTableClient();

            var table = tableClient.GetTableReference("Events");
            table.CreateIfNotExists();

            return tableClient;
        }

        public IEnumerable<User> GetAll(Func<User, bool> expression)
        {
            var tableClient = ConnectTableStorage();
            using (var tableServiceContext = new TableServiceContext(tableClient))
            {
                return tableServiceContext.CreateQuery<User>("Events")
                                        .Where(x => x.PartitionKey.Equals("dotnetkk"))
                                        .Where(expression);
            }
        }



    }

    public class User : TableEntity
    {

    }
}