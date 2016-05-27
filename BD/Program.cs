using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    class DataBase
    {
        List<DataTable> file = new List<DataTable>();

        string Iname;

        string Ipath = "C:/Users/e8922/OneDrive/Документы/ProjectDB";

        public string Path
        {
            get
            {
                return Ipath;
            }
        }
        
        public string Name
        {
            get
            {
                return Iname;
            }
        }

        public DataTable this[int i]
        {
            get
            {
                return file[i];
            }
        }


        public List<DataTable> Tables
        {
            get
            {
                return file;
            }
            set
            {
                file = value;
            }
        }


        public DataBase(string name)
        {
            Iname = name;

        }

        ~DataBase() { }

        public void Add(DataTable dataTable)
        {
           file.Add(dataTable);
        }

        public void Delete(string tableName)
        {
            file.RemoveAt(TableIndex(tableName));
        }

        public DataTable GetTable(string tableName)
        {
            for (int i = 0; i < file.Count; i++)
            {
                if (file[i].TableName == tableName)
                {
                    return file[i];
                }
            }

            return null;
        }

        public int TableIndex(string tableName)
        {
            for (int i = 0; i < file.Count; i++)
            {
                if (file[i].TableName == tableName)
                {
                    return i;
                }
            }

            return 0;
        }

        public DataColumn GetDColumn(string tableName, string columnName)
        {
           return GetTable(tableName).GetColumn(columnName);
        }

        public DataColumn IncludeToColumn(string tableName, string elementValue)
        {
            DataTable dataTable = GetTable(tableName);

            for (int i = 0; i < dataTable.Count; i++)
            {
                for (int j = 0; j < dataTable.Count; j++)
                {
                    if (dataTable[i][j] == elementValue)
                    {
                        return dataTable[i];
                    }
                }
            }

            return null;
        }

        public void Save()
        {
            SaveDB();

            for (int i = 0; i < file.Count; i++)
            {
                SaveDataTable(file[i].TableName);

                for (int j = 0; j < file[i].Count; j++)
                {
                    SaveDataColumn(file[i].TableName, file[i][j].ColumnName);

                    file[i][j].SaveAllElements(this, file[i].TableName);
                }
            }
        }

        private void SaveDB()
        {
            DirectoryInfo IDirectory = new DirectoryInfo(Ipath + "/" + Iname);

            IDirectory.Create();
        }

        private void SaveDataTable(string tableName)
        {
            Directory.CreateDirectory(Ipath + "/" + Iname + "/" + tableName);
        }

        private void SaveDataColumn(string tableName, string columnName)
        {
            Directory.CreateDirectory(Ipath + "/" + Iname + "/" + tableName + "/" + columnName);
        }

        public void DeleteAll()
        {
            file.RemoveRange(0, file.Count);
        }
        public void Import(string DataBaseName)
        {
            DeleteAll();

            Iname = DataBaseName;

            DirectoryInfo directoryInfo = new DirectoryInfo(Ipath + "/" + DataBaseName);

            DirectoryInfo[] tables = directoryInfo.GetDirectories();

            ImportTable(tables);

        }

        private void ImportElement(FileInfo[] elements, DataColumn dataColumn)
        {
            for (int n = 0; n < elements.Count(); n++)
            {
                StreamReader streamReader = new StreamReader(elements[n].FullName);

                string element = streamReader.ReadLine();

                streamReader.Close();

                dataColumn.Add(element);
            }

        }

        private void ImportColumn(DirectoryInfo[] columns, DataTable dataTable)
        {
            for (int j = 0; j < columns.Count(); j++)
            {
                DataColumn dataColumn = new DataColumn(columns[j].Name);

                FileInfo[] elements = columns[j].GetFiles();

                ImportElement(elements, dataColumn);

                dataTable.AddColumn(dataColumn);
            }
        }

        private void ImportTable(DirectoryInfo[] tables)
        {
            for (int i = 0; i < tables.Count(); i++)
            {
                DataTable dataTable = new DataTable(tables[i].Name);

                DirectoryInfo[] columns = tables[i].GetDirectories();

                ImportColumn(columns, dataTable);

                Add(dataTable);
            }
        }

        public void Show()
        {
            Console.WriteLine();

            for (int i = 0; i < file.Count; i++)
            {
                Console.WriteLine(file[i].TableName + ": ");

                for (int j = 0; j < file[i].Count; j++)
                {
                    Console.WriteLine(file[i][j].ColumnName + ": ");

                    for (int m = 0; m < file[i][j].Count; m++)
                    {
                        Console.Write(file[i][j][m] + ", ");
                    }

                }
            }
         }
    }
}