using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class E_cat
    {
        private int idcategoria;
        private string codigocategoria;
        private string nombre;
        private string descripcion;

        public int Idcategoria { get => idcategoria; set => idcategoria = value; }
        public string Codigocategoria { get => codigocategoria; set => codigocategoria = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
