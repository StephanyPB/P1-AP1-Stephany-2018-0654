using P1_AP1_Stephany_2018_0654.BLL;
using P1_AP1_Stephany_2018_0654.Entidades;
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

namespace P1_AP1_Stephany_2018_0654.UI
{
    /// <summary>
    /// Interaction logic for cAportes.xaml
    /// </summary>
    public partial class cAportes : Window
    {
        public cAportes()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Aportes>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //Persona
                        listado = AportesBLL.GetList(a => a.persona.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;

                    case 1: //Concepto                       
                        listado = AportesBLL.GetList(a => a.concepto.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;
                }
            }
            else
            {
                listado = AportesBLL.GetList(c => true);
            }

            if (DesdeDataPicker.SelectedDate != null)
                listado = listado.Where(c => c.fecha.Date >= DesdeDataPicker.SelectedDate).ToList();

            if (HastaDatePicker.SelectedDate != null)
                listado = listado.Where(c => c.fecha.Date <= HastaDatePicker.SelectedDate).ToList();

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;

            MontoTextBox.Text = listado.Sum(x => x.monto).ToString();
            ConteoTextBox.Text = listado.Count().ToString();
        }
    }
}
