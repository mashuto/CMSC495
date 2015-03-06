/****************************************************************
 * AddUser.xaml.cs
 * CMSC 495
 * 
 * Revisions:
 * 2/22/2015    Matthew Kocin:      Initial Creation
 * 3/01/2015    Matthew Kocin       Updates to use repository and encryption
 * 3/06/2015    Matthew Kocin       Updated error message to show inner exception
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
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Page
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void AddUser_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new DataContext())
                {
                    var userRepository = new UserRepository(db);
                    if (UserNameBox.Text == "")
                    {
                        MessageBox.Show("User Name Cannot be Blank.");
                    }
                    else
                    {
                        var test = userRepository.CheckUserNameExists(UserNameBox.Text);

                        if (userRepository.CheckUserNameExists(UserNameBox.Text))
                        {
                            MessageBox.Show("This user name already exists. Please choose another.");
                        }
                        else if (Password1Box.Text != Password2Box.Text)
                        {
                            MessageBox.Show("Passwords do not match.");
                        }
                        else if (Password1Box.Text == "" || Password2Box.Text == "")
                        {
                            MessageBox.Show("Password cannot be blank.");
                        }
                        else
                        {
                            string key = Crypto.GenerateRandomKey();
                            var user = new User { UserName = UserNameBox.Text, Password = Crypto.Encrypt(key, Password1Box.Text, (EncryptionAlgorithm)0), Key = key };
                            userRepository.AddUser(user);
                            NavigationService.Navigate(new UserDataPage(user));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error: " + ex.Message + ex.InnerException.Message);
            }
        }

        private void Cancel_Clicked(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
