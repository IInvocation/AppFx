using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using LiteDB;
using Microsoft.Win32;
using System;

namespace FluiTec.AppFx.Data.LiteDb.Editor.ViewModel
{
    /// <summary>   A ViewModel for the MainView. </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
#if DEBUG
            if (!System.IO.File.Exists("test.db"))
            {
                using (var db = new LiteDatabase("test.db"))
                {
                    var collection1 = db.GetCollection<Test>();
                    collection1.Insert(new Test
                    {
                        Id = 1,
                        DateTime = DateTime.Now,
                        Guid = Guid.NewGuid(),
                        Long = 50,
                        String = "Test"
                    });

                    var collection2 = db.GetCollection<Test2>();
                    collection2.Insert(new Test2
                    {
                        Id = 1,
                        DateTime = DateTime.Now,
                        Guid = Guid.NewGuid(),
                        Long = 50,
                        String = "Test"
                    });
                }
            }
#endif
            OpenCommand = new RelayCommand(OpenFile);

            CloseCommand = new RelayCommand(() =>
            {
                ActiveDbFile = null;
            });
        }

        private void OpenFile()
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                ActiveDbFile = dialog.FileName;
            }
        }

        private string _activeDbFile;

        /// <summary>   Gets or sets the active database file. </summary>
        /// <value> The active database file. </value>
        public string ActiveDbFile
        {
            get { return _activeDbFile; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || System.IO.File.Exists(value))
                {
                    Set(ref _activeDbFile, value);
                    RaisePropertyChanged(nameof(Header));
                    if (Database != null)
                        Database.Close();
                    Database = new DatabaseViewModel(value);
                }
            }
        }

        /// <summary>   Gets or sets the header. </summary>
        /// <value> The header. </value>
        public string Header
        {
            get
            {
                if (string.IsNullOrWhiteSpace(ActiveDbFile))
                    return "LiteDb Editor";
                return $"LiteDb Editor [{new System.IO.FileInfo(ActiveDbFile).Name}]";
            }
        }

        private DatabaseViewModel _database;

        /// <summary>   Gets or sets the database. </summary>
        /// <value> The database. </value>
        public DatabaseViewModel Database
        {
            get { return _database; }
            set { Set(ref _database, value); }
        }

        /// <summary>   Gets or sets the open command. </summary>
        /// <value> The open command. </value>
        public ICommand OpenCommand { get; private set; }

        /// <summary>   Gets or sets the close command. </summary>
        /// <value> The close command. </value>
        public ICommand CloseCommand { get; private set; }

        public class Test
        {
            public int Id { get; set; }

            public Guid Guid { get; set; }

            public DateTime DateTime { get; set; }

            public string String { get; set; }

            public long Long { get; set; }
        }

        public class Test2
        {
            public int Id { get; set; }

            public Guid Guid { get; set; }

            public DateTime DateTime { get; set; }

            public string String { get; set; }

            public long Long { get; set; }
        }
    }
}