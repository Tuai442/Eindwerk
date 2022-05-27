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

namespace FitnessCentra.PresentationWPF.Components.Optiebox
{
    /// <summary>
    /// Interaction logic for OptieBox2.xaml
    /// </summary>
    public partial class OptieBox2 : UserControl
    {

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(OptieBox2), new PropertyMetadata(null));

        public string Uur
        {
            get { return (string)GetValue(UurProperty); }
            set { SetValue(UurProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Uur.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UurProperty =
            DependencyProperty.Register("Uur", typeof(string), typeof(OptieBox2), new PropertyMetadata(null));

        public string Titel
        {
            get { return (string)GetValue(TitelProperty); }
            set { SetValue(TitelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Titel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitelProperty =
            DependencyProperty.Register("Titel", typeof(string), typeof(OptieBox2), new PropertyMetadata(null));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(OptieBox2), new PropertyMetadata(null));

        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Label.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(OptieBox2), new PropertyMetadata(null));

        public List<string> VrijeToestellen
        {
            get { return (List<string>)GetValue(VrijeToestellenProperty); }
            set { SetValue(VrijeToestellenProperty, value); }
        }

        // Using a DependencyProperty as the backing store for VrijeToestellen.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VrijeToestellenProperty =
            DependencyProperty.Register("VrijeToestellen", typeof(List<string>), typeof(OptieBox2), new PropertyMetadata(null));

       

        public OptieBox2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (dropDownLijst.Visibility == Visibility.Visible)
            {
                Height = 60;
                dropDownLijst.Visibility = Visibility.Collapsed;
            }
            else
            {
                Height = 200;
                dropDownLijst.Visibility = Visibility.Visible;
            }
        }

    }
}
