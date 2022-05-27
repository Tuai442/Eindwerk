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
    /// <summary>
    /// Interaction logic for Slot.xaml
    /// </summary>
    public partial class Slot : UserControl
    {

        public string Uur
        {
            get { return (string)GetValue(UurProperty); }
            set { SetValue(UurProperty, value); }
        }
        private bool _isBeschikbaar = true;
        public bool IsGeselecteer { get; set; }


        // Using a DependencyProperty as the backing store for Uur.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UurProperty =
            DependencyProperty.Register("Uur", typeof(string), typeof(Slot), new PropertyMetadata(null));

        private SolidColorBrush BESCHIKBAAR_SLOT_KLEUR =  new SolidColorBrush(Colors.Green);
        private SolidColorBrush NIET_BESCHIKBAAR_SLOT_KLEUR = new SolidColorBrush(Colors.Red);

        private SolidColorBrush _geselecteerdKleur = new SolidColorBrush(Colors.Blue);
        private SolidColorBrush _standaardKleur = new SolidColorBrush(Colors.White);
        public Slot(string uur, bool isBeschikbaar = true, SolidColorBrush activeKleur=null)
        {
            InitializeComponent();
            IsGeselecteer = false;
            _isBeschikbaar = isBeschikbaar;
            Uur = uur;
            if (isBeschikbaar && activeKleur is null)
            {
                slot.Background = BESCHIKBAAR_SLOT_KLEUR;

            }
            else
            {
                slot.Background = NIET_BESCHIKBAAR_SLOT_KLEUR;
            }

            if(activeKleur is not null)
            {
                slot.Background = activeKleur;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_isBeschikbaar)
            {
                if (IsGeselecteer)
                {
                    Background = _standaardKleur;
                    IsGeselecteer = false;
                }
                else
                {
                    Background = _geselecteerdKleur;
                    IsGeselecteer = true;
                }
            }
           
        }
    }
}
