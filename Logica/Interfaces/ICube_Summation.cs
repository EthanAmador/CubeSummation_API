using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube_Summation.Services.Interfaces
{
    internal interface ICube_Summation
    {
        int numero_casos { get; set; }
        long tamano_matrix { get; set; }
        long numero_operaciones { get; set; }

        long calcularSuma(long p_x, long p_y, long p_z);
        void realizarModifcacion(long p_x, long p_y, long p_z, long p_valor);
        void init(); 
        
    }
}
