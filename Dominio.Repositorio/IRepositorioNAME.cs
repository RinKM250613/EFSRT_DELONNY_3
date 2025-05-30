using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public interface IRepositorioNAME<T> where T : class
    {
        IEnumerable<T> GetByName(string nombre);
        IEnumerable<T> GetByCombo(string categoria);
        IEnumerable<T> GetByNameAndCombo(T registro);
    }
}
