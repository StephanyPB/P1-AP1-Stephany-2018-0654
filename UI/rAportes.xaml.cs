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
    /// Interaction logic for rAportes.xaml
    /// </summary>
    public partial class rAportes : Window
    {
        private Aportes Aporte;

        public rAportes()
        {
            InitializeComponent();
            Aporte = new Aportes();
            this.DataContext = this.Aporte;
        }
        private bool Validar()
        {
            bool esValido = true;

            if (PersonaTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if(ConceptoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (MontoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }
        private void Limpiar()
        {
            AportesIDTextBox.Text = string.Empty;
            FechaTextBox.SelectedDate = DateTime.Now;
            PersonaTextBox.Text = string.Empty;
            ConceptoTextBox.Text = string.Empty;
            MontoTextBox.Text = string.Empty;
            this.Aporte = new Aportes();
            DataContext = this.Aporte;
        }

        private void BuscarIDButton_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(AportesIDTextBox.Text, out int aporteID);
            var Aporte = AportesBLL.Buscar(aporteID);

            if (Aporte != null)
                this.Aporte = Aporte;
            else
            {
                this.Aporte = new Aportes();
                MessageBox.Show("Este aporte no existe.", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            this.DataContext = this.Aporte;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = AportesBLL.Guardar(this.Aporte);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccion Exitosa!", " Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida!", " Fallo", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Aportes existe = AportesBLL.Buscar(this.Aporte.aporteID);

            if (AportesBLL.Eliminar(this.Aporte.aporteID))
            {
                Limpiar();
                MessageBox.Show("Eliminado!", " Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
                MessageBox.Show("No fue posible eliminarlo!", " Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}

