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

namespace Group_2_Project
{
    /// <summary>
    /// Interaction logic for AddDataPage.xaml
    /// </summary>
    public partial class AddDataPage : Page
    {
        public User User { get; set; }

        public AddDataPage(User user)
        {
            InitializeComponent();
            this.User = user;
        }

        private void Add_Clicked(object sender, RoutedEventArgs e)
        {
            var userData = new UserData { Type = TypeBox.Text, Comment = CommentBox.Text, Information = InformationBox.Text, User = User };
            using (var db = new DataContext())
            {
                db.UserData.Add(userData);
                db.SaveChanges();
                NavigationService.Navigate(new UserDataPage(db.Users.FirstOrDefault(x => x.UserId == User.UserId)));
            }
        }
    }
}
