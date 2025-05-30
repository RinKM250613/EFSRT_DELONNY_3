using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public interface IRepositorioDATE<T> where T : class
    {
        IEnumerable<T> GetByDateAndName(DateTime? fechaPed, string nombre);
    }
}
