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
    internal class SLeerTexto : ILeerTexto
    {
        public List<Operacion> LstOperaciones { get; private set; } = null;

        public void RealizarLectura(string p_texto)
        {
            if (string.IsNullOrEmpty(p_texto))
                throw new ArgumentNullException("Debe ingresar un texto valido");

            var _result = ObtenerLineas(p_texto);

            LstOperaciones = ObtenerOperaciones(_result);

        }

        private string[] ObtenerLineas(string p_texto)
        {
            string[] stringSeparators = null;
            if (p_texto.Contains("\r\n"))
                stringSeparators = new string[] { "\r\n" };
            else
                stringSeparators = new string[] { "\n" };
            return p_texto.Split(stringSeparators, StringSplitOptions.None);
        }

        private List<Operacion> ObtenerOperaciones(string[] textoSplit)
        {
            List<Operacion> lstOperacion = new List<Operacion>();

            for (int i = 0; i < textoSplit.Length; i++)
            {
                Operacion _op = new Operacion();
                string _linea = textoSplit[i];

                //Numero de casos
                if (i == 0)
                {
                    _op.Comando = Comandos.INVALID;
                    _op.NumeroCasos = int.Parse(_linea);
                }
                //tamaño matiz y numero de operaciones 
                else if (_linea.Length == 3 && _linea.Contains(" "))
                {
                    _op.Comando = Comandos.INVALID;
                    _op.TamañoMatrix = int.Parse(_linea[0] + "");
                    _op.NumeroOperaciones = int.Parse(_linea[2] + "");
                }//operaciones
                else if (_linea.StartsWith(Comandos.QUERY.ToString()) ||
                         _linea.StartsWith(Comandos.UPDATE.ToString()))
                {
                    string[] _split = _linea.Split(' ');


                    if (Enum.TryParse(_split[0], out Comandos comando))
                    {
                        _op = new Operacion();
                        _op.Comando = comando;
                        switch (comando)
                        {
                            case Comandos.UPDATE:
                                _op.Update = this.getComandoUpdate(_split);
                                break;
                            case Comandos.QUERY:
                                _op.Query = this.getComandoQuery(_split);
                                break;
                        }
                    }
                }
                else
                {
                    throw new Exception("Error al realizar la lectura");
                }
                lstOperacion.Add(_op);
            }


            return lstOperacion;
        }

        private Update getComandoUpdate(string[] p_linea)
        {
            Update _up = new Update();
            for (int i = 0; i < p_linea.Length; i++)
            {
                switch (i)
                {
                    case 1:
                        _up.x = int.Parse(p_linea[i]);
                        break;
                    case 2:
                        _up.y = int.Parse(p_linea[i]);
                        break;
                    case 3:
                        _up.z = int.Parse(p_linea[i]);
                        break;
                    case 4:
                        _up.valor = long.Parse(p_linea[i]);
                        break;
                }
            }

            return _up;
        }

        private Query getComandoQuery(string[] p_linea)
        {
            Query _q = new Query();

            for (int i = 0; i < p_linea.Length; i++)
            {
                switch (i)
                {
                    case 1:
                        _q.x0 = int.Parse(p_linea[i]);
                        break;
                    case 2:
                        _q.y0 = int.Parse(p_linea[i]);
                        break;
                    case 3:
                        _q.z0 = int.Parse(p_linea[i]);
                        break;
                    case 4:
                        _q.x1 = int.Parse(p_linea[i]);
                        break;
                    case 5:
                        _q.y1 = int.Parse(p_linea[i]);
                        break;
                    case 6:
                        _q.z1 = int.Parse(p_linea[i]);
                        break;
                }
            }

            return _q;
        }
    }
}
