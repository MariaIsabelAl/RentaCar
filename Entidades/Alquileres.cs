using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace Renta_Car.Entidades
{
    public class Alquileres
    {
        [Key]
        public int IdAlquilar { get; set; }
        public string Matricula { get; set; }
        public DateTime FechaEntrada { get; set; }
        public decimal Duracion { get; set; }
        public string NombreCliente { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Observacion { get; set; }
        public decimal PrecioDiario { get; set; }
        public decimal Total { get; set; }

        public Alquileres()
        {
            IdAlquilar = 0;
            Matricula = string.Empty;
            FechaEntrada = DateTime.Now;
            Duracion = 0;
            NombreCliente = string.Empty;
            Cedula = string.Empty;
            Telefono = string.Empty;
            Observacion = string.Empty;
            PrecioDiario = 0;
            Total = 0;
        }
    }
}
