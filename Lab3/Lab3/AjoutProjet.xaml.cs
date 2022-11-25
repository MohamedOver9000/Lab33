using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Lab3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AjoutProjet : Page
    {
        public AjoutProjet()
        {
            this.InitializeComponent();
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            Projet q = new Projet
            {
                Numero = numero.Text,
                Debut = Convert.ToDateTime(arrivalCalendarDatePicker.Date.Value.ToString("dddd dd MMMM yyyy")),
                Budget = Convert.ToInt32(budget.Text),
                Description = description.Text,
                Employe = employe.Text
            };

            GestionBD.getInstance().ajouter_projet(q);

        }
    }
}
