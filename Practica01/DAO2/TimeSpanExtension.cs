using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.DAO2
{
    public static class TimeSpanExtensions
    {
        public static DateTime ToDateTime(this TimeSpan time)
        {
            return DateTime.Today.Add(time);
        }
    }

}
