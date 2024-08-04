using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pattern_Composite
{
    public abstract class Button 
    {
        protected string button_name;
        protected string parent_name;

        protected Button(string name)
        {
            button_name = name;
        }
        public void SetParentName(string name) 
        { 
            parent_name = name;
        }
        public virtual void Add(Button sub_buttom) { }  // sub_buttom - вложенная кнопка 
        public virtual void Remove(Button sub_buttom) { }  // метод для удаления кнопок
        public abstract void Display();
        // абстрактные методы обязательно реализовавть в классах наследниках, а виртуальные нет (их МОЖНО переписать в них)
    }

    public class ClickableButton : Button
    {
        public ClickableButton(string name) : base(name) { }
        public override void Add(Button sub_buttom)
        {
            throw new Exception();   // нельзя добавить кнопку
        }
        public override void Remove(Button sub_buttom)
        {
            throw new Exception();   // нельзя добавить кнопку
        }
        public override void Display() 
        { 
            Console.WriteLine(button_name);  
        }
    }

    public class ButtonDropMenu : Button
    {
        List<Button> childrens;
        public ButtonDropMenu(string name) : base(name)   // обращение к родительскому классу
        { 
            childrens = new List<Button>();
        }
        public override void Add(Button sub_buttom)
        {
            childrens.Add(sub_buttom);   // добавляем под-кнопки
            sub_buttom.SetParentName(this.button_name);  // записываем имя родительской кнопки
        }
        public override void Remove(Button sub_buttom)
        {
            childrens.Remove(sub_buttom);  // удаляем указанную кнопку
        }

        public override void Display()
        {

            foreach (Button sub_buttom in childrens)
            {
                if (parent_name != null)
                {
                    Console.Write(parent_name + button_name);
                }
                sub_buttom.Display();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Button file = new ButtonDropMenu("File->");
            Button create = new ButtonDropMenu("Create->");
            Button open = new ButtonDropMenu("Open->");
            Button exit = new ClickableButton("Exit");

            file.Add(create);
            file.Add(open);
            file.Add(exit);

            Button project = new ClickableButton("Project");
            Button repository = new ClickableButton("Repository");

            create.Add(project);
            create.Add(repository);

            Button solution = new ClickableButton("Solution");
            Button folder = new ClickableButton("Folder");

            open.Add(solution);
            open.Add(folder);

            file.Display();

            Console.WriteLine("--------------------");

            open.Remove(folder);

            file.Display();

            Console.WriteLine("--------------------");

            file.Remove(create);

            file.Display();
        }
    }
}
