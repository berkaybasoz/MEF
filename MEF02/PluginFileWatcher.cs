using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MEF02
{
    public class PluginFileWatcher
    { 
        public event Action<object, FileSystemEventArgs> OnUpdate;
        private FileSystemWatcher watcher;
        private string directoryPath;

        public PluginFileWatcher(string directoryPath)
        {
            if (string.IsNullOrEmpty(directoryPath))
                throw new ArgumentNullException("directoryPath is null");
            this.directoryPath = directoryPath;
        }

        public void Start()
        {
            watcher = new FileSystemWatcher(directoryPath, PluginDirectoryInfo.Filter);
            watcher.Changed += watcher_Changed;
            watcher.Created += watcher_Created;
            watcher.Deleted += watcher_Deleted;
            watcher.Renamed += watcher_Renamed;
            watcher.EnableRaisingEvents = true;
        }


        private void watcher_Renamed(object sender, FileSystemEventArgs e)
        {
            FireOnUpdated(e); 
        }

        private void watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            FireOnUpdated(e); 
        }

        private void watcher_Created(object sender, FileSystemEventArgs e)
        {
            FireOnUpdated(e); 
        }

        private void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            FireOnUpdated(e); 
        }

        private void FireOnUpdated(FileSystemEventArgs e)
        {
            if (OnUpdate != null)
                OnUpdate(this, e);
        }
    }
}
