#region Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Common.Models
{
    public interface IHasAutoID
    {
        int getAutoId();
    }
}
