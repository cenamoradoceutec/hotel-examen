using System;
using System.Collections.Generic;
using System.Text;

namespace hotel.Models
{
    public class Registro
    {
        public DateTime Fecha { get; set; }
        public Cliente Cliente { get; set; }
        public Habitacion Habitacion { get; set; }

        public Registro(DateTime fecha, Cliente cliente, Habitacion habitacion)
        {
            Fecha = fecha;
            Cliente = cliente;
            Habitacion = habitacion;
        }
    }
}
