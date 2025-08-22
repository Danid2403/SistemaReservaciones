using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Interfaces
{
    public interface IMesasLN
    {

        List<recMesas_Result> recMesa();
        recMesasXId_Result recMesaXID(int pId);
        bool insMesa(Mesas pobjMesa);
        bool updMesa(Mesas pobjMesa);
        bool delMesa(Mesas pobjMesa);

    }
}
