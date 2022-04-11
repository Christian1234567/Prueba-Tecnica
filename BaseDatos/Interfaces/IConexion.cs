using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatos.Interfaces
{
    public interface IConexion
    {
        void Open();
        void Close();
        bool ExecuteCommand(string nameProcedure, Dictionary<string, object> parameters);
    }
}
