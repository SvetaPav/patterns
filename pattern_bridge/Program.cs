using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pattern_bridge
{
    public interface IDataReader
    {
        void Read();
    }

    public class DataBaseReader : IDataReader
    { 
        public void Read() 
        {
            Console.Write("Данные из БД ");
        }
    }

    public class FileReader : IDataReader
    {
        public void Read()
        {
            Console.Write("Данные из файла ");
        }
    }

    public class ExcelReader : IDataReader
    {
        public void Read()
        {
            Console.Write("Данные из Excel ");
        }
    }

    public abstract class Sender 
    { 
        protected IDataReader reader;
        protected Sender(IDataReader reader)
        {
            this.reader = reader;
        }
        public void SetDataReader(IDataReader reader)
        {
            this.reader = reader;
        }
        public abstract void Send();  // отдаем метод на реализацию классам, т.к. это общий класс для отправителей
    }

    public class TelegramSender : Sender
    {
        public TelegramSender(IDataReader reader) : base(reader) { }  // вызываем конструктор родительского класса
        
        public override void Send() 
        {
            reader.Read();
            Console.WriteLine("отправлены при помощи Telegram");  // связали отправителя и источники
        }
    }

    public class EmailSender : Sender
    {
        public EmailSender(IDataReader reader) : base(reader) { }  // вызываем конструктор родительского класса

        public override void Send()
        {
            reader.Read();
            Console.WriteLine("отправлены при помощи Email");  // связали отправителя и источники
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Sender senderTG = new TelegramSender(new FileReader());
            senderTG.Send();   // "Данные из файла отправлены при помощи Telegram"

            senderTG.SetDataReader(new DataBaseReader());
            senderTG.Send();  // "Данные из БД отправлены при помощи Telegram"

            Sender senderE = new EmailSender(new FileReader());
            senderE.Send();   // "Данные из файла отправлены при помощи Email"

            senderE.SetDataReader(new DataBaseReader());
            senderE.Send();  // "Данные из БД отправлены при помощи Email"

            senderE.SetDataReader(new ExcelReader());
            senderE.Send();   // "Данные из Excel отправлены при помощи Email"

        }
    }
}
