using Cube_Summation.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube_Summation.Services.Servicios
{
    internal class SCube_Summation : ICube_Summation
    {

        #region patron singleton
        private SCube_Summation() { }

        private static SCube_Summation _instancia = null;

        public static SCube_Summation Instancia
        {
            get
            {
                if (_instancia is null)
                    _instancia = new SCube_Summation();

                return _instancia;
            }
        }
        #endregion

        private int _numeroCasos = 0;
        private long _tamanoMatrix = 0;
        private long _numeroOperaciones = 0;

        private long[,,] _matrix = null;  



        public int numero_casos { get => _numeroCasos;   set => this._numeroCasos = value;  }
        public long tamano_matrix { get => _tamanoMatrix; set => this._tamanoMatrix = value;  }
        public long numero_operaciones { get => _numeroOperaciones; set => this._numeroOperaciones = value;  }

        public long calcularSuma(long p_x, long p_y, long p_z)
        {
            long _suma = 0, _y1, _x1;

            while (p_z > 0)
            {
                _x1 = p_x;
                while (_x1 > 0)
                {
                    _y1 = p_y;
                    while (_y1 > 0)
                    {
                        _suma += _matrix[_x1 - 1, _y1 - 1, p_z - 1];
                        _y1 -= (_y1 & -_y1);
                    }
                    _x1 -= (_x1 & -_x1);
                }
                p_z -= (p_z & -p_z);
            }
            return _suma;
        }

        public void realizarModifcacion(long p_x, long p_y, long p_z, long p_valor)
        {
            long _y1, _x1;
            while (p_z <= _tamanoMatrix)
            {
                _x1 = p_x;
                while (_x1 <= _tamanoMatrix)
                {
                    _y1 = p_y;
                    while (_y1 <= _tamanoMatrix)
                    {
                        _matrix[_x1 - 1, _y1 - 1, p_z - 1] += p_valor;
                        _y1 += (_y1 & -_y1);
                    }
                    _x1 += (_x1 & -_x1);
                }
                p_z += (p_z & -p_z);
            }
        }

        public void init()
        {
            _matrix = new long[100, 100, 100];
        }
    }
}
