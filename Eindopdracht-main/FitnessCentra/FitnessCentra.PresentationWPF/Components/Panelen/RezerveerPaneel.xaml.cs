using Fitness.Domain;
using FitnessCentra.Domain.Models;
using FitnessCentra.PresentationWPF.Components.Optiebox;
using FitnessCentra.PresentationWPF.Components.Tijdslot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
using FitnessCentra.PresentationWPF.Components;
using Fitness.Domain.Models;
using FitnessCentra.Domain.Models.Reservaties;

namespace FitnessCentra.PresentationWPF.Components.Panelen
{
    /// <summary>
    /// Interaction logic for RezerveerPaneel.xaml
    /// </summary>
    public partial class RezerveerPaneel : UserControl
    {
        public EventHandler<DateTime> DagDubbeleClickHandler;
        private Dictionary<string, string> nederlandseMaanden = new Dictionary<string, string>()
        {
            {"January", "Januarie" },
            {"February", "Februari" },
            {"March", "Maart" },
            {"April", "April" },
            {"May", "Mei" },
            {"June", "Junie" },
            {"July", "Julie" },
            {"August", "Augustus" },
            {"September", "September" },
            {"October", "Oktober" },
            {"November", "November" },
            {"December", "December" },

        };

        private Dictionary<string, string> nederlandseDagen = new Dictionary<string, string>()
        {
            {"Monday", "Maandag" },
           {"Tuesday", "Dinsdag"},
           {"Wednesday", "Woensdag"},
           {"Thursday", "Donderdag"},
           {"Friday", "Vrijdag"},
           {"Saturday", "Zaterdag"},
           {"Sunday", "Zondag"} ,

        };
        private DomainController _controller;
        private Dictionary<int, Dictionary<int, Reservatie>> huidigeRezervatiesVanDeGeselecteerdeDag;
        private DateTime _geselecteerdeDatum;

        public RezerveerPaneel(DomainController controller)
        {
            InitializeComponent();
            _controller = controller;
            callender.DagClickHandler += NieuweGeselecteerdeDag;
            huidigeRezervatiesVanDeGeselecteerdeDag = new Dictionary<int, Dictionary<int, Domain.Models.Reservaties.Reservatie>>();
        }

        private void NieuweGeselecteerdeDag(object? sender, DateTime e)
        {
            ToonDag(e);
        }

        public void ToonDag(DateTime datum)
        {
            dagNr.Content = datum.Day.ToString();
            maand.Content = nederlandseMaanden[datum.ToString("MMMM", CultureInfo.InvariantCulture)];
            dag.Content = nederlandseDagen[datum.ToString("dddd", CultureInfo.InvariantCulture)];

            _geselecteerdeDatum = datum;
            huidigeRezervatiesVanDeGeselecteerdeDag = _controller.GeefRezervatiesOpDatum(datum);

            int tijdVoorwaarden = _controller.GeefTijdVoorwaarden();
            if( DateTime.Now > _geselecteerdeDatum.AddDays(1))
            {
                MaakAangepastOverzicht("Je kan niet in het verleden rezerveren.");
            }
            else if(DateTime.Now.AddDays(tijdVoorwaarden) <= _geselecteerdeDatum)
            {
                MaakAangepastOverzicht("Er kan max binnen 7 dagen gerezerveerd worden.");
            }
            else
            {
                MaakToestelOverzicht();
            }
        }

        private void MaakAangepastOverzicht(string txt)
        {
            rezerveerOverzicht.Children.Clear();
            Label label = new Label();
            label.Content = txt;
            rezerveerOverzicht.Children.Add(label);
        }

