using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IMesasAD
    {
        List<recMesas_Result> recMesa();
        recMesasXId_Result recMesaXID(int pId);
        bool insMesa(Mesas pobjMesas);
        bool updMesa(Mesas pobjMesas);
        bool delMesa(Mesas pobjMesas);

    }
}
