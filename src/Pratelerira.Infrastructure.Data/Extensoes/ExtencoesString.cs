using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratelerira.Infrastructure.Data.Extensoes
{
    public static class ExtencoesString
    {

        public static string StringFormat(this string to, string valor)
        {
            var formatado = string.Format(to, valor);
            return formatado;
        }

    }
}
