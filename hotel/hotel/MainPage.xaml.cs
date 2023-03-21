using hotel.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace hotel
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Creamos una nueva instancia de MainPageViewModel
            var viewModel = new ViewModelMainPage();

            // Asignamos la instancia creada al BindingContext de la vista
            this.BindingContext = viewModel;
        }
    }
}
