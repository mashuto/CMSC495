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
using Group_2_Project.DAL;

namespace Group_2_Project
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Clicked(object sender, RoutedEventArgs e)
        {
            using (var db = new DataContext())
            {
                //normally we would encrypt data here to match encrypted data in the db
                var users = db.Users.FirstOrDefault(x => x.UserName == UserName.Text);
                if (users == null)
                {
                    MessageBox.Show("User name not found");
                }
                else
                {
                    var currUser = db.Users.FirstOrDefault(x => x.UserName == UserName.Text && x.Password == Password.Text);
                    if (currUser == null)
                    {
                        MessageBox.Show("Incorrect Password.");
                    }
                    else
                    {
                        MessageBox.Show("Logged in!");
                        NavigationService.Navigate(new UserDataPage(currUser));
                        //call new page and pass currUser object to page
                    }
                }
            }
        }
    }
}
