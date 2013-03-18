using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;

namespace Gos.SimpleObjectStore
{
    public interface IDataProvider
    {
        ICollection<TEntity> Load<TEntity>();
        void Save<TEntity>(ICollection<TEntity> entities);
        event EventHandler<DataSourceChangedEventArgs> DataSourceChanged;
    }

    public class DataProvider : IDataProvider
    {
        private readonly object _lockObject = new object();
        private readonly string _dataPath;
        private readonly FileSystemWatcher _fileSystemWatcher;
        private readonly string _dataFileExtension;

        public event EventHandler<DataSourceChangedEventArgs> DataSourceChanged;

        public DataProvider(string dataPath)
        {
            _dataPath = dataPath;
            _dataFileExtension = ".json";
            _fileSystemWatcher = new FileSystemWatcher(_dataPath, "*" + _dataFileExtension);
            _fileSystemWatcher.Changed += (FileSystemEventHandler)((sender, eventArgs) => OnDataSourceChanged(eventArgs.Name));
            _fileSystemWatcher.EnableRaisingEvents = true;
        }

        public ICollection<TEntity> Load<TEntity>()
        {
            lock (_lockObject)
            {
                var dataFile = GetDataFile<TEntity>();
                if (!File.Exists(dataFile))
                {
                    Save(new Collection<TEntity>());
                }
                using (var fs = new FileStream(dataFile, FileMode.Open, FileAccess.Read))
                {
                    using (var sw = new StreamReader(fs))
                    {
                        var json = sw.ReadToEnd();
                        var serializeObject = JsonConvert.DeserializeObject<ICollection<TEntity>>(json);
                        return serializeObject;
                    }
                }
            }
        }

        public void Save<TEntity>(ICollection<TEntity> entities)
        {
            var dataFile = GetDataFile<TEntity>();
            lock (_lockObject)
            {
                using (var fs = new FileStream(dataFile,  FileMode.Create, FileAccess.Write))
                {
                    using (var sw = new StreamWriter(fs))
                    {
                        var serializeObject = JsonConvert.SerializeObject(entities, ObjectStore.FormatOutput ? Formatting.Indented : Formatting.None);
                        sw.Write(serializeObject);
                    }
                }
            }
        }

        private void OnDataSourceChanged(string dataFile)
        {
            if (DataSourceChanged != null)
            {
                DataSourceChanged(this, new DataSourceChangedEventArgs(dataFile.Substring(0, dataFile.Length - _dataFileExtension.Length)));
            }
        }

        private string GetDataFile<TEntity>()
        {
            lock (_lockObject)
            {
                return Path.Combine(_dataPath, typeof(TEntity).Name + _dataFileExtension);
            }
        }
    }
}