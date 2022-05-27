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
using System.Windows.Shapes;

namespace FitnessCentra.PresentationWPF.Windows
{
    /// <summary>
    /// Interaction logic for VoegToestelToeWindow.xaml
    /// </summary>
    public partial class VoegToestelToeWindow : Window
    {
        private List<string> _toestelTypes;

        public EventHandler<string> VoegToestelToeClick;
        public VoegToestelToeWindow(List<string> toestelTypes)
        {
            _toestelTypes = toestelTypes;
            InitializeComponent();
            VoegTypesToeAanCombobox(_toestelTypes);
        }

        private void VoegTypesToeAanCombobox(List<string> toestelTypes)
        {
            foreach(string type in toestelTypes)
            {
                typeToestellenCombobox.Items.Add(type.ToString());
            }
        }

        private void VoegToestelToe_Click(object sender, RoutedEventArgs e)
        {
            string toestelType = typeToestellenCombobox.Text;
            if(toestelType != "")
            {
                VoegToestelToeClick?.Invoke(this, toestelType);
                this.Close();
            }
        }

        
    }
}
