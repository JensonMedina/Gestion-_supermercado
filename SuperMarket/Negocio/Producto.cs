﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Producto
    {
        public int Id { get; set; }
        public string  Nombre { get; set; }
        public Categoria Categoria { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
    }
}
