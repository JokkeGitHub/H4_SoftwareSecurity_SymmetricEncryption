using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H4_SoftwareSecurity_SymmetricEncryption
{
    class EncryptionType : ObservableCollection<string>
    {
        public EncryptionType()
        {
            Add("TripleDES");
            Add("AES");
        }
    }
}
