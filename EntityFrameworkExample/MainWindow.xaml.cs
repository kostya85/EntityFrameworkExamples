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

namespace EntityFrameworkExample
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (SoccerContext db = new SoccerContext())
            {
                db.Players.Add(new Player("Ronaldo", 36, "Forward"));
                db.SaveChanges();
                Players.ItemsSource = db.Players.ToArray();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string name = NameAdd.Text;
            string position = PositionAdd.Text;
            int age;
            if (!int.TryParse(AgeAdd.Text, out age)) MessageBox.Show("Error data!");
            else
            {

                if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(position))
                {
                    MessageBox.Show("Error data!");

                }
                else
                {
                    using (SoccerContext db = new SoccerContext())
                    {
                        db.Players.Add(new Player(name, age, position));
                        db.SaveChanges();
                        Players.ItemsSource = db.Players.ToArray();
                    }
                }
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            int id;
            if(int.TryParse(IdDelete.Text, out id)){
                using (SoccerContext db = new SoccerContext())
                {
                    try
                    {
                        Player p = db.Players.First(k => k.Id==id);
                        db.Players.Remove(p);
                        db.SaveChanges();
                        Players.ItemsSource = db.Players.ToArray();
                    }
                    catch
                    {
                        MessageBox.Show("Data error!");
                    }
                    
                }
            }
        }
    }
}
