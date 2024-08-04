using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3 };
            //arr.Length;  // одно свойсвтво для всех типов массивов - для int string и т.д.
        }

    }

    public class Vehicle 
    {
        public virtual void Move()
        {
            Console.WriteLine("Транспорт едет");
        }
    }


    public class Car : Vehicle
    {
        override public void Move()  // переписываем метод Move
        {
            Console.WriteLine("Транспорт едет");
        }
    }

    public class Bicycle : Vehicle
    {

    }

    public class Metro : Vehicle { }

    public class Plane
    {
        public void Move()
        {
            Console.WriteLine("Транспорт едет");
        }
    }

    // чтобы не переписывать методы (т.к. "мы не должны переписывать, а только дописывать") для классов используют интерфейсы:

    interface IMove
    {
       void Move();
        void Stop();
    }

    public class Car2 : IMove  // в классе обязательно должен быть реализован метод из Move
    {
        public void Move()
        {
            Console.WriteLine("Машина едет");
        }

        void IMove.Stop()
        {
            throw new NotImplementedException();
        }
    }

    public class Bicycle2 : IMove
    {
        public void Move()
        {
            Console.WriteLine("Велосипед едет");
        }
        void IMove.Stop()
        {
            throw new NotImplementedException();
        }
    }
}