        public void MaakToestelOverzicht()
        {
            rezerveerOverzicht.Children.Clear();
            Dictionary<string, List<Toestel>> toestellenPerType = _controller.GeefAlleToestellenPerType();

            foreach (string toestelType in toestellenPerType.Keys)
            {
                OptieBox2 optieBox = new OptieBox2();
                optieBox.Titel = toestelType.ToString();
                foreach (Toestel toestel in toestellenPerType[toestelType])
                { 
                    Label1 label = new Label1();
                    label.LText = toestel.Type.ToString();
                    label.RText = toestel.Id.ToString();
                    label.Id = toestel.Id;
                    label.LabelClick = kiesUurVanRezervering;

                    // Kijkt of er een toestel beschikbaaris via de toestel id.
                    bool dagIsNietBeschikbaar = huidigeRezervatiesVanDeGeselecteerdeDag.All(x => x.Value[toestel.Id] != null);
                    bool isErEenReservatieOpGeselecteerdeDatum = _controller.IsErEenReservatieOpDatum(_geselecteerdeDatum);
                    // Er zijn geen beschikbare sloten meer op dit toesten en datum.
                    if (dagIsNietBeschikbaar)
                    {
                        label.StelStatusIn(false);
                    }
                    if (toestel.OnderhoudBijVolgendeVrijStelling && !isErEenReservatieOpGeselecteerdeDatum)
                    {
                       
                        label.StelStatusIn(false, new SolidColorBrush(Colors.Lavender));
                        
                        
                    }
                    if (toestel.VerwijderBijVolgendeVrijStelling)
                    {
                        label.StelStatusIn(false, new SolidColorBrush(Colors.DarkKhaki));
                    }

                    optieBox.selectieLijst.Children.Add(label);
                }
                rezerveerOverzicht.Children.Add(optieBox);
            }
        }
        
        private void kiesUurVanRezervering(object? sender, int geselecteerdeToestelId)
        {

            Toestel toestel = _controller.GeefToeselOpId(geselecteerdeToestelId);

            tijdslotKiezerPanel.Child = null;
            tijdslotKiezerPanel.Visibility = Visibility.Visible;
            TijdslotKiezer tijdslot = new TijdslotKiezer(toestel.ToString(), toestel.Id);
            
            tijdslot.SluitClick += SluitTijdSlotKiezer;
            tijdslot.RezerveerClick += Rezerveer;


            foreach (int uur in huidigeRezervatiesVanDeGeselecteerdeDag.Keys)
            { 
                foreach(int toestelId in huidigeRezervatiesVanDeGeselecteerdeDag[uur].Keys)
                {
                    if(toestelId == geselecteerdeToestelId)
                    {
                        if(DateTime.Now.Hour > uur)
                        {
                            SolidColorBrush bgColor = new SolidColorBrush(Colors.Transparent);
                            tijdslot.VoegTijdslotToe(uur, false, bgColor);
                        }
                        else
                        {
                            Reservatie reservatie = huidigeRezervatiesVanDeGeselecteerdeDag[uur][toestelId];
                            if (reservatie is not null)
                            {
                                SolidColorBrush bgColor = new SolidColorBrush(Colors.LightSalmon);

                                if (_controller.IsDitDeGebruiker(reservatie.Gebruiker.Id))
                                {
                                    bgColor = new SolidColorBrush(Colors.LightGreen);
                                }
                                tijdslot.VoegTijdslotToe(uur, false, bgColor);

                            }
                            else
                            {
                                SolidColorBrush bgColor = new SolidColorBrush(Colors.Green);

                                if (toestel.OnderhoudBijVolgendeVrijStelling)
                                {
                                    bgColor = new SolidColorBrush(Colors.LightYellow);
                                    tijdslot.VoegTijdslotToe(uur, false, bgColor);
                                }
                                else
                                {
                                    tijdslot.VoegTijdslotToe(uur, true, bgColor);

                                }
                            }
                        }
                        
                    }
                    
                
                }
            }
           
            tijdslotKiezerPanel.Child = tijdslot;

        }

        private void Rezerveer(object? sender, Dictionary<int, List<int>> e)
        {
            int toestelId = e.Keys.First();
            string resonseBericht = _controller.MaakReservatie(_geselecteerdeDatum, toestelId, e[toestelId]);
            if (resonseBericht != null)
            {
                MessageBox.Show(resonseBericht, "Opgelet", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            tijdslotKiezerPanel.Visibility = Visibility.Collapsed;
            ToonDag(_geselecteerdeDatum);
        }

        private void SluitTijdSlotKiezer(object? sender, RoutedEventArgs e)
        {
            tijdslotKiezerPanel.Visibility = Visibility.Collapsed;
        }

       

    }
}
