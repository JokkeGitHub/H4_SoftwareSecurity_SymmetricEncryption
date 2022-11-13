using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H4_SoftwareSecurity_SymmetricEncryption
{
    class BitSize : ObservableCollection<string>
    {
        public BitSize()
        {
            Add("128");
            Add("192");
            Add("256");
        }
    }
}
