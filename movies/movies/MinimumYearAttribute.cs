using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movies
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MinimumYearAttribute : Attribute
    {
        public int MinimumYear { get; set; }
        public MinimumYearAttribute(int MinimumYear)
        {
            this.MinimumYear = MinimumYear;
        }
    }
}
