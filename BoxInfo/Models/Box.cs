using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoxInfo.Models
{
    public class Box
    {
        public string Codbar { get; set; }
        public DateTime FechaProduccion { get; set; }
        public int Turno { get; set; }
        public int NroPlan { get; set; }
        public string NombrePlan { get; set; }
    }
}
