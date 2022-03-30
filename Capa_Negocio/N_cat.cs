using Capa_Acceso_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Capa_Negocio
{
    public class N_cat
    {
        public D_cat objDato = new D_cat();
        public List<E_cat> ListarCategoria(string Buscar)
        {
            return objDato.ListarCategorias(Buscar);
        }
        public void InsertarCategoria(E_cat Categoria)
        {
            objDato.InsertarCat(Categoria);
        }
        public void EditandoCategoria(E_cat Categoria)
        {
            objDato.EditarCat(Categoria);
        }
        public void EliminandoCategoria(E_cat Categoria)
        {
            objDato.EliminarCat(Categoria);
        }


    }
}
