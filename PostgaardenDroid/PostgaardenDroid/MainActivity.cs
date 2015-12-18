using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Postgaarden.Connection.Sqlite;
using System.IO;
using Postgaarden.Connection;

namespace PostgaardenDroid
{
    [Activity(Label = "PostgaardenDroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var pathToDatabase = Path.Combine(docsFolder, "postgaarden.db");
            

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            DatabaseConnection SqlCon = SqliteDatabaseConnection.GetInstance(pathToDatabase);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.CreateDbButton);
            TextView isDbCreatedText = FindViewById<TextView>(Resource.Id.IsDbText);

            button.Click += delegate {
                if (File.Exists(pathToDatabase))
                    isDbCreatedText.Text = "DBCreated! :D";
                else
                    isDbCreatedText.Text = "Something went wrong";
            };
            string[] createTableSql =
                { @"CREATE TABLE IF NOT EXISTS `Employee` (
	                `Id`	INTEGER NOT NULL,
	                `Name`	CHAR(25) NOT NULL,
	                `Email`	CHAR(25) NOT NULL,
                    PRIMARY KEY(Id));",
                    @"CREATE TABLE IF NOT EXISTS `Customer` (
	                `CVR`	CHAR(8) NOT NULL,
	                `Name`	CHAR(25) NOT NULL,
	                `Email`	CHAR(25) NOT NULL,
	                `Company`	CHAR(25) NOT NULL,
	                PRIMARY KEY(CVR));",
                    @"CREATE TABLE IF NOT EXISTS `ConferenceRoom` (
	                `Id`	INTEGER NOT NULL,
	                `Capacity`	INTEGER NOT NULL,
	                PRIMARY KEY(Id)
                    );",
                    @"CREATE TABLE IF NOT EXISTS `Equipment` (
	                `Id`	INTEGER NOT NULL,
	                `Name`	CHAR(25) NOT NULL,
	                `ConferenceRoomId`	INTEGER NOT NULL,
                    PRIMARY KEY(Id),
                    FOREIGN KEY(`ConferenceRoomId`) REFERENCES ConferenceRoom ( Id ));",
                    @"CREATE TABLE IF NOT EXISTS `Booking` (
	                `Id` INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
	                `StartTime`	DATETIME NOT NULL,
	                `EndTime`	DATETIME NOT NULL,
	                `Price`	REAL NOT NULL,
	                `ConferenceRoomId`	INTEGER NOT NULL,
	                `CustomerCVR`	CHAR(8) NOT NULL,
	                `EmployeeId`	INTEGER NOT NULL,
	                FOREIGN KEY(`ConferenceRoomId`) REFERENCES ConferenceRoom ( Id ),
	                FOREIGN KEY(`EmployeeId`) REFERENCES Employee ( Id ));"
                };
            
            foreach(string s in createTableSql)
            {
                SqlCon.CreateTable(s);
            }

            

            
        }
    }
}

