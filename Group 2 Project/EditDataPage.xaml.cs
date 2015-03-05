/****************************************************************
 * EditDataPage.xaml.cs
 * CMSC 495
 * 
 * Revisions:
 * 3/04/2015    Matthew Kocin:      Initial Creation
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
    /// Interaction logic for EditDataPage.xaml
    /// </summary>
    public partial class EditDataPage : Page
    {
        public UserData userData { get; set; }

        public EditDataPage(UserData data)
        {
            InitializeComponent();
            userData = data;
            TypeBox.Text = userData.Type;
            InformationBox.Text = Crypto.Decrypt(userData.Key, userData.Information, (EncryptionAlgorithm)userData.Encryption);
            CommentBox.Text = userData.Comment;
        }

        private void Update_Clicked(object sender, RoutedEventArgs e)
        {
            userData.Type = TypeBox.Text;
            userData.Information = Crypto.Encrypt(userData.Key, InformationBox.Text, (EncryptionAlgorithm)userData.Encryption);
            userData.Comment = CommentBox.Text;
            using (var db = new DataContext())
            {
                var userRepository = new UserRepository(db);
                userRepository.UpdateUserData(userData);
            }
            NavigationService.Navigate(new UserDataPage(userData.User));
        }

        private void Cancel_Clicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserDataPage(userData.User));
        }
    }
}
