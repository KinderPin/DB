using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
       static void Main(string[] args)
        {
            DataBase dataBase = new DataBase("Автосалон");

            DataTable dataTable = new DataTable("Владельцы");

            DataColumn dataColumn = new DataColumn("ФИО");

            string a = "Антонов И.М";

            string b = "Петров А.А";

            string c = "Воронов А.Е";

            string d = "Левшов Е.П";

            string e = "Соколов Н.Н";

            dataColumn.Add(a);

            dataColumn.Add(b);

            dataColumn.Add(c);

            dataColumn.Add(d);

            dataColumn.Add(e);

            dataTable.AddColumn(dataColumn);

            dataBase.Add(dataTable);

            dataBase.Save();

            DataBase dataBase1 = new DataBase("Налоговый учет");

            DataTable dataTable1 = new DataTable("Владельцы");

            DataColumn dataColumn1 = new DataColumn("ФИО");

            //dataBase1.Import("Автосалон");

            dataBase.Show();

            dataBase.Tables[dataBase.TableIndex("Владельцы")].Columns[0].ChangeElement("Петров А.А", "Иванов И.И");

            dataBase.Tables[dataBase.TableIndex("Владельцы")].Columns[0].ChangeElement("Антонов И.М", "Маслов К.М");

            dataBase.Tables[0].Columns[0].Delete("Воронов А.Е");

            dataTable1.AddColumn(dataColumn);
            dataBase1.Add(dataTable);
            dataBase1.Save();

            dataBase1.Show();

            Console.ReadKey();
        }
    }
}