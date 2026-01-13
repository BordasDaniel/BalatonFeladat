using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.IO;

namespace BalatonWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static ObservableCollection<Haz> hazak = new ObservableCollection<Haz>();

        public MainWindow()
        {
            InitializeComponent();
            Beolvas();
            telkekDataGrid.ItemsSource = hazak;
        }

        public static void SetModify(Haz haz, int index)
        {
            hazak[index] = haz;
        }

        private void Beolvas()
        {
            try
            {
                using (StreamReader sr = new StreamReader("utca.txt"))
                {
                    sr.ReadLine();

                    while (!sr.EndOfStream)
                    {
                        string sor = sr.ReadLine();
                        if (!string.IsNullOrWhiteSpace(sor))
                        {
                            hazak.Add(new Haz(sor));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba a fájl beolvasásakor: {ex.Message}", "Hiba", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ModositButton_Click(object sender, RoutedEventArgs e)
        {
            if (telkekDataGrid.SelectedItem is Haz kivalasztottHaz)
            {
                ComboBoxItem kivalasztottItem = (ComboBoxItem)adoSavComboBox.SelectedItem;
                string ujAdoSav = kivalasztottItem.Content.ToString();

                kivalasztottHaz.Adosav = ujAdoSav;

                telkekDataGrid.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Kérem válasszon ki egy telket a módosításhoz!", "Figyelmeztetés",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void MentesButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("modositottadok.txt"))
                {
                    sw.WriteLine("800 600 100");

                    foreach (var haz in hazak)
                    {
                        sw.WriteLine($"{haz.TelekAdoSzam} {haz.UtcaNeve} {haz.Hazszam} {haz.Adosav} {haz.Terulet}");
                    }
                }

                MessageBox.Show("Sikeres mentés!", "Információ", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            ModifyWindow modifyWindow = new(hazak[telkekDataGrid.SelectedIndex]);
            if (modifyWindow.ShowDialog() == true)
            {
                int index = telkekDataGrid.SelectedIndex;
                Haz haz = modifyWindow.ModositottHaz;
                SetModify(haz, index);
                telkekDataGrid.Items.Refresh();
            }
        }
    }
}