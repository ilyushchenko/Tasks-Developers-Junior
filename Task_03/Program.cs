using System;
using System.Collections.Generic;

namespace TaskThree
{

    /// Задача - перепишите данный код так, чтобы он работал через коллекции C#, вместо конструкции switch


    public enum ActionType
    {
        Create,

        Read,

        Update,

        Delete
        
    }

    public delegate void CrudAction(ActionType type);

    class Program
    {
        static void Main(string[] args)
        {
            // 1 вариант
            // Выбираем необходимый метод по типу (предположим, что они выполняют разные действия)
            // Выполняем
            var dictinaryActions = new Dictionary<ActionType, CrudAction>
            {
                { ActionType.Create, CreateMethod },
                { ActionType.Read, ReadMethod },
                { ActionType.Update, UpdateMethod },
                { ActionType.Delete, DeleteMethod }
            };

            var type = ActionType.Read;

            dictinaryActions[type].Invoke(type);

            // Вариант 2
            // Выбираем необходимую реализацию
            var interfaceActions = new List<ICrudAction>()
            {
                new CreateAction(),
                new ReadAction(),
                new UpdateAction(),
                new DeleteAction(),
            };

            foreach (var action in interfaceActions)
            {
                action.Execute();
            }
        }

        private static void CreateMethod(ActionType type)
        {
            Console.WriteLine(type.ToString());
        }

        private static void ReadMethod(ActionType type)
        {
            Console.WriteLine(type.ToString());
        }

        private static void UpdateMethod(ActionType type)
        {
            Console.WriteLine(type.ToString());
        }

        private static void DeleteMethod(ActionType type)
        {
            Console.WriteLine(type.ToString());
        }
    }
}
