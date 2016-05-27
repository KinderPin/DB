using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class DataTable
    {
        List<DataColumn> Itable = new List<DataColumn>();

        string Iname;

        public DataTable(string name)
        {
            Iname = name;
        }

        public List<DataColumn> Columns
        {
            get
            {
                return Itable;
            }
        }

        public string TableName
        {
            get
            {
                return Iname;
            }
        }

        public int Count
        {
            get
            {
                return Itable.Count;
            }
        }

        public DataColumn this[int i]
        {
            get
            {
                return Itable[i];
            }
        }

        public DataColumn GetColumn(string columnName)
        {
            for (int i = 0; i < Itable.Count; i++)
            {
                if (Itable[i].ColumnName == columnName)
                {
                    return Itable[i];
                }
            }

            return null;
        }

        public void AddColumn(DataColumn dataColumn)
        {
            Itable.Add(dataColumn);
        }

        public void DeleteColumn(string columnName)
        {
            Itable.Remove(GetColumn(columnName));
        }
    }
    
}