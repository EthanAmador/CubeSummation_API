using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeerTexto.Interfaces
{
    public interface ILeerTexto
    {
        List<Operacion> LstOperaciones { get; }
        void RealizarLectura(string p_texto); 
    }
}
