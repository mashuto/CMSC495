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
using Group_2_Project.Repository;

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
            try
            {
                using (var db = new DataContext())
                {
                    var userRepository = new UserRepository(db);
                    if (!userRepository.CheckUserNameExists(UserName.Text))
                    {
                        MessageBox.Show("User name not found");
                    }
                    else
                    {
                        var user = userRepository.GetUserByUserNameAndPassword(UserName.Text, Password.Text);
                        if (user == null)
                        {
                            MessageBox.Show("Incorrect Password.");
                        }
                        else
                        {
                            NavigationService.Navigate(new UserDataPage(user));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error: " + ex.Message);
            }
        }

        private void AddNewUserButton_Clicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddUser());
        }
    }
}
