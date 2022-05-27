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
using System.Windows.Shapes;

namespace FitnessCentra.PresentationWPF.Windows
{
    /// <summary>
    /// Interaction logic for LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        public event EventHandler<List<object>>LogIn;
        public LogInWindow()
        {
            InitializeComponent();
            windowMenu.AbonneerOpVensterSluiten.Add(this);
            windowMenu.AbonneerOpVensterBewegegingen.Add(this);
            windowMenu.AbonneerOpVensterVerklein.Add(this);
        }
 
        private void LogIn_klant(object? sender, RoutedEventArgs e)
        {
            string inlogGegevens = emailTxtBox.Text;
            List<object> gegevens = new List<object>(){ };
            gegevens.Add(inlogGegevens);
            gegevens.Add(false);
            
            LogIn?.Invoke(sender, gegevens);
           
        }

        private void LogIn_beheerder(object? sender, RoutedEventArgs e)
        {
            string inlogGegevens = emailTxtBox.Text;
            List<object> gegevens = new List<object>() { };
            gegevens.Add(inlogGegevens);
            gegevens.Add(true);

            LogIn?.Invoke(sender, gegevens);

        }



    }
}
