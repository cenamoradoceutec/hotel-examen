using hotel.Models;
using hotel.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Numerics;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace hotel.ViewModel
{
    public class ViewModelHabitacion : ContentPage, INotifyPropertyChanged
    {

        public ViewModelHabitacion()
        {
            Console.WriteLine("///-------------Empieza la condicion---------///");
            Console.WriteLine("////////////////////////////////////////////////");

            AbrirListaHabitaciones();
            VerClienteRegistrado();

            nombreCliente = clienteRegistrado.nombreCompleto;

            if (ListaHabitacionesNormal.Count > 0)
            {
                Console.WriteLine("-------------Variable con Datos---------");
                Console.WriteLine("-------------Se leeran datos---------");
                Console.WriteLine(ListaHabitacionesNormal);                
            }else
            {
                Console.WriteLine("-------------Variable Limpia---------");
                Console.WriteLine("-------------Se creo Data!---------");
               CreateData();
            }            
        }
      
        
        private void CreateData()
        {
            HabitacionNormal habitacionN1 = new HabitacionNormal
            {
                Titulo = "Habitacion Normal Sencilla",
                Imagen = "https://www.hotelharare.mx/wp-content/uploads/2019/08/Hotel-Harare-Ciudad-de-Mexico-15.jpg",
                NumeroCuarto = 201,
                Precio = 100.50,
                CantidadCamas = 1,
                Ducha = "Sí",
                Microondas = false,
                Ventanas = false
            };

            HabitacionNormal habitacionN2 = new HabitacionNormal
            {
                Titulo = "Habitacion Normal 2",
                Imagen = "https://www.elmueble.com/medio/2022/11/06/dormitorio-rustico-con-vigas-de-madera-y-pared-de-madera-00557319_00000000_22116180616_900x900.jpg",
                NumeroCuarto = 301,
                Precio = 420.00,
                CantidadCamas = 2,
                Ducha = "Sí",
                Microondas = true,
                Ventanas = true
            };
            HabitacionNormal habitacionN3 = new HabitacionNormal
            {
                Titulo = "Habitacion Suite 2",
                Imagen = "https://www.hotelharare.mx/wp-content/uploads/2019/08/Hotel-Harare-Ciudad-de-Mexico-15.jpg",
                NumeroCuarto = 402,
                Precio = 620.00,
                CantidadCamas = 3,
                Ducha = "Sí",
                Microondas = true,
                Ventanas = true
            };

            ListaHabitacionesNormal.Add(habitacionN1);
            ListaHabitacionesNormal.Add(habitacionN2);
            ListaHabitacionesNormal.Add(habitacionN3);

            GuardarDatos();

            App.Current.Properties["ListaHabitacionesNormal"] = ListaHabitacionesNormal;

            //App.Current.Properties["ListaHabitacionesNormal"] = habitacionNormal;
        }

        private void GuardarDatos()
        {
            /* Rutina de Serializacion (Proceso de convertir Objetos a Archivos, crear archivos) */

            BinaryFormatter formatter = new BinaryFormatter();
            string rutaN = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "habitacionesnormal.aut");
      
            using (Stream archivo = new FileStream(rutaN, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(archivo, ListaHabitacionesNormal);
                archivo.Close();
            }

            /*Fin de Rutina de Serializacion*/
        }
        private void AbrirListaHabitaciones()
        {
            try
            {

                /*Proceso de Deserializacion (Ingeniera Inversa de Serializar, leer archivos) */
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "habitacionesnormal.aut");
                Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);

                ListaHabitacionesNormal = (ObservableCollection<HabitacionNormal>)formatter.Deserialize(archivo);

                archivo.Close();

                 App.Current.Properties["ListaHabitacionesNormal"] = ListaHabitacionesNormal;
                
                
            }
            catch (Exception)
            {
                listaHabitacionesNormal = new ObservableCollection<HabitacionNormal>();
            }

        }

        private void VerClienteRegistrado()
        {
            try
            {

                /*Proceso de Deserializacion (Ingeniera Inversa de Serializar, leer archivos) */
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "clienteregistrado.aut");
                Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);

                clienteRegistrado = (Cliente)formatter.Deserialize(archivo);

                archivo.Close();

                App.Current.Properties["ClienteRegistrado"] = clienteRegistrado;

            }
            catch (Exception)
            {
                clienteRegistrado = new Cliente();
            }

        }

        public Cliente clienteRegistrado;
        ObservableCollection<HabitacionNormal> listaHabitacionesNormal = new ObservableCollection<HabitacionNormal>();

        public ObservableCollection<HabitacionNormal> ListaHabitacionesNormal
        {
            get => listaHabitacionesNormal;
            set
            {

                listaHabitacionesNormal = value;
                var arg = new PropertyChangedEventArgs(nameof(ListaHabitacionesNormal));
                PropertyChanged?.Invoke(this, arg);

            }
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

        string Imagen;
        public string imagen
        {

            get => Imagen;
            set
            {
                Imagen = value;
                var arg = new PropertyChangedEventArgs(nameof(Imagen));
                PropertyChanged?.Invoke(this, arg);

            }
        }


        int NumeroCuarto;
        public int numerocuarto
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
        public double precio
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
        public int cantidadcamas
        {

            get => CantidadCamas;
            set
            {
                CantidadCamas = value;
                var arg = new PropertyChangedEventArgs(nameof(CantidadCamas));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Command AbrirOtraPaginaCommand { get; set; }

        private async void AbrirOtraPagina()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ViewHabitacionDetalle());
        }

    }
}
