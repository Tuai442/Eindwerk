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

namespace FitnessCentra.PresentationWPF.Components
{
    public partial class Label1 : UserControl
    {
        public EventHandler<int> LabelClick;

        private SolidColorBrush STATUS_AAN = new SolidColorBrush(Colors.LightGreen);
        private SolidColorBrush STATUS_UIT = new SolidColorBrush(Colors.Red);
        private bool _isActief = true;
        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(int), typeof(Label1), new PropertyMetadata(null));

        public string LText
        {
            get { return (string)GetValue(LTextProperty); }
            set { SetValue(LTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LTextProperty =
            DependencyProperty.Register("LText", typeof(string), typeof(Label1), new PropertyMetadata(null));

        public string RText
        {
            get { return (string)GetValue(RTextProperty); }
            set { SetValue(RTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RTextProperty =
            DependencyProperty.Register("RText", typeof(string), typeof(Label1), new PropertyMetadata(null));


        public SolidColorBrush BackgroundColor
        {
            get { return (SolidColorBrush)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BackgroundColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackgroundColorProperty =
            DependencyProperty.Register("BackgroundColor", typeof(SolidColorBrush), typeof(Label1), new PropertyMetadata(new SolidColorBrush(Colors.LightGreen)));


        
        public Label1()
        {
            InitializeComponent();
            StelStatusIn(true);
        }

        public void StelStatusIn(bool actief, SolidColorBrush statusKleur = null)
        {
            if (actief)
            {
                _isActief = true;
                BackgroundColor = STATUS_AAN;
            }
            else
            {
                _isActief = false;
                BackgroundColor = STATUS_UIT;

            }
            if(statusKleur != null)
            {
                Background = statusKleur;
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_isActief)
            {
                LabelClick?.Invoke(this, this.Id);
            }
        }

        public void StelAfmetingenIn(int breedte, int hoogte)
        {
            this.Width = breedte;
            this.Height = hoogte;
        }
    }
}
