using Dominio.Entidad.Negocio.Entidad;
using Dominio.Entidad.Negocio.Entidad.Lista;
using Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidad.Negocio.Abstraccion
{
    public interface IProveedor : IRepositorioCRUD<Proveedor>, IRepositorioGET<ProveedorLista>
    {
    }
}
