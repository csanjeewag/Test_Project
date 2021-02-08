using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Test_Project.Repository
{
    public class DbContext
    {
        private readonly String connectionString;
        public DbContext(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("mydb");
        }

        public DataTable execute(String sql)
        {
            DataTable dataTable = new DataTable();

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, conn);
            conn.Open();

            SqlDataAdapter SqlDataAdapter = new SqlDataAdapter(command);
            SqlDataAdapter.Fill(dataTable);

            return dataTable;
        }

        public List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private  T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}
