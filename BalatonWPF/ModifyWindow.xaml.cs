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

namespace BalatonWPF
{
    /// <summary>
    /// Interaction logic for ModifyWindow.xaml
    /// </summary>
    public partial class ModifyWindow : Window
    {
        public Haz ModositottHaz { get; private set; }

        public ModifyWindow()
        {
            InitializeComponent();
        }

        public ModifyWindow(Haz haz)
        {
            InitializeComponent();
            tbxTaxBracket.Text = haz.TelekAdoSzam.ToString();
            tbxStreet.Text = haz.UtcaNeve;
            tbxTaxNumber.Text = haz.Hazszam;
            tbxArea.Text = haz.Terulet.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ModositottHaz = new Haz(
                int.Parse(tbxTaxBracket.Text), 
                tbxStreet.Text, 
                tbxTaxNumber.Text, 
                "A",
                int.Parse(tbxArea.Text));
            DialogResult = true;
            Close();
        }
    }
}
