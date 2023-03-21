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
    public class ViewModelCreacionCliente : INotifyPropertyChanged
    {


        public ViewModelCreacionCliente()
        {


            AbrirListaClientes();


            CrearCliente = new Command(() =>
            {


                Cliente cv = new Cliente()
                {
                    nombreCompleto = this.nombreCompleto,
                    edad = this.edad,
                    tipo = this.Tipo,                  
                };

                Console.WriteLine(cv.nombreCompleto);
                Console.WriteLine(cv.edad);
                Console.WriteLine(cv.tipo);



                //ListaClientes.Add(cv);

                /* Rutina de Serializacion (Proceso de convertir Objetos a Archivos, crear archivos) */

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "clienteregistrado.aut");

                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, cv);
                archivo.Close();

                /*Fin de Rutina de Serializacion*/

                App.Current.Properties["ClienteRegistrado"] = cv;
            });

        }

        private void AbrirListaClientes()
        {
            try
            {

                /*Proceso de Deserializacion (Ingeniera Inversa de Serializar, leer archivos) */
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "clientes.aut");
                Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);

                ListaClientes = (ObservableCollection<Cliente>)formatter.Deserialize(archivo);

                archivo.Close();

                App.Current.Properties["ListaClientes"] = ListaClientes;

            }
            catch (Exception)
            {
                ListaClientes = new ObservableCollection<Cliente>();
            }

        }

        string nombreCompleto;
        public string NombreCompleto
        {

            get => nombreCompleto;
            set
            {
                nombreCompleto = value;
                var arg = new PropertyChangedEventArgs(nameof(NombreCompleto));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        string tipo;
        public string Tipo
        {

            get => tipo;
            set
            {
                tipo = value;
                var arg = new PropertyChangedEventArgs(nameof(Tipo));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        string edad;
        public string Edad
        {

            get => edad;
            set
            {
                edad = value;
                var arg = new PropertyChangedEventArgs(nameof(Edad));
                PropertyChanged?.Invoke(this, arg);

            }
        }



        public Cliente clienteRegistrado;


        ObservableCollection<Cliente> listaClientes = new ObservableCollection<Cliente>();
        List<string> opciones = new List<string>() { "VIP", "Normal" };

      
        public ObservableCollection<Cliente> ListaClientes
        {
            get => listaClientes;
            set
            {

                listaClientes = value;
                var arg = new PropertyChangedEventArgs(nameof(ListaClientes));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Command CrearCliente { get; }
    }
}
