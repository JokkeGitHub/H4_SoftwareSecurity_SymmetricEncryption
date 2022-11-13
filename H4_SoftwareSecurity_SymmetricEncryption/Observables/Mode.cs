using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H4_SoftwareSecurity_SymmetricEncryption
{
    class Mode : ObservableCollection<string>
    {
        public Mode()
        {
            Add("ECB");
            Add("CBC");
        }
    }
}
