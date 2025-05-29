using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public interface IRepositorioGET<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByName(string nombre);
    }
}
