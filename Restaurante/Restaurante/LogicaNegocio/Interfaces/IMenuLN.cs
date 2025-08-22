using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Interfaces
{
    public interface IMenuLN
    {
        List<recMenu_Result> recMenus();

        recMenuXId_Result recMenusXID(int pId);

        bool insMenu(Menu pobjMenu);

        bool updMenu(Menu pobjMenu);

        bool delMenu(Menu pobjMenu);
    }
}
