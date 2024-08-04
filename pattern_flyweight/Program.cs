using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pattern_flyweight
{
    public abstract class FlyWeight
    {
        public abstract void Operation(int outState);  // передаем в функцию внешнее состояние
    }

    public class FlyWeightFactory 
    { 
        Hashtable flyweights = new Hashtable();
        public FlyWeightFactory()
        {
            flyweights.Add("1", new ConcreteFlyWeight());  // передаем ключ и объект
            flyweights.Add("2", new ConcreteFlyWeight());
            flyweights.Add("3", new ConcreteFlyWeight());
        }

        public FlyWeight GetFlyWeight(string key)
        {
            if(!flyweights.Contains(key))  // если объект не содержится в коллекции
            {
                flyweights.Add(key, new ConcreteFlyWeight());
            }
            return (FlyWeight)flyweights[key];  // или можно написать return flyweights[key] as FlyWeight; 
        }
    }

    public class ConcreteFlyWeight : FlyWeight  // исп-ся когда мы хотим получить элемент, который уже есть в хеш-таблице
    {
        int inState;  // внутреннее состояние кокретного объекта
        public override void Operation(int outState)
        {
            ;
        }
    }

    public class UnConcreteFlyWeight : FlyWeight  // олицетворяет новый обхект
    {
        int allState;  // внутреннее состояние кокретного объекта
        public override void Operation(int outState)
        {
            allState = outState;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int state = 10;
            FlyWeightFactory fwf = new FlyWeightFactory();
            FlyWeight flyObj1 = fwf.GetFlyWeight("1");
            flyObj1.Operation(--state);  // указываем место, куда встает цифра 1 в числе
            Console.WriteLine(state);

            FlyWeight flyObj2 = fwf.GetFlyWeight("2");
            flyObj2.Operation(--state);
            Console.WriteLine(state);

            FlyWeight flyObj3 = fwf.GetFlyWeight("9");
            flyObj3.Operation(--state);
            Console.WriteLine(state);

            UnConcreteFlyWeight ucfw = new UnConcreteFlyWeight();
            ucfw.Operation(--state);
        }
    }
}
