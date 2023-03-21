using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace hotel.Models
{
    [Serializable]

    public class Cliente
    {
        public string nombreCompleto { get; set; }
        public string tipo { get; set; }
        public string edad { get; set; }
        public ObservableCollection<HabitacionNormal> habitacionesRegistradas { get; set; } = new ObservableCollection<HabitacionNormal>();

    }

  

    
}
