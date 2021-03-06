﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using GalaSoft.MvvmLight;
using LiteDB;

namespace FluiTec.AppFx.Data.LiteDb.Editor.ViewModel
{
    /// <summary>   A ViewModel for the database. </summary>
    public class DatabaseViewModel : ViewModelBase, IDisposable
    {
        private readonly LiteDatabase _db;

        private string _activeCollection;
        private List<BsonDocument> _bson;

        private DataTable _data;

        public DatabaseViewModel() : this(null)
        {
        }

        public DatabaseViewModel(string fileName)
        {
            if (!File.Exists(fileName)) return;

            _db = new LiteDatabase(fileName);
            CollectionNames = _db.GetCollectionNames();
        }

        /// <summary>   Gets a list of names of the collections. </summary>
        /// <value> A list of names of the collections. </value>
        public IEnumerable<string> CollectionNames { get; }

        /// <summary>   Gets or sets the active collection. </summary>
        /// <value> A collection of actives. </value>
        public string ActiveCollection
        {
            get => _activeCollection;
            set
            {
                Set(ref _activeCollection, value);
                if (!string.IsNullOrWhiteSpace(_activeCollection))
                {
                    var collection = _db.GetCollection(_activeCollection);
                    _bson = collection.FindAll().ToList();

                    var tableKeys = GetKeys(_bson);

                    var table = new DataTable(_activeCollection);
                    for (var i = 0; i < tableKeys.Count; i++)
                        table.Columns.Add(tableKeys.ElementAt(i).Key, tableKeys.ElementAt(i).Value);

                    foreach (var entry in _bson)
                    {
                        var netValues = new object[tableKeys.Count];

                        for (var i = 0; i < tableKeys.Count; i++)
                            netValues[i] = GetValue(entry[tableKeys.ElementAt(i).Key]);
                        table.Rows.Add(netValues);
                    }

                    Data = table;
                    Data.RowChanged += Data_RowChanged;
                    Data.RowDeleting += Data_RowDeleted;
                }
                else
                {
                    if (Data != null)
                    {
                        Data.RowChanged -= Data_RowChanged;
                        Data.RowDeleted -= Data_RowDeleted;
                    }

                    Data = null;
                }
            }
        }

        /// <summary>   Gets or sets the data. </summary>
        /// <value> The data. </value>
        public DataTable Data
        {
            get => _data;
            private set => Set(ref _data, value);
        }

        public void Dispose()
        {
            _db?.Dispose();
            _data?.Dispose();
        }

        private Dictionary<string, Type> GetKeys(List<BsonDocument> data)
        {
            var dictionary = new Dictionary<string, Type>();
            foreach (var entity in data)
            foreach (var key in entity.Keys)
                if (!dictionary.ContainsKey(key))
                    dictionary.Add(key, GetType(entity[key].Type));
            return dictionary;
        }

        private void Data_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            var newArgs = new DataRowChangeEventArgs(e.Row, DataRowAction.Delete);
            Data_RowChanged(sender, newArgs);
        }

        private void Data_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (e.Action)
            {
                case DataRowAction.Add:
                {
                    var collection = _db.GetCollection(ActiveCollection);
                    var entry = collection.FindAll().First().Keys
                        .ToDictionary(key => key, key => new BsonValue(e.Row[key]));
                    collection.Insert(new BsonDocument(entry));
                    break;
                }
                case DataRowAction.Change:
                {
                    var key = e.Row.ItemArray[0];
                    var collection = _db.GetCollection(ActiveCollection);
                    var entry = collection.FindById(new BsonValue(key));
                    foreach (var eKey in entry.Keys)
                        if (eKey != "_id")
                            entry.Set(eKey, new BsonValue(e.Row[eKey]));
                    collection.Update(entry);
                    break;
                }
                case DataRowAction.Delete:
                {
                    var key = e.Row.ItemArray[0];
                    var collection = _db.GetCollection(ActiveCollection);
                    collection.Delete(new BsonValue(key));
                    break;
                }
            }
        }

        private static Type GetType(BsonType type)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (type)
            {
                case BsonType.Int32:
                    return typeof(int);
                case BsonType.Int64:
                    return typeof(long);
                case BsonType.Double:
                    return typeof(double);
                case BsonType.Decimal:
                    return typeof(decimal);
                case BsonType.String:
                    return typeof(string);
                case BsonType.Array:
                    return typeof(Array);
                case BsonType.Binary:
                    return typeof(byte[]);
                case BsonType.Guid:
                    return typeof(Guid);
                case BsonType.Boolean:
                    return typeof(bool);
                case BsonType.DateTime:
                    return typeof(DateTime);
                default:
                    throw new NotImplementedException();
            }
        }

        private static object GetValue(BsonValue value)
        {
            if (value.IsInt32)
                return value.AsInt32;
            if (value.IsInt64)
                return value.AsInt64;
            if (value.IsDouble)
                return value.AsDouble;
            if (value.IsDecimal)
                return value.AsDecimal;
            if (value.IsString)
                return value.AsString;
            if (value.IsArray)
                return value.AsArray;
            if (value.IsBinary)
                return value.AsBinary;
            if (value.IsGuid)
                return value.AsGuid;
            if (value.IsBoolean)
                return value.AsBoolean;
            if (value.IsDateTime)
                return value.AsDateTime;

            return null;
        }

        public void Close()
        {
            _db?.Dispose();
        }
    }
}