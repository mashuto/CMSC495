/****************************************************************
 * UserDataPage.xaml.cs
 * CMSC 495
 * 
 * Revisions:
 * 2/22/2015    Matthew Kocin:      Initial Creation
*****************************************************************/

using Group_2_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Group_2_Project
{
    /// <summary>
    /// Interaction logic for UserDataPage.xaml
    /// </summary>
    public partial class UserDataPage : Page
    {

        class GridData
        {
            public string Type { get; set; }
            public string Information { get; set; }
            public string Comments { get; set; }
        }

        public User User { get; set; }
        public UserDataPage(User user)
        {
            InitializeComponent();
            this.User = user;
            IList<GridData> userData = new List<GridData>();
            foreach (var data in user.UserData)
            {
                userData.Add(new GridData { Type = data.Type, Information = data.Information, Comments = data.Comment });
            }
            UserDataGrid.ItemsSource = userData;
            UserDataGrid.IsReadOnly = true;
            
            TestLabel.Content = User.UserName + " has " + User.UserData.Count + " saved data items.";
        }

        private void AddData_Clicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddDataPage(User.UserId));
        }
    }
}
