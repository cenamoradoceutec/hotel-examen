using hotel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xamarin.Forms;

namespace hotel.ViewModel
{
    public class ViewModelCreacionHabitacion : INotifyPropertyChanged
    {
        public ViewModelCreacionHabitacion()
        {


            //AbrirListaHabitaciones();

            CrearHabitacion = new Command(() =>
            {
                // AbrirListaHabitaciones();

                Habitacion h = new Habitacion()
                {
                    NumeroCuarto = this.NumeroHabitacion,
                    Precio = this.PrecioHabitacion,
                    CantidadCamas = this.CamasCantidad,

                };

                HabitacionNormal habitacionNormal = new HabitacionNormal
                {
                    Titulo= "Habitacion Normal 1",
                    NumeroCuarto = 101,
                    Precio = 50.00,
                    CantidadCamas = 2,
                    Ducha = "Sí",
                    Microondas = true,
                    Ventanas = true
                };

                HabitacionSuite habitacionSuite = new HabitacionSuite
                {
                    Titulo = "Habitacion Normal Suite",
                    NumeroCuarto = 101,
                    Precio = 50.00,
                    CantidadCamas = 2,
                    Cocina = true,
                    Terraza = true,
                    Jacuzzi = true
                };


                ListaHabitacionesNormal.Add(habitacionNormal);
                ListaHabitacionesSuite.Add(habitacionSuite);

                /* Rutina de Serializacion (Proceso de convertir Objetos a Archivos, crear archivos) */

                BinaryFormatter formatter = new BinaryFormatter();
                string rutaN = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "habitacionesnormal.aut");
                string rutaS = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "habitacionessuite.aut");

                using (Stream archivo = new FileStream(rutaN, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(archivo, ListaHabitacionesNormal);
                    archivo.Close();
                }
                using (Stream archivo = new FileStream(rutaS, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(archivo, ListaHabitacionesSuite);
                    archivo.Close();
                }

                /*Fin de Rutina de Serializacion*/

                App.Current.Properties["ListaHabitacionesNormal"] = ListaHabitacionesNormal;
                App.Current.Properties["ListaHabitacionesSuite"] = ListaHabitacionesSuite;

            });

        }

        private void AbrirListaHabitaciones()
        {
            try
            {

                /*Proceso de Deserializacion (Ingeniera Inversa de Serializar, leer archivos) 
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "habitaciones.aut");
                Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);

                ListaHabitaciones = (ObservableCollection<Habitacion>)formatter.Deserialize(archivo);

                archivo.Close();

                App.Current.Properties["ListaHabitaciones"] = ListaHabitaciones;
                */
            }
            catch (Exception)
            {
                ListaHabitacionesNormal = new ObservableCollection<HabitacionNormal>();
            }

        }

        ObservableCollection<HabitacionSuite> listaHabitacionesSuite = new ObservableCollection<HabitacionSuite>();
        ObservableCollection<HabitacionNormal> listaHabitacionesNomal = new ObservableCollection<HabitacionNormal>();

        public ObservableCollection<HabitacionNormal> ListaHabitacionesNormal
        {
            get => listaHabitacionesNomal;
            set
            {

                listaHabitacionesNomal = value;
                var arg = new PropertyChangedEventArgs(nameof(ListaHabitacionesNormal));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        public ObservableCollection<HabitacionSuite> ListaHabitacionesSuite
        {
            get => listaHabitacionesSuite;
            set
            {

                listaHabitacionesSuite = value;
                var arg = new PropertyChangedEventArgs(nameof(ListaHabitacionesSuite));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        string Titulo;
        public string titulo
        {

            get => Titulo;
            set
            {
                Titulo = value;
                var arg = new PropertyChangedEventArgs(nameof(Titulo));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        int NumeroCuarto;
        public int NumeroHabitacion
        {

            get => NumeroCuarto;
            set
            {
                NumeroCuarto = value;
                var arg = new PropertyChangedEventArgs(nameof(NumeroCuarto));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        double Precio;
        public double PrecioHabitacion
        {

            get => Precio;
            set
            {
                Precio = value;
                var arg = new PropertyChangedEventArgs(nameof(Precio));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        int CantidadCamas;
        public int CamasCantidad
        {

            get => CantidadCamas;
            set
            {
                CantidadCamas = value;
                var arg = new PropertyChangedEventArgs(nameof(CantidadCamas));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        string Ducha;
        public string TraeDucha
        {

            get => Ducha;
            set
            {
                Ducha = value;
                var arg = new PropertyChangedEventArgs(nameof(Ducha));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        bool Microondas;
        public bool TraeMicroondas
        {

            get => Microondas;
            set
            {
                Microondas = value;
                var arg = new PropertyChangedEventArgs(nameof(Microondas));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        bool Ventanas;
        public bool TraeVentanas
        {

            get => Ventanas;
            set
            {
                Ventanas = value;
                var arg = new PropertyChangedEventArgs(nameof(Ventanas));
                PropertyChanged?.Invoke(this, arg);

            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public Command CrearHabitacion { get; }
    
    }
}
