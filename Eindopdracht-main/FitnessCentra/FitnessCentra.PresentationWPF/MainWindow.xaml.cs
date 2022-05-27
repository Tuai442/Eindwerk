using Fitness.Domain;
using Fitness.Domain.Models;
using FitnessCentra.PresentationWPF.Components.Panelen;
using FitnessCentra.PresentationWPF.Pages;
using FitnessCentra.PresentationWPF.Windows;
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

namespace FitnessCentra.PresentationWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public EventHandler<RoutedEventArgs> LogUit_Click;
        private DomainController _controller;

        LogInWindow _logInWindow;
        public MainWindow(DomainController controller)
        {
            _controller = controller;
            InitializeComponent();
            windowMenu.AbonneerOpVensterSluiten.Add(this);
            windowMenu.AbonneerOpVensterBewegegingen.Add(this);
            windowMenu.AbonneerOpVensterVerklein.Add(this);
        }

        private void NavigeerNaarHoofdPagina()
        {
            HoofdPagina hoofPagina = new HoofdPagina(_controller);
            hoofPagina.LogUitClick += LogUitClick;
            mainFrame.Navigate(hoofPagina);

        }

        private void LogUitClick(object? sender, RoutedEventArgs e)
        {
            LogUit_Click?.Invoke(this, e);
        }

        public new void Show()
        {
            NavigeerNaarHoofdPagina();
            base.Show();
        }

    
    }
}
