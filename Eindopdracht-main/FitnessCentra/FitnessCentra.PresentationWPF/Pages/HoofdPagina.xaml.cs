using Fitness.Domain;
using FitnessCentra.Domain.Models;
using FitnessCentra.PresentationWPF.Components;
using FitnessCentra.PresentationWPF.Components.Optiebox;
using FitnessCentra.PresentationWPF.Components.Panelen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FitnessCentra.PresentationWPF.Pages
{
    /// <summary>
    /// Interaction logic for HoofdPagina.xaml
    /// </summary>
    public partial class HoofdPagina : Page
    {
        private DomainController _controller;
        private bool _volledigaToegang;
        public EventHandler<RoutedEventArgs> LogUitClick;
        public HoofdPagina(DomainController controller)
        {
            _controller = controller;
            InitializeComponent();
            GenereerMenu();
        }

        private void GenereerMenu()
        {
            buttonMenu.Children.Clear();
            if (_controller.IsGebruikerVolledigBevoegd())
            {
                MenuButton menuButtonToestellen = new MenuButton("Toestellen beheren");
                menuButtonToestellen.ButtonClick += ToonAlleToestellen_Click;
                buttonMenu.Children.Add(menuButtonToestellen);

            }
            MenuButton menuButtonRezerveer = new MenuButton("Rezerveer");
            menuButtonRezerveer.ButtonClick += ToonRezerveringen;
            buttonMenu.Children.Add(menuButtonRezerveer);
        }

        private void ToonRezerveringen(object? sender, RoutedEventArgs e)
        {
            ToonAlleRezerveringen(menu);
        }

        private void ToonAlleRezerveringen(StackPanel stackPanel)
        {
            stackPanel.Children.Clear();
            RezerveerPaneel rezerveerPaneel = new RezerveerPaneel(_controller);
            stackPanel.Children.Add(rezerveerPaneel);
        }

        private void ToonAlleToestellen_Click(object sender, RoutedEventArgs e)
        {
            ToonAlleToestellen(menu);
        }

        private void ToonAlleToestellen(StackPanel stackPanel)
        {
            stackPanel.Children.Clear();
            BeheerdersPaneel beheerdersPaneel = new BeheerdersPaneel(_controller);
            menu.Children.Add(beheerdersPaneel);
        }

        private void LogUit_Click(object sender, RoutedEventArgs e)
        {
            LogUitClick?.Invoke(this, e);
        }

    }
}
