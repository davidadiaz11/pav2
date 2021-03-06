﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Hotel
/// </summary>
public class Hotel
{

    public int id { get; set; }

    public int capacidad { get; set; }

    public string descripcion { get; set; }

    public int? destino { get; set; }

    public string destino_descripcion { get; set; }

    public long cuit { get; set; }

    public Boolean aceptaMascota { get; set; }

    public bool eliminado { get; set; }

    public DateTime inicioActividad { get; set; }
}