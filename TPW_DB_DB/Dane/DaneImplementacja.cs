using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public class DaneImplementacja : DaneAPI
    {
        public override Kula stworz()
        {
            return new Kula();
        }
    }
}
