using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Helpers
{
    public static class Helper
    {
        public static IEnumerable<object> EnumToEnumarableDynamic<T>()
        {
            var arr = new List<object>();
            foreach (var item in Enum.GetValues(typeof(T)))
            {
                var key = ((int)item).ToString();
                var val = item.ToString();
                var dyn = DynObject.GetDynamicObject(new Dictionary<string, object>() { { key, val }, });
                arr.Add(dyn);
            }

            return arr;
        }
    }
}
