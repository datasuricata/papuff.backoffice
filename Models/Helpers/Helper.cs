using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace papuff.backoffice.Models.Helpers {
    public static class Helper {

        /// <summary>
        /// generic type of enum
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string EnumDisplay(this Enum value) {
            return !(value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DisplayAttribute), false)
                .SingleOrDefault() is DisplayAttribute attribute) ? value.ToString() : attribute.Description;
        }

        public static List<SelectListItem> ToDropDown<T>() {
            var dropdown = new List<SelectListItem>();
            foreach (var i in Enum.GetValues(typeof(T))) {
                var sItem = new SelectListItem {
                    Text = (i as Enum).EnumDisplay(), Value = ((int)i).ToString()
                };
                dropdown.Add(sItem);
            }
            return dropdown.OrderBy(x => x.Text).ToList();
        }

        public static List<SelectListItem> ToDropDown<T>(IEnumerable<T> list, string text, string value) {
            var dropdown = list.Select(item => new SelectListItem {
                Text = item.GetType()
                    .GetProperty(text)
                    .GetValue(item, null) as string,

                Value = item.GetType()
                    .GetProperty(value)
                    .GetValue(item, null) as string
            }).ToList();

            return dropdown.OrderBy(x => x.Text).ToList();
        }
    }
}