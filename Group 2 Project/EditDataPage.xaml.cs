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
        public int id { get; set; }
        public int userId { get; set; }
        public EditDataPage(UserData data, int userId)
        {
            InitializeComponent();
            id = data.UserDataId;
            this.userId = userId;
            TypeBox.Text = data.Type;
            InformationBox.Text = Crypto.Decrypt(data.Key, data.Information, (EncryptionAlgorithm)data.Encryption);
            CommentBox.Text = data.Comment;
        }

        private void Update_Clicked(object sender, RoutedEventArgs e)
        {
            
            using (var db = new DataContext())
            {
                var userRepository = new UserRepository(db);
                var userData = userRepository.GetUserDataById(id);
                userData.Type = TypeBox.Text;
                userData.Information = Crypto.Encrypt(userData.Key, InformationBox.Text, (EncryptionAlgorithm)userData.Encryption);
                userData.Comment = CommentBox.Text;
                userRepository.UpdateUserData(userData);
                NavigationService.Navigate(new UserDataPage(userRepository.GetUserById(userId)));
            }
        }

        private void Cancel_Clicked(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
