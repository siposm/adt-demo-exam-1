using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace movies
{
    public class Validator
    {
        public static bool IsValid<T>(string propertyName, T obj)
        {
            PropertyInfo prop = typeof(T).GetProperty(propertyName);
            
            MinimumYearAttribute attr = (MinimumYearAttribute)prop
                .GetCustomAttributes(typeof(MinimumYearAttribute), false)
                .SingleOrDefault();
            
            int propertyValue = (int)prop.GetValue(obj);

            if (attr != null && propertyValue >= attr?.MinimumYear)
                return true;
            else if (attr != null && propertyValue < attr?.MinimumYear)
                return false;
            else
                throw new ArgumentException();
        }
    }
}
