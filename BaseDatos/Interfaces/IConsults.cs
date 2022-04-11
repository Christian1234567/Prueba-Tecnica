using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatos.Interfaces
{
    public interface IConsults<T>
    {
        List<T> GetAll();
        T GetById(int Id);
    }
}
