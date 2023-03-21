using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace hotel.Models
{
    [Serializable]
    public class HabitacionSuite : Habitacion
    {
        public bool Cocina { get; set; }
        public bool Terraza { get; set; }
        public bool Jacuzzi { get; set; }

        public override string GetTipo()
        {
            return "Habitación Suite";
        }
    }
}
