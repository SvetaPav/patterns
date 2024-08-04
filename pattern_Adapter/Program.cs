using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pattern_AdapterObjects
{
    public interface IScale
    {
        double GetWeight();
    }

    public class RussianScales : IScale
    {
        readonly double _weight;  // поле можно только читать
        public RussianScales(double weight)
        {
            _weight = weight;
        }
        public double GetWeight()
        {
            return _weight;
        }
    }

    public class BritishScales
    {
        readonly double _weight;
        public BritishScales(double weight)
        {
            _weight = weight;
        }
        public double GetWeight()
        {
            return _weight;
        }
    }

    public class Adapter : IScale
    {
        BritishScales _britishScales;
        public Adapter(BritishScales britishScales)
        {
            _britishScales = britishScales;
        }
        public double GetWeight()
        {
            return _britishScales.GetWeight() * 0.45;  // переводим фунты в кг
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            RussianScales kg = new RussianScales(167);  // в кг
            BritishScales funts = new BritishScales(123);  // в фунтах
            // IScale lbs = new Adapter(funts); - так тоже работает
            IScale lbs = new Adapter(new BritishScales(123));

            Console.WriteLine(funts.GetWeight());  // 123
            Console.WriteLine(lbs.GetWeight());  // 55,35
            Console.WriteLine(kg.GetWeight());   // 167

        }
    }
}
