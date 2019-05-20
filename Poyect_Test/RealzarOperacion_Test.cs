using Cube_Summation.Services.Interfaces;
using Cube_Summation.Services.Servicios;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poyect_Test
{
    public class RealzarOperacion_Test
    {
        private readonly IOperacion _Ioperacion = null; 
        public RealzarOperacion_Test()
        {
            _Ioperacion = new SOperacion();
        }

        [Test]
        public void RealizarOperacion()
        {
            string _string = @"2
4 5
UPDATE 2 2 2 4
QUERY 1 1 1 3 3 3
UPDATE 1 1 1 23
QUERY 2 2 2 4 4 4
QUERY 1 1 1 3 3 3
2 4
UPDATE 2 2 2 1
QUERY 1 1 1 1 1 1
QUERY 1 1 1 2 2 2
QUERY 2 2 2 2 2 2";

            List<string> _result = _Ioperacion.Realizar(p_texto: _string);

            foreach (var item in _result)
            {
                TestContext.Out.WriteLine(item);
            }
        }
    }
}
