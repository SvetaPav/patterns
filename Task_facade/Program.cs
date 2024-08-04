using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_facade
{
    public class User
    {
        public void Create() { Console.WriteLine("Создание пользователя"); }
        public void Update() { Console.WriteLine("Изменение пользователя"); }
        public void Delete() { Console.WriteLine("Удаление пользователя"); }
    }

    public class Product
    {
        public void Create() { Console.WriteLine("Создание продукта"); }
        public void Update() { Console.WriteLine("Изменение продукта"); }
        public void Delete() { Console.WriteLine("Удаление продукта"); }
    }

    public class Provider
    {
        public void Create() { Console.WriteLine("Создание поставщика"); }
        public void Update() { Console.WriteLine("Изменение поставщика"); }
        public void Delete() { Console.WriteLine("Удаление поставщика"); }
    }

    public class Connection
    {
        public void ON() { Console.WriteLine("Подключение к БД"); }
        public void OFF() { Console.WriteLine("Отключение от БД"); }
    }

    public class DataBase {
        private User User;
        private Product Product;
        private Provider Provider;
        private Connection Connection;

        public DataBase()
        {
            User = new User();
            Product = new Product();
            Provider = new Provider();
            Connection = new Connection();
        }

        public void CreateUser()
        {
            Connection.ON();
            User.Create();
            Connection.OFF();
        }

        public void UpdateUser()
        {
            Connection.ON();
            User.Update();
            Connection.OFF();
        }

        public void DeleteUser()
        {
            Connection.ON();
            User.Delete();
            Connection.OFF();
        }

        public void CreateProduct()
        {
            Connection.ON();
            Product.Create();
            Connection.OFF();
        }

        public void UpdateProduct()
        {
            Connection.ON();
            Product.Update();
            Connection.OFF();
        }

        public void DeleteProduct()
        {
            Connection.ON();
            Product.Delete();
            Connection.OFF();
        }

        public void CreateProvider()
        {
            Connection.ON();
            Provider.Create();
            Connection.OFF();
        }

        public void UpdateProvider()
        {
            Connection.ON();
            Provider.Update();
            Connection.OFF();
        }

        public void DeleteProvider()
        {
            Connection.ON();
            Provider.Delete();
            Connection.OFF();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            DataBase DataBase = new DataBase();
            DataBase.CreateUser();
            DataBase.CreateProduct();
            DataBase.CreateProvider();
        }
    }
}
