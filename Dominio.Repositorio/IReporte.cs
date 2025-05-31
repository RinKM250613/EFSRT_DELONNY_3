using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public interface IReporte<T> where T : class
    {
        IEnumerable<T> ComboCategoriaStock(T registro);
        IEnumerable<T> GetCategoriaVentas(T registro);

        IEnumerable<T> FiltroFechas(T registro);

    }
}
