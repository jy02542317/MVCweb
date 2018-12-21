using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BaseDAL
    {
        public static T DataTableTo<T>(DataTable table)
        {
            T t = default(T);
            PropertyInfo[] propertypes = null;
            string tempName = string.Empty;
            DataRow row = table.Rows[0];
            t = Activator.CreateInstance<T>();
            propertypes = t.GetType().GetProperties();
            foreach (PropertyInfo pro in propertypes)
            {
                tempName = pro.Name;
                if (table.Columns.Contains(tempName))
                {
                    object value = row[tempName] ?? DBNull.Value;
                    pro.SetValue(t, value, null);
                }
            }

            return t;
        }

        public static IList<T> DataTableToList<T>(DataTable table)
        {
            IList<T> list = new List<T>();
            T t = default(T);
            PropertyInfo[] propertypes = null;
            string tempName = string.Empty;
            foreach (DataRow row in table.Rows)
            {
                t = Activator.CreateInstance<T>();
                propertypes = t.GetType().GetProperties();
                foreach (PropertyInfo pro in propertypes)
                {
                    tempName = pro.Name;
                    if (table.Columns.Contains(tempName))
                    {
                        object value = ((row[tempName]) == DBNull.Value) ? null : row[tempName];
                        pro.SetValue(t, value, null);
                    }
                }
                list.Add(t);
            }
            return list;
        }
    }
}
