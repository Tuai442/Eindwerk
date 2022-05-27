using Fitness.Domain;
using Fitness.Domain.Models.Gebruikers;
using FitnessCentra.PresentationWPF.Components.Labels;
using FitnessCentra.PresentationWPF.Components.Optiebox;
using FitnessCentra.PresentationWPF.Windows;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace FitnessCentra.PresentationWPF.Components.Panelen
{
    /// <summary>
    /// Interaction logic for BeheerdersPaneel.xaml
    /// </summary>
    public partial class BeheerdersPaneel : UserControl
    {
        private DomainController _controller;
        private int _geselecteerdeToestelId;
        private int _geselecteerdeToestelTypeIndex;
        private SolidColorBrush _knopIsIngedrukt = new SolidColorBrush(Colors.DarkCyan);
        private SolidColorBrush _knopIsNietIngedrukt = new SolidColorBrush(Colors.AliceBlue);

        private bool _onderhoudBtnActief = false;
        private bool _verwijderBtnActief = false;

        public SolidColorBrush VoegToestelBgColor
        {
            get { return (SolidColorBrush)GetValue(VoegToestelBgColorProperty); }
            set { SetValue(VoegToestelBgColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for VoegToestelBgColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VoegToestelBgColorProperty =
            DependencyProperty.Register("VoegToestelBgColor", typeof(SolidColorBrush), typeof(BeheerdersPaneel), new PropertyMetadata(null));


        public SolidColorBrush OnderhoudBtnBgColor
        {
            get { return (SolidColorBrush)GetValue(OnderhoudBtnBgColorProperty); }
            set { SetValue(OnderhoudBtnBgColorProperty, value); }
        }
        // Using a DependencyProperty as the backing store for OnderhoudBtnBgColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OnderhoudBtnBgColorProperty =
            DependencyProperty.Register("OnderhoudBtnBgColor", typeof(SolidColorBrush), typeof(BeheerdersPaneel), new PropertyMetadata(new SolidColorBrush(Colors.AliceBlue)));

        public SolidColorBrush VerwijderBtnBgColor
        {
            get { return (SolidColorBrush)GetValue(VerwijderBtnBgColorProperty); }
            set { SetValue(VerwijderBtnBgColorProperty, value); }
        }
        // Using a DependencyProperty as the backing store for VerwijderBtnBgColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VerwijderBtnBgColorProperty =
            DependencyProperty.Register("VerwijderBtnBgColor", typeof(SolidColorBrush), typeof(BeheerdersPaneel), new PropertyMetadata(new SolidColorBrush(Colors.AliceBlue)));

        public BeheerdersPaneel(DomainController controller)
        {
            InitializeComponent();
            _controller = controller;
            GenereerMenu();
        }

        public void GenereerMenu()
        {
            menuPaneel.Children.Clear();
            List<string> toestelTypes = _controller.GeefAlleToestelTypes();
            //List<List<string>> klanten = _controller.GeefAlleGebruikers();

            OptieBox2 optieBox = new OptieBox2();
            optieBox.Titel = "Soorten toestellen";
            int teller = 0;
            foreach (string type in toestelTypes)
            {
                Label1 label = new Label1();
                label.LText = type.ToString();
                label.Id = teller;
                label.LabelClick += TypeToestelGekozen;
                optieBox.selectieLijst.Children.Add(label);
                teller++;
            }

            menuPaneel.Children.Add(optieBox);
        }

        private void TypeToestelGekozen(object? sender, int typeIndex)
        {
            _geselecteerdeToestelTypeIndex = typeIndex;
            GenereerToestellenMenu(typeIndex);
        }

        public void GenereerToestellenMenu(int typeIndex)
        {
            hoofding.Children.Clear();
            content.Children.Clear();
            List<string> toestelTypes = _controller.GeefAlleToestelTypes();
            List<Toestel> alleToestellen = _controller.GeefAlleToestellen();
            string type = toestelTypes[typeIndex];
            Label label = new Label();
            label.Content = type.ToString();
            label.FontSize = 30;

            foreach (Toestel toestel in alleToestellen)
            {
                if (toestel.Type == type)
                {
                    GrootLabel grootLabel = new GrootLabel();
                    grootLabel.LText = type.ToString();
                    grootLabel.RText = toestel.Id.ToString();
                    grootLabel.Id = toestel.Id;
                    if (toestel.OnderhoudBijVolgendeVrijStelling)
                    {
                        grootLabel.VoegTextToe($"Moet Onderhouden worden bij de volgende vrijstelling.");
                    }
                    if (toestel.VerwijderBijVolgendeVrijStelling)
                    {
                        grootLabel.VoegTextToe($"Toestel wordt verwijderd bij de volgende vrijstelling");
                    }
                    grootLabel.LabelClick += Toestel_Click;

                    content.Children.Add(grootLabel);
                }
            }
            hoofding.Children.Add(label);
        }

        private void Toestel_Click(object? sender, int id)
        {
            _geselecteerdeToestelId = id;
            if (_onderhoudBtnActief)
            {
                string datumVanOnderhoud = _controller.OnderhoudToestelBijVolgendeVrijstelling(id);
                if (datumVanOnderhoud != null)
                {
                    MessageBox.Show($"De laatste rezervering is op {datumVanOnderhoud}, vanaf dan gaat het toestel in onderhoud.");
                }
            }
            else if (_verwijderBtnActief)
            {
                string datumVanVerwijdering = _controller.VerwijderToestel(id);
                if(datumVanVerwijdering != null)
                {
                    MessageBox.Show($"De laatste rezervering is op {datumVanVerwijdering}, achter deze datum wordt het toestel verwijderd.");
                }
            }
            GenereerMenu();
            GenereerToestellenMenu(_geselecteerdeToestelTypeIndex);
            
        }

        private void OnderhoudToestel_Click(object? sender, RoutedEventArgs e)
        {
            OnderhoudBtnBgColor = _knopIsIngedrukt;
            _onderhoudBtnActief = true;

            VerwijderBtnBgColor = _knopIsNietIngedrukt;
            _verwijderBtnActief = false;

            VoegToestelBgColor = _knopIsNietIngedrukt;
       }

        private void verwijderBtn_Click(object sender, RoutedEventArgs e)
        {
            VerwijderBtnBgColor = _knopIsIngedrukt;
            _verwijderBtnActief = true;

            OnderhoudBtnBgColor = _knopIsNietIngedrukt;
            _onderhoudBtnActief = false;

            VoegToestelBgColor = _knopIsNietIngedrukt;
        }

        private void VoegNiewToestelToe_Click(object sender, RoutedEventArgs e)
        {
            OnderhoudBtnBgColor = _knopIsNietIngedrukt;
            _onderhoudBtnActief = false;

            VerwijderBtnBgColor = _knopIsNietIngedrukt;
            _verwijderBtnActief = false;

            VoegToestelBgColor = _knopIsIngedrukt;

            VoegToestelToeWindow voegToestelToeWindow = new VoegToestelToeWindow(_controller.GeefAlleToestelTypes());
            voegToestelToeWindow.VoegToestelToeClick += VoegToestelToeClick;
            voegToestelToeWindow.Show();
           
          
        }

        private void VoegToestelToeClick(object? sender, string toestelType)
        {
            _controller.VoegToestelToe(toestelType);
            GenereerToestellenMenu(_geselecteerdeToestelTypeIndex);
        }
    
    }
}
