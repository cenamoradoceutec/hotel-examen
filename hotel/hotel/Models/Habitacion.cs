using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace hotel.Models
{
    [Serializable]
    public class Habitacion : INotifyPropertyChanged
    {
        public string Titulo { get; set; }
        public int NumeroCuarto { get; set; }
        public double Precio { get; set; }
        public int CantidadCamas { get; set; }
        public string Imagen { get; set; }

        public virtual string GetTipo()
        {
            return "Habitación";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
