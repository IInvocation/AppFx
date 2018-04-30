using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace FluiTec.AppFx.UnitTesting.Helper
{
    /// <summary>
    ///     A connection string helper.
    /// </summary>
    public static class ConnectionStringHelper
    {
        /// <summary>
        ///     The root dir.
        /// </summary>
        private const string RootDir = "configuration";

        /// <summary>
        ///     Filename of the file.
        /// </summary>
        private const string FileName = "ConnectionStrings.local.json";

        /// <summary>
        ///     The connection strings.
        /// </summary>
        private static readonly List<ConnectionString> ConnectionStrings;

        /// <summary>
        ///     Default constructor.
        /// </summary>
        static ConnectionStringHelper()
        {
            // build filename for the connectionstrings-configuration-file
            var current = Directory.GetCurrentDirectory();
            var currentDirectory = new DirectoryInfo(current);
            if (currentDirectory.Parent?.Parent?.Parent?.Parent?.Parent == null) return;
            var sourceDirectory = currentDirectory.Parent.Parent.Parent.Parent.Parent;
            var configDirectory = Path.Combine(sourceDirectory?.FullName, RootDir);
            var connectionStringFileName = Path.Combine(configDirectory, FileName);

            // parse the configuration-file
            var root = JsonConvert.DeserializeObject<Root>(File.ReadAllText(connectionStringFileName));

            // fill internal list of connectionstrings
            ConnectionStrings = root.ConnectionStrings.ToList();
        }

        /// <summary>
        ///     Gets connection string for the given database-name.
        /// </summary>
        /// <param name="databaseName"> Name of the database. </param>
        /// <returns>
        ///     The connection string for.
        /// </returns>
        public static string GetConnectionStringFor(string databaseName)
        {
            return ConnectionStrings.SingleOrDefault(c => c.Name == databaseName)?.Value;
        }
    }
}