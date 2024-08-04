using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_pattern  // применяется если нужно удостовериться в том, что какой-то объект создается один раз
{
    class Program
    {
        static void Main(string[] args)
        {
            //DatabaseHealper dbHealper = DatabaseHelper.GetConnection();  // можем так вызывать, потму что метод static
            
            DatabaseHelper.GetConnection().CreateData("Первая запись в бд");
            Console.WriteLine(DatabaseHelper.GetConnection().GetData());
            //DatabaseHelper.GetConnection() - возвращается объект класса,
            //поэтому можно обращаться с этим выражением как с объектом класса
        }
    }
}
