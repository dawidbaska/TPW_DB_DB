using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPW_DB_DB.Model
{
    public class ModelLinearFunction
    {
        public double a;
        public double b;
    

    public double FindZero(double a, double b)
    {
        return -b / a;
    }

    }
}
