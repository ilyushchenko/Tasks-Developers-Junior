using System;

namespace TaskThree
{
    class CreateAction : ICrudAction
    {
        public void Execute()
        {
            Console.WriteLine(ActionType.Create.ToString());
        }
    }

    class ReadAction : ICrudAction
    {
        public void Execute()
        {
            Console.WriteLine(ActionType.Read.ToString());
        }
    }

    class UpdateAction : ICrudAction
    {
        public void Execute()
        {
            Console.WriteLine(ActionType.Update.ToString());
        }
    }

    class DeleteAction : ICrudAction
    {
        public void Execute()
        {
            Console.WriteLine(ActionType.Delete.ToString());
        }
    }
}
