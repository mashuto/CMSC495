using Group_2_Project.Models;
using Group_2_Project.DAL;
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
using Group_2_Project.Repository;

namespace Group_2_Project
{
    /// <summary>
    /// Interaction logic for AddDataPage.xaml
    /// </summary>
    public partial class AddDataPage : Page
    {
        public int ID { get; set; }

        public AddDataPage(int id)
        {
            InitializeComponent();
            this.ID = id;
        }

        private void Add_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new DataContext())
                {
                    var userRepository = new UserRepository(db);
                    var user = userRepository.GetUserById(ID);
                    var userData = new UserData { Type = TypeBox.Text, Comment = CommentBox.Text, Information = InformationBox.Text, User = user };
                    userRepository.AddUserData(userData);
                    NavigationService.Navigate(new UserDataPage(user));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error: " + ex.Message);
            }
        }
    }
}
