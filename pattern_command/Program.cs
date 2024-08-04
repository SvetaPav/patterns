using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace pattern_command
{
    public interface ICommand 
    {
        void Positive(); // отвечает за включение или увеличение
        void Negative();  // наоборот
    }

    public class Conveyer
    {
        public void On() => Console.WriteLine("Конвейер запущен");
        public void Off() => Console.WriteLine("Конвейер остановлен");
        public void SpeedIncrease() => Console.WriteLine("Скорость конвейера увеличена");
        public void SpeedDecrease() => Console.WriteLine("Скорость конвейера снижена");
    }

    public class ConveyerWorkCommand : ICommand 
    {
        private Conveyer conveyer;
        public ConveyerWorkCommand(Conveyer conveyer)
        {
            this.conveyer = conveyer;
        }
        public void Positive()
        {
            conveyer.On();
        }
        public void Negative() => conveyer.Off();
    }

    public class ConveyerSpeedAdjustCommand : ICommand   // регулировка скорости на конвейере
    {
        private Conveyer conveyer;
        public ConveyerSpeedAdjustCommand(Conveyer conveyer) 
        {
            this.conveyer = conveyer;
        }
        public void Positive()
        {
            conveyer.SpeedIncrease();
        }
        public void Negative() => conveyer.SpeedDecrease();
    }

    public class Controller  // пульт
    {
        private List<ICommand> commands;
        private Stack<ICommand> history;  // хранение истории нажатия
        public Controller()
        {
            commands = new List<ICommand> { null, null };
            history = new Stack<ICommand>();
        }
        public void SetCommand(int button, ICommand command) => commands[button] = command; // обращаемся к списку по индексу и записываем туда команду
        public void PressOn(int button) // передаем номер объекта, который хотим нажать
        {
            commands[button].Positive();
            history.Push(commands[button]);
        }

        public void PressCancel()  // отменяем последнее действие
        {
            if(history.Count > 0) history.Pop().Negative();  // у последнего действия вызываем Negative
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Conveyer conveyer = new Conveyer();
            Controller controller = new Controller();

            controller.SetCommand(0, new ConveyerWorkCommand(conveyer));
            controller.SetCommand(1, new ConveyerSpeedAdjustCommand(conveyer));

            controller.PressOn(0);  // Конвейер запущен
            controller.PressOn(1);  // Скорость конвейера увеличена
            controller.PressOn(1);  // Скорость конвейера увеличена

            controller.PressCancel();  // Скорость конвейера снижена
            controller.PressCancel();  // Скорость конвейера снижена
            controller.PressCancel();  // Конвейер остановлен
        }
    }
}
