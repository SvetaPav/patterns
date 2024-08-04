using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pattern_Prototype
{
    public interface IPhone
    {
        void SetManufacture(string manufacture);
        void SetVersion(double version);
        string GetManufacture();
        double GetVersion();
        IPhone Clone();
    }

    public class Apple : IPhone
    {
        private string _manufacture;  // нижнее подчеркивание у private обычно
        private double _version;  // если тут будет { get; set; } то это уже будут свойства, а сейчас поле

        public Apple() { }
        public Apple(Apple donor)
        {
            _manufacture = donor._manufacture;
            _version = donor._version;
        }

        public void SetManufacture(string manufacture) { _manufacture = manufacture; }
        public void SetVersion(double version) => _version = version;    // значит то же, что и выше
        public string GetManufacture() { return _manufacture;}
        public double GetVersion() => _version;    // значит то же, что и выше
        public IPhone Clone() {  return new Apple(this); }  // обращение ко второму конструктору, копируется текущий объект
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            IPhone apple1 = new Apple();  // можно так написать, т.к. IPhone это интерфейс
            apple1.SetManufacture("Apple1");
            apple1.SetVersion(9.0);

            IPhone apple2 = apple1.Clone();
            Console.WriteLine(apple2.GetVersion());
            apple2.SetManufacture("Honor");
            Console.WriteLine(apple1.GetManufacture());
            Console.WriteLine(apple2.GetManufacture());
            Console.WriteLine(apple1.GetVersion());
        }
    }
}
