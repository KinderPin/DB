using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace ConsoleApplication1
{
    class DataColumn
    {
        List<string> column = new List<string>();

        string Iname;

        public int Count
        {
            get
            {
                return column.Count;
            }
        }

        public string ColumnName
        {
            get
            {
                return Iname;
            }
        }

        public DataColumn(string name)
        {
            Iname = name;

        }

        public string this[int i]
        {
            get
            {
                return column[i];
            }
        }

        public void Add(string element)
        {
            column.Add(element);
        }

        public void Delete(string element)
        {
            column.Remove(element);
        }

        public string getElement(string element)
        {
            for (int i = 0; i < column.Count; i++)
            {
                if (column[i] == element)
                {
                    return column[i];
                }
            }

            return null;
        }

        public int GetElementIndex(string element)
        {
            for (int i = 0; i < column.Count; i++)
            {
                if (column[i] == element)
                {
                    return i;
                }
            }

            return 0;
        }

        public void ChangeElement(string oldValue, string newValue)
        {
            column[GetElementIndex(oldValue)] = newValue;
        }

        public void SaveAllElements(DataBase dataBase, string tableName)
        {
            for (int i = 0; i < column.Count; i++)
            {
                SaveElement(dataBase, tableName, column[i]);
            }
        }

        private void SaveElement(DataBase dataBase, string tableName, string element)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "unknown files (*.unknown)|*.unknown";

            saveFileDialog.FileName = dataBase.Path + "/" + dataBase.Name + "/" + tableName + "/" + Iname + "/" + element;

            FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create);

            StreamWriter streamWriter = new StreamWriter(fs);

            streamWriter.Write(element);

            streamWriter.Close();
        }
    }
}