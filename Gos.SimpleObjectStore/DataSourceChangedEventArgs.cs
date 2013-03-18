using System;

namespace Gos.SimpleObjectStore
{
    public class DataSourceChangedEventArgs : EventArgs
    {

        public DataSourceChangedEventArgs(string entityType)
        {
            EntityType = entityType;
        }

        public string EntityType { get; set; }
    }
}