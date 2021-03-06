﻿/****************************************************************
 * UserDataPage.xaml.cs
 * CMSC 495
 * 
 * Revisions:
 * 2/22/2015    Matthew Kocin:      Initial Creation
 * 3/01/2015    Matthew Kocin       Updated to decrypt data properly
 * 3/03/2015    Matthew Kocin       Added initial code to start allow editing records
 * 3/04/2015    Matthew Kocin       Finished adding editing ability. Added Delete ability.
 * 3/06/2015    Matthew Kocin       Some modifications to keep the software working properly with the new connecting string/deploy
*****************************************************************/

using Group_2_Project.DAL;
using Group_2_Project.Models;
using Group_2_Project.Repository;
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
            public int ID { get; set; }
        }

        public User User { get; set; }
        public UserDataPage(User user)
        {
            InitializeComponent();
            this.User = user;
            IList<GridData> userData = new List<GridData>();
            try
            {
                using (var db = new DataContext())
                {
                    var userRepository = new UserRepository(db);
                    foreach (var data in userRepository.GetUserDataByUser(user))
                    {
                        userData.Add(new GridData { Type = data.Type, Information = Crypto.Decrypt(data.Key, data.Information, (EncryptionAlgorithm)data.Encryption), Comments = data.Comment, ID = data.UserDataId });
                    }
                }
            }
            catch (Exception ex)
            {

            }
            UserDataGrid.ItemsSource = userData;
            UserDataGrid.IsReadOnly = true;
        }

        private void AddData_Clicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddDataPage(User.UserId));
        }

        private void OnGenerating(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.ToLower() == "id")
            {
                e.Cancel = true;
            }
            if (e.PropertyName.ToLower() == "type")
            {
                e.Column.Width = new DataGridLength(20, DataGridLengthUnitType.Star);
            }
            if (e.PropertyName.ToLower() == "information")
            {
                e.Column.Width = new DataGridLength(50, DataGridLengthUnitType.Star);
            }
            if (e.PropertyName.ToLower() == "comments")
            {
                e.Column.Width = new DataGridLength(30, DataGridLengthUnitType.Star);
            }
        }

        private void Edit_Clicked(object sender, RoutedEventArgs e)
        {
            if (UserDataGrid.SelectedItem != null)
            {
                var data = (GridData)UserDataGrid.SelectedItem;
                UserData userData = null;
                using (var db = new DataContext())
                {
                    var userRepository = new UserRepository(db);
                    userData = userRepository.GetUserDataById(data.ID);
                    userData.User = User;
                }
                NavigationService.Navigate(new EditDataPage(userData, User.UserId));
            }
        }

        private void Delete_Clicked(object sender, RoutedEventArgs e)
        {
            if (UserDataGrid.SelectedItem != null)
            {
                if (MessageBox.Show("Really Delete? This cannot be undone.", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    try
                    {
                        using (var db = new DataContext())
                        {
                            var gridData = (GridData)UserDataGrid.SelectedItem;
                            var userRepository = new UserRepository(db);
                            var userData = userRepository.GetUserDataById(gridData.ID);
                            userRepository.DeleteUserData(userData);
                            NavigationService.Navigate(new UserDataPage(userRepository.GetUserById(User.UserId)));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There was an error: " + ex.Message);
                    }
                }
            }
        }
    }
}
