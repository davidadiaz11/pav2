using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Hotel
/// </summary>
public class Hotel
{

        public int codigo { get; set; }
        
        public int capacidad { get; set; }

        public string nombre { get; set; }

        public int? destino { get; set; }

        public string destino_descripcion { get; set; }

        public Boolean aceptaMascota { get; set; }

        public int cuit { get; set; }

        public DateTime inicioActividad { get; set; }
        
	
}