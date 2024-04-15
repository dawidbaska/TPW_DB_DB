using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public abstract class DaneAPI
    {
        public static DaneAPI Create()
        {
            return new DaneImplementacja();
        }
        public abstract Kula stworz();
    }
    
}
