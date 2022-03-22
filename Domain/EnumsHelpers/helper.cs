using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain.EnumsHelpers
{
    public static class helper
    {
        public static SelectList GetSelectedItemList<T>() where T : struct
        {
            T t = default(T);
            if (!t.GetType().IsEnum) { throw new ArgumentNullException("make sure it is enum type"); }
            var namelist = t.GetType().GetEnumNames();
            var counter = 0;
            Dictionary<int, string> myDictionary = new Dictionary<int, string>();
            if (namelist != null && namelist.Length > 0)
            {
                foreach (var name in namelist)
                {
                    T newEnum = (T)Enum.Parse(t.GetType(), name);
                    string description = getDescriptionFromEnumValue(newEnum as Enum);

                    if (!myDictionary.ContainsKey(counter))
                    {
                        myDictionary.Add(counter, description);
                    }
                    counter++;
                }
                counter = 0;
                return new SelectList(myDictionary, "Key", "Value");

            }
            return null;
        }

        private static string getDescriptionFromEnumValue(Enum value)
        {
            DescriptionAttribute descriptionAttribute =
                value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault() as DescriptionAttribute;
            return descriptionAttribute == null ? value.ToString() : descriptionAttribute.Description;
        }

        public static string ToDescription(this Enum e)
        {
            var attributes = (DisplayAttribute[])e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DisplayAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
