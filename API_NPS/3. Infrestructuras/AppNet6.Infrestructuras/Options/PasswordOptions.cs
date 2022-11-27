using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNet6.Infrestructuras.Options
{
    public class PasswordOptions
    {
        public int SaltSize { get; set; }
        public int keySize { get; set; }
        public int Iterations { get; set; }
    }
}
