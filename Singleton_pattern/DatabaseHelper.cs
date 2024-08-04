using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_pattern
{
    class DatabaseHelper
    {
        private string data;  // это база данных
        private static DatabaseHelper databaseConnection;  // один для всех объектов класса
        private DatabaseHelper() // избегаем создание 2х объектов класса
        {
            Console.WriteLine("Подключение к БД...");
        }
        public static DatabaseHelper GetConnection() // static - метод вызывается через класс, а не через объект!
        {
            if (databaseConnection == null)  // избегаем создание 2х объектов класса
            {
                databaseConnection = new DatabaseHelper();
            }
            return databaseConnection;
        }
        public string GetData() => data;
        public void CreateData(string str)
        {
            Console.WriteLine($"Новые данные - {str} - внесены в БД");
            data = str;
        }
     }
}
