using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entity
{
    public class Prato
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int RestauranteId { get; set; }
        public Restaurante Restaurante { get; set; }
    }
}
