using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Renta_Car.Entidades
{
    public class Proveedores
    {
        [Key]
        public int IdProveedor { get; set; }
        public string Proveëdor { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public Proveedores()
        {
            IdProveedor = 0;
            Proveëdor = string.Empty;
            Direccion = string.Empty;
            Ciudad = string.Empty;
            Telefono = string.Empty;
            Email = string.Empty;
            
            
        }
    }
}
