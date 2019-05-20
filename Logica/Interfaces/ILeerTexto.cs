using Cube_Summation.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube_Summation.Services.Interfaces
{
    internal interface ILeerTexto
    {
        List<Operacion> LstOperaciones { get; }
        void RealizarLectura(string p_texto);
    }
}
