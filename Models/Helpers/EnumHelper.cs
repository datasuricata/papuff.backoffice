using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace papuff.backoffice.Models.Helpers {
    public static class EnumHelper {

        /// <summary>
        /// generic type of enum
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string EnumDisplay(this Enum value) {
            return !(value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DisplayAttribute), false)
                .SingleOrDefault() is DisplayAttribute attribute) ? value.ToString() : attribute.Description;
        }
    }
}
