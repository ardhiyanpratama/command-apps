using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandApps.Helper
{
    public class ServiceResponse<TObject>:ResponseBase
    {
        public TObject Result { get; set; }
    }
}
