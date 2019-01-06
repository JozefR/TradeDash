using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TradeDash.Application.Common
{
    public static class ViewHelpers
    {
        public static List<SelectListItem> EnumToSelectItem<T>() where T : Enum
        {
            var results = new List<SelectListItem>();
            var values = Enum.GetValues(typeof(T));

            foreach (int value in values)
            {
                var selectListItem = new SelectListItem
                {
                    Text = Enum.GetName(typeof(T), value),
                    Value = value.ToString()
                };
                
                results.Add(selectListItem);
            }

            return results;
        }
    }
}