using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace FitnessCentra.PresentationWPF.Components
{
    /// <summary>
    /// Interaction logic for WindowMenu.xaml
    /// </summary>
    public partial class WindowMenu : UserControl
    {
       

        public event EventHandler<RoutedEventArgs> SluitHandler;

        public List<Window> AbonneerOpVensterVergroot;
        public List<Window> AbonneerOpVensterVerklein;
        public List<Window> AbonneerOpVensterBewegegingen;
        public List<Window> AbonneerOpVensterSluiten;
        public WindowMenu()
        {
            AbonneerOpVensterBewegegingen = new List<Window>();
            AbonneerOpVensterVerklein = new List<Window>();
            AbonneerOpVensterVergroot = new List<Window>();
            AbonneerOpVensterSluiten = new List<Window>();
            InitializeComponent();
        }

        private void Vergroot_click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in AbonneerOpVensterBewegegingen)
            {
                if(window.WindowState == WindowState.Normal)
                {
                    window.WindowState = WindowState.Maximized;

                }
                else if (window.WindowState == WindowState.Maximized)
                {
                    window.WindowState = WindowState.Normal;
                }
            }
        }

        private void Verklein_click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in AbonneerOpVensterBewegegingen)
            {
                window.WindowState = WindowState.Minimized;
            }
        }

        private void Sluit_click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in AbonneerOpVensterBewegegingen)
            {
                window.Close();
                
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            foreach(Window window in AbonneerOpVensterBewegegingen)
            {
               
                window.DragMove();
                
            }

        }
    }
}
