using System;
using System.Collections.Generic;
using System.Text;

namespace hotel.Models
{
    public class Hotel
    {
        public List<Habitacion> Habitaciones { get; set; }
        public List<Registro> Registros { get; set; }

        public Hotel()
        {
            Habitaciones = new List<Habitacion>();
            Registros = new List<Registro>();
        }

        public void RegistrarHabitacion(Habitacion habitacion)
        {
            Habitaciones.Add(habitacion);
        }

        public void RegistrarCliente(Cliente cliente, HabitacionNormal habitacion)
        {
            cliente.habitacionesRegistradas.Add(habitacion);
            Registros.Add(new Registro(DateTime.Now, cliente, habitacion));
        }
    }
}
