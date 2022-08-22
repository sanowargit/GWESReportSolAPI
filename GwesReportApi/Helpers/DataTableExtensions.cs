using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;
using System.Linq;
using System;
using System.Runtime.InteropServices;

namespace GwesReportApi.Helpers
{
    public static class DataTableExtensions
    {
        public static List<T> ToList<T>(this DataTable dt)
        {
            foreach (DataColumn col in dt.Columns)
            {
                col.ColumnName = col.ColumnName.Replace(" ", "");
            }
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
            var columnNames = dt.Columns.Cast<DataColumn>()
                .Select(c => c.ColumnName)
                .ToList();
            var objectProperties = typeof(T).GetProperties(flags);
            var targetList = dt.AsEnumerable().Select(dataRow =>
            {
                var instanceOfT = Activator.CreateInstance<T>();

                foreach (var properties in objectProperties.Where(properties => columnNames.Contains(properties.Name) && dataRow[properties.Name] != DBNull.Value))
                {
                    properties.SetValue(instanceOfT, dataRow[properties.Name], null);
                }
                return instanceOfT;
            }).ToList();

            return targetList;
        }
    }
}

