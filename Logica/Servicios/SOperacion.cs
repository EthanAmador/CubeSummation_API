using Cube_Summation.Entity;
using Cube_Summation.Entity.Enum;
using Cube_Summation.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube_Summation.Services.Servicios
{
    public class SOperacion : IOperacion
    {
        private readonly ILeerTexto _leerTexto;
        private readonly ICube_Summation _realizarOperaciones;
        public SOperacion()
        {
            _leerTexto = new SLeerTexto();
            _realizarOperaciones = SCube_Summation.Instancia;
        }

        public List<string> Realizar(string p_texto)
        {
            List<string> _lstResult = new List<string>(); 

            _leerTexto.RealizarLectura(p_texto: p_texto);
            List<Operacion> _lst = _leerTexto.LstOperaciones;

            int? _numeroCasos = (from a in _lst
                                 where !(a.NumeroCasos is null)
                                 select a.NumeroCasos).FirstOrDefault();

            _realizarOperaciones.numero_casos = (int)_numeroCasos;

            foreach (var item in _lst)
            {
                long _value1 = 0, _value2 = 0;

                if (item.Comando == Comandos.INVALID &&
                   !(item.TamañoMatrix is null) &&
                   !(item.NumeroOperaciones is null))
                {
                    _realizarOperaciones.tamano_matrix = (int)item.TamañoMatrix;
                    _realizarOperaciones.numero_operaciones = (int)item.NumeroOperaciones;
                    _realizarOperaciones.init();
                }
                else if (item.Comando == Comandos.QUERY)
                {
                    int
                        _x0 = item.Query.x0,
                        _y0 = item.Query.y0,
                        _z0 = item.Query.z0,
                        _x1 = item.Query.x1,
                        _y1 = item.Query.y1,
                        _z1 = item.Query.z1;

                    _value1 = _realizarOperaciones.calcularSuma(_x1, _y1, _z1) - _realizarOperaciones.calcularSuma(_x0 - 1, _y1, _z1)
                            - _realizarOperaciones.calcularSuma(_x1, _y0 - 1, _z1) + _realizarOperaciones.calcularSuma(_x0 - 1, _y0 - 1, _z1);

                    _value2 = _realizarOperaciones.calcularSuma(_x1, _y1, _z0 - 1) - _realizarOperaciones.calcularSuma(_x0 - 1, _y1, _z0 - 1)
                            - _realizarOperaciones.calcularSuma(_x1, _y0 - 1, _z0 - 1) + _realizarOperaciones.calcularSuma(_x0 - 1, _y0 - 1, _z0 - 1);

                    _lstResult.Add($"Restultado OP: {_value1 - _value2}"); 
                }
                else if (item.Comando == Comandos.UPDATE)
                {
                    int
                        _x = item.Update.x,
                        _y = item.Update.y,
                        _z = item.Update.z,
                        _x0 = _x,
                        _y0 = _y,
                        _z0 = _z;

                    long _valor = item.Update.valor;

                    //_value1 = _realizarOperaciones.calcularSuma(_x, _y, _z) - _realizarOperaciones.calcularSuma(_x0 - 1, _y, _z)
                    //        - _realizarOperaciones.calcularSuma(_x, _y0 - 1, _z) + _realizarOperaciones.calcularSuma(_x0 - 1, _y0 - 1, _z);

                    //_value2 = _realizarOperaciones.calcularSuma(_x, _y, _z0 - 1) - _realizarOperaciones.calcularSuma(_x0 - 1, _y, _z0 - 1)
                    //        - _realizarOperaciones.calcularSuma(_x, _y0 - 1, _z0 - 1) + _realizarOperaciones.calcularSuma(_x0 - 1, _y0 - 1, _z0 - 1);

                    _realizarOperaciones.realizarModifcacion(_x, _y, _z, _valor);
                }
            }

            return _lstResult; 
        }
    }
}
