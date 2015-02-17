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
using Group_2_Project.Models;
using Group_2_Project.DAL;

namespace Group_2_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //DataContext db = new DataContext();

            //Gets all the users from the db to a list object
            //var test = db.Users.ToList();
            //MessageBox.Show(test.First().UserName);

            //test code to get a the first user where password is blank, then remove
            //var abc = db.Users.FirstOrDefault(x => x.Password == "");
            //db.Users.Remove(abc);
            MainFrame.Navigate(new Login());
        }
    }
}
