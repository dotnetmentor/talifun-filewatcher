using System;

namespace Talifun.FileWatcher
{
    public interface IEnhancedFileSystemWatcher : IDisposable
    {
        /// <summary>
        /// Start listening for file/folder events
        /// </summary>
        void Start();

        /// <summary>
        /// Stop listening for file/folder events
        /// </summary>
        void Stop();

        /// <summary>
        /// Is it listening for file/folder events
        /// </summary>
        bool IsRunning
        {
            get;
        }

        /// <summary>
        /// The folder to watch for file events.
        /// </summary>
        string FolderToWatch
        {
            get;
        }

        /// <summary>
        /// The wildcard filter to use for files. E.g. *.txt
        /// </summary>
        string IncludeFilter
        {
            get;
        }

        /// <summary>
        /// The wildcard filter to use to exclude files from matches. E.g. important.txt
        /// </summary>
        /// <remarks>Just to make excluding files a little easier. Writing it all in the include filter can be difficult.</remarks>
        string ExcludeFilter
        {
            get;
        }

        /// <summary>
        /// The amount of time to wait without file activity before assuming that changes are complete.
        /// </summary>
        int PollTime
        {
            get;
        }

        /// <summary>
        /// Should subdirectories be watches as well.
        /// </summary>
        bool IncludeSubdirectories
        {
            get;
        }

        /// <summary>
        /// A user state supplied by the client. Most common use is for assigning an id.
        /// </summary>
        object UserState
        {
            get;
            set;
        }

        /// <summary>
        /// This event occurs every time a file is changed.
        /// </summary>
        event FileChangedEventHandler FileChangedEvent;

        /// <summary>
        /// This event occurs when a file is created.
        /// </summary>
        event FileCreatedEventHandler FileCreatedEvent;

        /// <summary>
        /// This event occurs when a file is deleted.
        /// </summary>
        event FileDeletedEventHandler FileDeletedEvent;

        /// <summary>
        /// This event occures when a file is renamed.
        /// </summary>
        event FileRenamedEventHandler FileRenamedEvent;


        /// <summary>
        /// This event occurs when a directory is created.
        /// </summary>
        event DirectoryCreatedEventHandler DirectoryCreatedEvent;

        /// <summary>
        /// This event occurs when a directory is deleted.
        /// </summary>
        event DirectoryDeletedEventHandler DirectoryDeletedEvent;

        /// <summary>
        /// This event occures when a directory is renamed.
        /// </summary>
        event DirectoryRenamedEventHandler DirectoryRenamedEvent;


        /// <summary>
        /// This event is raised when a few changes to a file have finished taking place. The polltime
        /// specifies how long to wait without activity before assuming that file changes are complete.
        /// If the file is renamed or deleted, this event will be called immediatly.
        /// </summary>
        event FileFinishedChangingEventHandler FileFinishedChangingEvent;

        /// <summary>
        /// This event is raised when a few changes to a multiple files have finished taking place. The polltime
        /// specifies how long to wait without activity before assuming that file changes to all files are complete.
        /// </summary>
        /// <remarks>Use this to listen for batch updates to files.</remarks>
        event FilesFinishedChangingEventHandler FilesFinishedChangingEvent;

        /// <summary>
        /// This event is raised when changes to a multiple files and files in the directory have finished taking place. 
        /// The polltime specifies how long to wait without activity before assuming that file changes to all files are complete.
        /// </summary>
        /// <remarks>Use this to wait for all file events to finish. It is recommended to switch off the file watcher while 
        /// processing events</remarks>
        event FileActivityFinishedEventHandler FileActivityFinishedEvent;
    }
}
