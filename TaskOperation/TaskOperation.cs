using DatahandlerClass;
using TaskClass;
namespace TaskOperationclass;
public class TaskOperation
{
    private Datahandler _datahandler;
    private List<TaskWork> _task;

    public TaskOperation() {
        _datahandler = new Datahandler();
        _task = _datahandler.LoadTask();
    }

    public void Addtask(string description) {
        //Give new task an Id
        int id = _task.Count == 0 ? 1 : _task.Max(t => t.Id) + 1;

        // Create a new task and add it to the task list
        TaskWork newTask = new TaskWork(); 

        newTask.Id = id;
        newTask.Description  = description;
        _task.Add(newTask);     //add the new task to the list of  task
        _datahandler.SaveTask(_task);  //Save the task to the list of task
        Console.WriteLine($"Task {newTask.Description} has been added succesfully!");   
    }

    public void DeleteTask(int deleteId){
        //We firstly have to search for the Id of the task before we can delete it;
        if (_task.Count == 0) return;

        TaskWork? task = _task.FirstOrDefault(t => t.Id == deleteId);  //find the task by its ID
        if (task == null) {
            Console.WriteLine("Task not found!!!");
            return;
        }
        _task.Remove(task);
        _datahandler.SaveTask(_task);     //Save the updated task list
        Console.WriteLine($"Task {task.Description} has successfully been removed");
        }

    public void UpdateTask(int updateId, string? newdescription = null){
         if (_task.Count == 0) return;
        TaskWork? task = _task.FirstOrDefault(t => t.Id == updateId);  //find the task by its ID
        if (task == null) {
            Console.WriteLine("Task not found!!!");
            return;
        }

        task.Description = newdescription;
        task.UpdatedAt = DateTime.Now;
        task.Id =  updateId;

        //Now we need to save our task
        _datahandler.SaveTask(_task);
        Console.WriteLine("Task has been successfully updated");
    }

    public void InProgress(int id){
        ChangeStatus("in progress", id);
    }

    public void Done(int id){
        ChangeStatus("done", id);
    }

    public void ChangeStatus(string status, int id) {
            //Find the task by its ID    
            TaskWork? task = _task.FirstOrDefault( t => t.Id == id);
            if (task == null) return;
            task.Status = status;
            //Since its like we are updating our task
            task.UpdatedAt = DateTime.Now;
            //Save this to our database 
            _datahandler.SaveTask(_task);
            Console.WriteLine("Task status has successfully been changed");

        }

    public void ListTask(string? status = null) {
        if (_task.Count == 0) {
            Console.WriteLine("Empty task list");
            return;
        }
        if (status == null) {
            foreach (var task in _task) {
                Console.WriteLine($"{task.Id}   {task.Description}  {task.Status}   {task.CreateAt} {task.UpdatedAt} ");
            }
            return; 
        }
        else if (status.ToLower() == "in-progress") {
            List<TaskWork>? inProgressTasks = _task.Where(t => t.Status == "in progress").ToList();
            foreach (var task in inProgressTasks) {
                Console.WriteLine($"{task.Id}   {task.Description}  {task.Status}   {task.CreateAt} {task.UpdatedAt} ");
            }
            return;
        }

        else if (status.ToLower() == "done") {
              List<TaskWork>? doneTasks = _task.Where(t => t.Status == "done").ToList();
            foreach (var task in doneTasks) {
                Console.WriteLine($"{task.Id}   {task.Description}  {task.Status}   {task.CreateAt} {task.UpdatedAt} ");
            }
            return;
        }
         else if (status.ToLower() == "todo") {
              List<TaskWork>? todoTasks = _task.Where(t => t.Status == "to do").ToList();
            foreach (var task in todoTasks) {
                Console.WriteLine($"{task.Id}   {task.Description}  {task.Status}   {task.CreateAt} {task.UpdatedAt} ");
            }
            return;
        

    }


 }

}
