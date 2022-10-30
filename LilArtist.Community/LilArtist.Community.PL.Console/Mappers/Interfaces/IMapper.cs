using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LilArtist.Community.PL.MyConsole.Mappers
{
    public interface IMapper<BLL, PL>
        where BLL : class
        where PL : class
    {
        BLL Map(PL model);
        PL Map(BLL model);
        IEnumerable<BLL> Map(IEnumerable<PL> model);
        IEnumerable<PL> Map(IEnumerable<BLL> model);

    }
}
