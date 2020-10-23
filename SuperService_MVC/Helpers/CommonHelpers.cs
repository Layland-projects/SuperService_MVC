using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperService_MVC.Helpers
{
    public class CommonHelpers
    {
        public static T ConvertIngredientToViewModel<T>(object obj) where T : new()
        {
            var o = new T();
            foreach (var prop in obj.GetType().GetProperties())
            {
                if (prop.CanWrite && prop.CanRead)
                {
                    prop.SetValue(o, prop.GetValue(obj));
                }
            }
            return o;
        }
    }
}
