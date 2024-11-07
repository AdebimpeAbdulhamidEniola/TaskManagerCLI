using System.Text.Json;
using System.Text.Json.Serialization;
using TaskClass;
namespace DatahandlerClass;
public class Datahandler
{
    private const string FilePath = "task.json";

    public List<TaskWork> LoadTask(){
        if (!File.Exists(FilePath)) return new List<TaskWork>();    //If the file does not exist then return an empty list

        string json = File.ReadAllText(FilePath);   
        return JsonSerializer.Deserialize<List<TaskWork>>(json) ?? new List<TaskWork>();
    }

    public void SaveTask(List<TaskWork> task) {
        string json = JsonSerializer.Serialize(task, new JsonSerializerOptions {WriteIndented = true});
        File.WriteAllText(FilePath,json); 
    }

}
