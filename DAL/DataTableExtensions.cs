using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace DAL
{
    public static class DataTableExtensions
    {
        public static List<T> ToList<T>(this DataTable dataTable) where T : new()
        {
            var list = new List<T>();

            foreach (DataRow row in dataTable.Rows)
            {
                T item = new T();
                foreach (PropertyInfo prop in typeof(T).GetProperties())
                {
                    if (dataTable.Columns.Contains(prop.Name) && row[prop.Name] != DBNull.Value)
                    {
                        prop.SetValue(item, Convert.ChangeType(row[prop.Name], prop.PropertyType), null);
                    }
                }
                list.Add(item);
            }

            return list;
        }
    }
}
