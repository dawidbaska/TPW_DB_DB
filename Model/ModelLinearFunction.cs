using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPW_DB_DB.Model
{
    public class ModelLinearFunction
    {
        public double a = 1;
        public double b = -10;
    
    public double? FindZero()
    {
        if (a == 0) return null;
        else return -b / a;
    }

    }
}
