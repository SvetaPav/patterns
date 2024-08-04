using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hero player1 = new Hero(new Dragon());
            Console.WriteLine("Первый игрок:");
            player1.Hit();
            player1.Move();

            Hero player2 = new Hero(new Goblin());
            Console.WriteLine("Второй игрок:"); 
            player2.Hit();
            player2.Move();
        }
    }

    public abstract class Movement
    {
        public abstract void Move();
    }

    public class RunMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Персонаж бежит...");  // заглушка
        }
    }

    public class FlyMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Персонаж летит..."); // заглушка
        }
    }

    public class SwimMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Персонаж плывет..."); // заглушка
        }
    }

    public abstract class Weapon 
    { 
        public abstract void Hit();
    }

    public class Gun : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Выстрел пистолета...");  // заглушка
        }
    }

    public class Arbalet : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Выстрел из арбалета...");  // заглушка
        }
    }

    public class Knife : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Удар ножом..."); // заглушка
        }
    }

   
    abstract public class HeroFactory
    {
        public abstract Movement CreateMovement();  // возвращаемый тип - Movement
        public abstract Weapon CreateWeapon();
    }

    public class Hero   // класс для взаимодействия с игроком
    {
        private Weapon _weapon;
        private Movement _movement;

        public Hero(HeroFactory factory)
        {
            _weapon = factory.CreateWeapon();
            _movement = factory.CreateMovement();

        }

        public void Move()
        {
            _movement.Move(); // выведет на экран тип передвижения
        }
        public void Hit()
        {
            _weapon.Hit(); // выведет на экран тип оружия
        }

    }


    public class Goblin : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new RunMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Knife();
        }
    }

    public class Dragon : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new FlyMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Arbalet();
        }
    }

    public abstract class Shape
    {
        public int A { get; set; }
        public int B { get; set; }
        public abstract void CalculateSquare();
    }

    interface IShape 
    { 
        void CalculateSquare();
    }

    public class Rectangle : Shape  // мы можем наследовать класс только один раз, поэтому лучше использовать интерфейсы
    {
        public override void CalculateSquare()
        {
            Console.WriteLine(A*B);
        }
    }


}
