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

namespace FitnessCentra.PresentationWPF.Components
{
    /// <summary>
    /// Interaction logic for Callender.xaml
    /// </summary>
    public partial class Callender : UserControl
    {
        public event EventHandler<DateTime> DagClickHandler;
        public Callender()
        {
            InitializeComponent();
        }

        private void CalendarDayButton_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DependencyObject originalSource = e.OriginalSource as DependencyObject;
            CalendarDayButton geselecteerdeDag = VindDeParentVan<CalendarDayButton>(originalSource);
            DateTime geselecteerdeDatum = (DateTime)geselecteerdeDag.DataContext;
            DagClickHandler?.Invoke(this, geselecteerdeDatum);
        }

        private T VindDeParentVan<T>(DependencyObject? source) where T : DependencyObject
        {
            T ret = default(T);
            DependencyObject parent = VisualTreeHelper.GetParent(source);

            if (parent != null)
            {
                ret = parent as T ?? VindDeParentVan<T>(parent) as T;
            }
            return ret;
        }
    }
}
