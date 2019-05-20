using Cube_Summation.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube_Summation.Entity
{
    public class Operacion
    {
        public int? NumeroCasos { get; set; }
        public int? TamañoMatrix { get; set; }
        public int? NumeroOperaciones { get; set; }
        public Comandos Comando { get; set; }
        public Update Update { get; set; }
        public Query Query { get; set; }

        public Operacion()
        {
            NumeroCasos = null;
            TamañoMatrix = null;
            NumeroOperaciones = null;
            Comando = Comandos.INVALID; 
            Update = new Update();
            Query = new Query(); 
        }
    }
}