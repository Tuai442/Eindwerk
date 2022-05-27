using Fitness.Domain;
using Fitness.Domain.Interfaces;
using Fitness.Percistence;
using FitnessCentra.Domain.Interfaces;
using FitnessCentra.Persictance.Mappers;
using FitnessCentra.PresentationWPF.Pages;
using FitnessCentra.PresentationWPF.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FitnessCentra.PresentationWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private DomainController _controller;
        private LogInWindow _logInWindow;
        private MainWindow _hoofdWindow;
        protected override void OnStartup(StartupEventArgs e)
        {

            IGebruikerRepository gebruikerRepository = new GebruikerMapper();
            IToestelRepository toestelRepository = new ToestelMapper();
            IReserveerRepository reserveerRepository = new ReserveringMapper();

            _controller = new DomainController(gebruikerRepository, toestelRepository, reserveerRepository);
            _hoofdWindow = new MainWindow(_controller);
            _hoofdWindow.LogUit_Click += LogUitClick;

            ToonLogInWindow();
           
        }

        private void ToonLogInWindow()
        {
            _logInWindow = new LogInWindow();
            _logInWindow.LogIn += InLoggen;
            _logInWindow.Show();
        }
        private void ControleIsGebruikerIngelogd()
        {
            if (!_controller.IsGebruikerIngelogd())
            {
                throw new Exception("Er moet ingelogd zijn om deze pagina te betreden.");
            }
        }

        private void InLoggen(object? sender, List<object> gegevens)
        {
            string inlogGegevens = (string)gegevens[0];
            bool bevoegdheid = (bool)gegevens[1];
            bool ingelogt = _controller.LogGebruikerInMetInlogGegevens(inlogGegevens, bevoegdheid);
            if (ingelogt)
            {
                _logInWindow.Close();
                ToonWindow(_hoofdWindow);                
            }
            else
            {
                MessageBox.Show("Fout email.");
            }
        }

        private void ToonWindow(MainWindow window)
        {
            ControleIsGebruikerIngelogd();
            window.Show();
        }

        private void LogUitClick(object? sender, RoutedEventArgs e)
        {
            _controller.LogUit();

            ToonLogInWindow();
            _hoofdWindow.Close();
            _hoofdWindow = new MainWindow(_controller);
            _hoofdWindow.LogUit_Click += LogUitClick; 
            
        }




    }
}
