using Group_2_Project.DAL;
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
            using (var db = new DataContext())
            {
                if (UserNameBox.Text == "")
                {
                    MessageBox.Show("User Name Cannot be Blank.");
                }
                else
                {
                    var existingUser = db.Users.SingleOrDefault(x => x.UserName == UserNameBox.Text);
                    if (existingUser != null)
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
                        var user = new User { UserName = UserNameBox.Text, Password = Password1Box.Text };
                        db.Users.Add(user);
                        NavigationService.Navigate(new UserDataPage(user));
                    }
                }
            }
        }
    }
}
