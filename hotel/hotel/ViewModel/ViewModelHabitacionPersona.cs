using hotel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xamarin.Forms;

namespace hotel.ViewModel
{
    public class ViewModelHabitacionPersona : INotifyPropertyChanged
    {
      
        public ViewModelHabitacionPersona()
        {
            try
            {
                listaHabitacionNormal = App.Current.Properties["ListaHabitacionesNormal"] as ObservableCollection<HabitacionNormal>;
                clienteRegistrado = App.Current.Properties["ClienteRegistrado"] as Cliente;

                nombreCliente = clienteRegistrado.nombreCompleto;
                edadCliente = clienteRegistrado.edad;
                tipoCliente = clienteRegistrado.tipo;
                //listaHabitacionesRegistradas = clienteRegistrado.habitacionesRegistradas;
            }
            catch (Exception ex)
            {
            }

            AsignarHabitacion = new Command(() => {
                clienteRegistrado.habitacionesRegistradas.Add(habitacionSeleccionada);
            });

            MostrarPerfil = new Command(() => {
                clienteRegistrado = App.Current.Properties["ClienteRegistrado"] as Cliente;
                Console.WriteLine("*****Cliente Registrado******");
                Console.WriteLine(clienteRegistrado.nombreCompleto);
                Console.WriteLine(clienteRegistrado.habitacionesRegistradas);
            });
        }


        string nombreCliente;
        public string NombreCliente
        {

            get => nombreCliente;
            set
            {
                nombreCliente = value;
                var arg = new PropertyChangedEventArgs(nameof(NombreCliente));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        string edadCliente;
        public string EdadCliente
        {

            get => edadCliente;
            set
            {
                edadCliente = value;
                var arg = new PropertyChangedEventArgs(nameof(EdadCliente));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        string tipoCliente;
        public string TipoCliente
        {

            get => tipoCliente;
            set
            {
                tipoCliente = value;
                var arg = new PropertyChangedEventArgs(nameof(TipoCliente));
                PropertyChanged?.Invoke(this, arg);
            }
        }


        Cliente clienteRegistrado;
        public Cliente ClienteRegistrado
        {
            get => clienteRegistrado;
            set
            {

                clienteRegistrado = value;
                var arg = new PropertyChangedEventArgs(nameof(ClienteRegistrado));
                PropertyChanged?.Invoke(this, arg);

            }

        }

        HabitacionNormal habitacionSeleccionada = new HabitacionNormal();
        public HabitacionNormal HabitacionSeleccionada
        {
            get => habitacionSeleccionada;
            set
            {

                habitacionSeleccionada = value;
                var arg = new PropertyChangedEventArgs(nameof(HabitacionSeleccionada));
                PropertyChanged?.Invoke(this, arg);

            }

        }

        public ObservableCollection<HabitacionNormal> listaHabitacionNormal { get; set; } = new ObservableCollection<HabitacionNormal>();
        public ObservableCollection<HabitacionNormal> listaHabitacionesRegistradas { get; set; } = new ObservableCollection<HabitacionNormal>();

        public event PropertyChangedEventHandler PropertyChanged;
        public Command AsignarHabitacion { get; }
        public Command MostrarPerfil { get; }


    }  

}
