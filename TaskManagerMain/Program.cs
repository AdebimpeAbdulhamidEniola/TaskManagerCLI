using System.Runtime.InteropServices;
using TaskOperationclass;
namespace TaskManagerMain;

class Program
{
    static void Main(string[] args)
    {
        TaskOperation taskOperation = new TaskOperation();
        if (args.Length == 0) {
            Console.WriteLine("Please provide a command");
            return;
        }
        string command = args[0].ToLower();

        switch (command) {
            case "add":
                if (args.Length != 2) {
                    Console.WriteLine(" Error in Usage: <add> <name_of_task)");
                    return;
                }
                taskOperation.Addtask(args[1]);
                break;

            case "delete":
                if (args.Length != 2  || !(int.TryParse(args[1], out int result)))
                {
                    Console.WriteLine("Error in Usage:<delete> <task Id>");
                    return;
                }
                taskOperation.DeleteTask(result);
                break;
            
            case "update":
                if (args.Length != 3 || !(int.TryParse(args[1], out int newNum)) ) {
                    
                    Console.WriteLine("Error in Usage:<update> <task Id> <description>");
                    return;
                }
                taskOperation.UpdateTask(newNum, args[2]);
                break;
            
            case "mark-in-progress":
             if (args.Length != 2 || !(int.TryParse(args[1], out int newResult)) ) {
                Console.WriteLine("Error in Usage: <mark-in-progress> <task Id>");
                return;
             }
            taskOperation.InProgress(newResult);
            break;
        

             case "mark-done":
             if (args.Length != 2 || !(int.TryParse(args[1], out int newR)) ) {
                Console.WriteLine("Error in Usage: <mark-in-progress> <task Id>");
                return;
             }
            taskOperation.Done(newR);
            break;

            case "list":
                if (args.Length ==  1)
                    taskOperation.ListTask();
                else if(args[1] == "done" && args.Length == 2)
                    taskOperation.ListTask("done");
                else if (args[1] == "in-progress"  && args.Length == 2)
                    taskOperation.ListTask("in-progress");
                 else if (args[1] == "todo"  && args.Length == 2)
                    taskOperation.ListTask("todo");
                else 
                    Console.WriteLine("Invalid  task status");
                break;

            default:
                Console.WriteLine("Error check your input arguments");
                break;
        }


    }
}
