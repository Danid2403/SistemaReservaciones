using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IClientesAD
    {
        List<recClientes_Result> recCliente();

        recClientesXId_Result recClienteXId(int pId);

        bool insCliente(Clientes pobjCliente);

        bool updCliente(Clientes pobjCliente);

        bool delCliente(Clientes pobjCliente);

    }
}
