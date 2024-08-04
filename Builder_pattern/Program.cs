using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Builder_pattern  // создаем телефоны
{
    public class Phone 
    {
        private string data; // обязательно приватный

        public Phone()
        {
            data = "";
        }  // это можно писать проще: public Phone() => data = ""; - через лямбда выражение

        public string AboutPhone() { return data; }  //  это можно писать проще: public string AboutPhone() => data; 

        public void AppendData(string str) => data += str; 
    }

    public interface IDeveloper  // что может сделать разработчик
    {
        void CreateBox();
        void CreateDisplay();
        void SystemInstall();
        Phone GetPhone();
    }

    public class AndroidDeveloper : IDeveloper
    {
        private Phone phone;
        public AndroidDeveloper() => phone = new Phone();  // у разработчика сразу есть какой-то телефон
        public void CreateBox()  // добавляем телефону корпус
        {
            phone.AppendData("Добавлен корпус Android; ");
        }

        public void CreateDisplay() 
        {
            phone.AppendData("Добавлен дисплей Android; ");
        }

        public Phone GetPhone() => phone;  // возвращаем телефон

        public void SystemInstall()
        {
            phone.AppendData("Система Android установлена; ");
        }
    }

    public class IOSDeveloper : IDeveloper
    {
        private Phone phone;
        public IOSDeveloper() => phone = new Phone();
        public void CreateBox()  // добавляем телефону корпус
        {
            phone.AppendData("Добавлен корпус Apple; ");
        }

        public void CreateDisplay()
        {
            phone.AppendData("Добавлен дисплей Apple; ");
        }

        public Phone GetPhone() => phone;  // возвращаем телефон

        public void SystemInstall()
        {
            phone.AppendData("Система IOS установлена; ");
        }
    }

    public class Director
    {
        private IDeveloper developer;  // ЭТО О ЗНАЧАЕТ что в develover можно записать объекты IOSDeveloper и AndroidDeveloper
                                       // !!!!ОБЪЕКТ ТИПА ИНТЕРФЕЙС НЕ СОЗДАЁТСЯ!!!!!!
        public Director(IDeveloper developer) // можно передавать и IOSDeveloper и AndroidDeveloper
        {
            this.developer = developer;  // разработчики прикрепляются с нуля, сработает только когда создается директор
        }
        
        public void SetDeveloper(IDeveloper developer) => this.developer = developer; // метод чтобы поменять разработчика
        public Phone MountOnlyPhone()  // создаем телефон без системы
        {
            developer.CreateBox();
            developer.CreateDisplay();
            return developer.GetPhone();
        }

        public Phone MountFullPhone()  // создаем телефон полностью
        {
            developer.CreateBox();
            developer.CreateDisplay();
            developer.SystemInstall();
            return developer.GetPhone();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IDeveloper androidDeveloper = new AndroidDeveloper();
            Director director = new Director(androidDeveloper);

            Phone samsung = director.MountFullPhone();
            Console.WriteLine(samsung.AboutPhone());

            Phone samsung1 = director.MountOnlyPhone();  // создание нового класса Phone ничего не меняет,
                                                         // это под капотом будет один и тот же телефон, т.к. тот же разработчик
            Console.WriteLine(samsung1.AboutPhone());

            IDeveloper IOSDeveloper = new IOSDeveloper();
            director.SetDeveloper(IOSDeveloper);

            Phone iphone1 = director.MountOnlyPhone();
            Console.WriteLine(iphone1.AboutPhone());
        }
    }
}
