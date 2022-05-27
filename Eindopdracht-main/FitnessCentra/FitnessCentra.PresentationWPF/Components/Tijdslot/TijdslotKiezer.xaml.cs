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

namespace FitnessCentra.PresentationWPF.Components.Tijdslot
{

    public partial class TijdslotKiezer : UserControl
    {
        public event EventHandler<RoutedEventArgs> SluitClick;
        public event EventHandler<Dictionary<int, List<int>>> RezerveerClick;

        private SolidColorBrush _backgroundColor = new SolidColorBrush(Colors.Green);

        public string test
        {
            get { return (string)GetValue(testProperty); }
            set { SetValue(testProperty, value); }
        }

        // Using a DependencyProperty as the backing store for test.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty testProperty =
            DependencyProperty.Register("test", typeof(string), typeof(TijdslotKiezer), new PropertyMetadata(null));



        public int ToestelId
        {
            get { return (int)GetValue(ToestelIdProperty); }
            set { SetValue(ToestelIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ToestelId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ToestelIdProperty =
            DependencyProperty.Register("ToestelId", typeof(int), typeof(TijdslotKiezer), new PropertyMetadata(null));



        public TijdslotKiezer(string titel, int toestelId, int aantalSloten, int startUur)
        {
            InitializeComponent();

            GenereerTijdSloten(aantalSloten, startUur);
            ToestelId = toestelId;
            test = titel;

        }
        public TijdslotKiezer(string titel, int toestelId)
        {
            test = titel;
            ToestelId = toestelId;
            InitializeComponent();
            

        }

        public void GenereerTijdSloten(int aantalSloten, int startUur)
        {
            int huidigeUur = startUur;
            for (int i = 0; i < aantalSloten; i++)
            {
                Slot slot = new Slot($"{huidigeUur.ToString()}u");
                mainGrid.Children.Add(slot);
                huidigeUur++;
            }
        }

        public void VoegTijdslotToe(int uur, bool isBeshikbaar, SolidColorBrush activeKleur = null)
        {
            Slot slot = new Slot($"{uur.ToString()}u", isBeshikbaar, activeKleur);
            mainGrid.Children.Add(slot);
        }

        private void Rezerveer_Click(object sender, RoutedEventArgs e)
        {
            List<int> uren = new List<int>();
            int toestelId = int.Parse(titel.Content.ToString().Split(" ")[2]);
            var i = mainGrid.Children;
            int aantalUur = 0;
            foreach(Slot slot in i)
            {
                if (slot.IsGeselecteer)
                {
                    string uur = slot.Uur.Replace("u", "");
                    uren.Add(int.Parse(uur));
                }
            }
            RezerveerClick?.Invoke(this, new Dictionary<int, List<int>>
            {
                {toestelId, uren},
            });
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            SluitClick?.Invoke(this, e);

        }
    }
}