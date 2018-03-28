using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CliHelpers;
using DbLocalizationProvider;
using Microsoft.Extensions.CommandLineUtils;
using Newtonsoft.Json;

namespace FluiTec.AppFx.Localization.Exporter
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new CommandLineApplication
            {
                Name = "AppFx-LocalizationExporter",
                Description = "Exporter for AppFx-Localizations supporting Mssql, Pgsql, Mysql, LiteDb, Assembly",
            };
            app.HelpOption("-?|-h|--help");

            // add option for selecting the correct source type
            var sourceTypeOption = app
                .AddCliOption("-t | --type <type>", "ExportSourceType (Mssql, Pgsql, Mysql, LiteDb, Assembly")
                .IsRequired<string>()
                .ValidatedWith(EnumHelper.IsEnum<ExportSourceType>, "Invalid ExportSourceType")
                .TransformWith(EnumHelper.ParseEnum<ExportSourceType>);

            // add option to specify fileName / connectionString
            var sourceOption = app.AddCliOption("-s | --source <source>", "ExportSource (FileName, ConnectionString")
                .IsRequired<string>();

            // add option to filter outpout by resourceKey
            var filterOption = app.AddCliOption("-f | --filter <filter>", "ResourceKeyFilter (case sensitive)")
                .WithDefaultValue(string.Empty);

            // add option to specify exportFileName
            var exportFileNameOption = app.AddCliOption("-e | --exportFile <exportFile>",
                    "ExportFileName (example: \"./json/export\", default is common basePath of exported resources")
                .WithDefaultValue(string.Empty);

            app.OnExecute(() =>
            {
                Console.WriteLine(app.Name);

                var type = sourceTypeOption.Value();
                Console.WriteLine($"--> Using ExportSourceType {type}");

                var source = sourceOption.Value();
                Console.WriteLine($"--> Using Source {source}");

                var filter = filterOption.Value();
                if (!string.IsNullOrWhiteSpace(filter))
                    Console.WriteLine($"--> Using Filter {filter}");

                var reader = ExportSourceReaderFactory.Create(type, source);
                var entries = string.IsNullOrWhiteSpace(filter)
                    ? reader.ReadAll()
                    : reader.ReadAll().Where(e => e.ResourceKey.StartsWith(filter));

                var optionValue = exportFileNameOption.Value();
                var baseFileName = string.IsNullOrWhiteSpace(optionValue)
                    ? "./json/" + FindCommonBasePath(entries)
                    : optionValue;
                var fileName = $"{baseFileName}.json";
                Console.WriteLine($"--> Exporting to file {fileName}");

                var json = JsonConvert.SerializeObject(entries);

                // ensure old files are deleted
                if (File.Exists(fileName))
                    File.Delete(fileName);

                // ensure target directory exists
                var directoryName = new FileInfo(fileName).DirectoryName;
                if (!Directory.Exists(directoryName))
                    Directory.CreateDirectory(directoryName);

                File.WriteAllText(fileName, json, Encoding.UTF8);

                return 0;
            });

            try
            {
                // parse and call OnExecute handler specified above
                app.Execute(args);
            }
            catch (CommandParsingException ex)
            {
                Console.WriteLine(app.Name);
                Console.WriteLine(app.Description);
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>Searches for the first common base path.</summary>
        /// <param name="entries">  The entries. </param>
        /// <returns>The found common base path.</returns>
        private static string FindCommonBasePath(IEnumerable<LocalizationResource> entries)
        {
            var resources = entries.ToList();

            // set current key to longest resourceKey in list
            var currentKey = resources.Aggregate("",
                (max, cur) => max.Length > cur.ResourceKey.Length ? max : cur.ResourceKey);

            // substring till all resourceKeys start with the currentKey
            while (!resources.All(r => r.ResourceKey.StartsWith(currentKey)))
                currentKey = currentKey.Substring(0, currentKey.Length - 1);

            // remove last dot if any
            var returnValue = currentKey.EndsWith(".") ? currentKey.Substring(0, currentKey.Length - 1) : currentKey;

            return returnValue ?? "export";
        }
    }
}