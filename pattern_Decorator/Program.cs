using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pattern_Decorator
{
    public interface IProcessor
    {
        void Process();  // главный метод
    }

    public abstract class Shell : IProcessor  // отвечает за отправку - это Decorator
    {
        protected IProcessor processor;
        protected Shell (IProcessor processor)
        {
            this.processor = processor;
        }
        public virtual void Process() 
        { 
            processor.Process();
        }
    }

    public class Transmitter : IProcessor   // отвечает за вывод результатов, это ConcreteDecorator
    {
        private string data;
        private DataBaseHelper connection;
        public Transmitter(string data)
        {
            this.data = data;
            connection = DataBaseHelper.GetConnection();
        }
        public void Process()
        {
            Console.WriteLine($"Данные {data} переданы по каналу связи");
        }

        public void InsertData(string data)  // находится не на месте
        {
            Console.WriteLine($"New data is {data}");
            this.data = data;
        }
    }

    public class HammingCode : Shell // отвечает за помехоустойчивость сигнала, это ConcreteDecorator
    {
        public HammingCode(IProcessor proc) : base(proc) { }
        public override void Process() 
        {
            Console.Write("Наложен помехоустойчивый код Хэмминга->");
            processor.Process();
        }   
    }

    public class Encryptor : Shell // отвечает за шифрование данных, это ConcreteDecorator
    {
        public Encryptor(IProcessor proc) : base(proc) { }
        public override void Process()
        {
            Console.Write("Шифрование данных->");
            processor.Process();
        }
    }

    public class Connection : Shell // проверка соединения, это ConcreteDecorator
    {
        public Connection(IProcessor proc) : base(proc) { }
        public override void Process()
        {
            Console.Write("Проверка соединения->");
            processor.Process();
        }

    }

    public class DataBaseHelper
    {
        private static DataBaseHelper dataBaseConnection;
        private DataBaseHelper()
        {
            Console.WriteLine("Подключение к БД");
        }
        public static DataBaseHelper GetConnection()
        {
            if (dataBaseConnection == null)
            {
                dataBaseConnection = new DataBaseHelper();
            }
            return dataBaseConnection;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IProcessor transmitter = new Transmitter("password");
            transmitter.Process();  //Подключение к БД
                                    //Данные password переданы по каналу связи
      
            Console.WriteLine("-----------------------");
            Shell hamming = new HammingCode(transmitter);
            hamming.Process();  // Наложен помехоустойчивый код Хэмминга->Данные password переданы по каналу связи

            Console.WriteLine("-----------------------");
            Shell encrypter = new Encryptor(transmitter);
            encrypter.Process();  // Шифрование данных->Данные password переданы по каналу связи

            Console.WriteLine("-----------------------");
            Shell encrypter2 = new Encryptor(hamming);
            encrypter2.Process();  // Шифрование данных->Наложен помехоустойчивый код Хэмминга->Данные password переданы по каналу связи

            Console.WriteLine("-----------------------");
            Shell encrypter3 = new Connection(encrypter2);
            encrypter3.Process();  // Проверка соединения->Шифрование данных->Наложен помехоустойчивый код Хэмминга->Данные password переданы по каналу связи
        }
    }
}
