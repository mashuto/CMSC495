/****************************************************************
 * App.xaml.cs
 * CMSC 495
 * 
 * Revisions:
 * 2/22/2015    Matthew Kocin:      Initial Creation
 * 3/06/2015    Matthew Kocin       Copy db mdf file to shared public folder
*****************************************************************/

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Group_2_Project.DAL;
using System.IO;

namespace Group_2_Project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            if (File.Exists(Directory.GetCurrentDirectory() + "\\Group2.mdf"))
            {
                if (!File.Exists("C:\\Users\\Public\\Group2.mdf"))
                {
                    File.Copy(Directory.GetCurrentDirectory() + "\\Group2.mdf", "C:\\Users\\Public\\Group2.mdf");
                }
            }
            //Database.SetInitializer(new DataInitializer());
        }
    }
}
