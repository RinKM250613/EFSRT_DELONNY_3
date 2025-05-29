using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public interface IRepositorioCRUD<T> where T : class
    {
        string Add(T registro);
        string Update(T registro);
        string Delete(string id);
        T Find(string id);
    }
}
