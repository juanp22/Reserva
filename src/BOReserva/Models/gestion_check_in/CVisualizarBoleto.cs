﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_check_in
{
    public class CVisualizarBoleto
    {
        public String _origen { get; set; }
        public String _destino { get; set; }
        public String _fechaDespegueIda { get; set; }
        public String _fechaDespegueVuelta { get; set; }
        public String _fechaAterrizajeIda { get; set; }
        public String _fechaAterrizajeVuelta { get; set; }
        public String _horaDespegueIda { get; set; }
        public String _horaDespegueVuelta { get; set; }
        public String _horaAterrizajeIda { get; set; }
        public String _horaAterrizajeVuelta { get; set; }
        public double _monto { get; set; }
        public String _tipoBoleto { get; set; }
        public String _nombre { get; set; }
        public String _apellido { get; set; }
        public int _pasaporte { get; set; }
        public String _correo { get; set; }

    }
}