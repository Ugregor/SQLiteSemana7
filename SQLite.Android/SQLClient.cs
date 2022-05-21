using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.IO;
using SQLite.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(SQLClient))]

namespace SQLite.Droid
{
    public class SQLClient : Database
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documetnPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documetnPath, "uisraeldb");
            return new SQLiteAsyncConnection(path);
        }
    }
}