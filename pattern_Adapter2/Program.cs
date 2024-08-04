using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pattern_AdapterClasses
{
    public interface IScale
    {
        double GetWeight();
        void Adjust();
    }

    public class RussianScale : IScale
    {
        double _weight;
        public RussianScale(double weight)
        {
            _weight = weight;
        }
        public double GetWeight() 
        {
            return _weight;
        }
        public void Adjust()
        {
            Console.WriteLine("Приведение килограмм к килограммам");
        }
    }

    public class BritishScale
    {
        double _weight;
        public BritishScale(double weight)
        {
            _weight = weight;
        }
        public double GetWeight()
        {
            return _weight;
        }
        public void Adjust()
        {
            Console.Write("Приведение фунтов к килограммам");
        }
    }

    public class Adapter : BritishScale, IScale // сначала классы, потом интерфейсы!
        // класс может наследоваться только один, а интерфейсов несколько
    {
        public Adapter(double weight) : base (weight) // означает что вызываем базовый класс
        { }
        double IScale.GetWeight()
        {
            return base.GetWeight() * 0.45;  // обращаемся к базовому классу
        }

        void IScale.Adjust()
        {
            base.Adjust();
            Console.WriteLine(" в методе Adjust() класса Adapter.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IScale russianScale = new RussianScale(256);
            IScale britishScale = new Adapter(178);

            Console.WriteLine(russianScale.GetWeight());  //"256"
            Console.WriteLine(britishScale.GetWeight());  //"80.1"
            
            russianScale.Adjust();  // Вывод: "Приведение килограмм к килограммам"
            britishScale.Adjust();  // Вывод: "Приведение фунтов к килограммам в методе Adjust() класса Adapter."
        }
    }

}

