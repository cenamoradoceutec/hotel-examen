using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace hotel.Models
{
    [Serializable]
    public class HabitacionNormal : Habitacion
    {
        public string Ducha { get; set; }
        public bool Microondas { get; set; }
        public bool Ventanas { get; set; }

        public override string GetTipo()
        {
            return "Habitación Normal";
        }
    }
}
