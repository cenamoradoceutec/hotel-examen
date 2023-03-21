using hotel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace hotel.ViewModel
{
    public class ViewModelMainPage : INotifyPropertyChanged
    {
        public ViewModelMainPage()
        {
            AbrirListaClientes();

            // Lógica para establecer el valor de la propiedad MostrarViewCrearCliente
            if (ListaClientes.Count > 0)
            {
                Console.WriteLine("///////Lista Clientes tiene datos/////");
                MostrarViewCrearCliente = false;
            }
            else
            {
                MostrarViewCrearCliente = true;
            }
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


        ObservableCollection<Cliente> listaClientes = new ObservableCollection<Cliente>();

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

        private bool _mostrarViewCrearCliente;

        public bool MostrarViewCrearCliente
        {
            get { return _mostrarViewCrearCliente; }
            set
            {
                if (_mostrarViewCrearCliente != value)
                {
                    _mostrarViewCrearCliente = value;
                    OnPropertyChanged(nameof(MostrarViewCrearCliente));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
