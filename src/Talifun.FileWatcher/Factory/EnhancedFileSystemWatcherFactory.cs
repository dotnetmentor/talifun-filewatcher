namespace Talifun.FileWatcher
{
    public sealed class EnhancedFileSystemWatcherFactory : IEnhancedFileSystemWatcherFactory
    {
        private EnhancedFileSystemWatcherFactory()
        {
        }

        public static readonly IEnhancedFileSystemWatcherFactory Instance = new EnhancedFileSystemWatcherFactory();

        #region IEnhancedFileSystemWatcherFactory Members
        public IEnhancedFileSystemWatcher CreateEnhancedFileSystemWatcher(string folderToWatch)
        {
            return CreateEnhancedFileSystemWatcher(folderToWatch, string.Empty);
        }

        public IEnhancedFileSystemWatcher CreateEnhancedFileSystemWatcher(string folderToWatch, string filter)
        {
            return CreateEnhancedFileSystemWatcher(folderToWatch, filter, 2, true);
        }

        public IEnhancedFileSystemWatcher CreateEnhancedFileSystemWatcher(string folderToWatch, string filter, int pollTime, bool includeSubdirectories)
        {
            return new EnhancedFileSystemWatcher(folderToWatch, filter, pollTime, includeSubdirectories);
        }

        public IEnhancedFileSystemWatcher CreateEnhancedFileSystemWatcher(string folderToWatch, string filter, int pollTime, bool includeSubdirectories, object userState)
        {
            IEnhancedFileSystemWatcher folderMonitor = new EnhancedFileSystemWatcher(folderToWatch, filter, pollTime, includeSubdirectories)
            {
                UserState = userState
            };

            return folderMonitor;
        }
        #endregion
    }
}