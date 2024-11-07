namespace TaskClass;

public class TaskWork
{
public int Id {get; set;}
public string? Status{get;set;} = "to do";
public string? Description {get; set;}
public DateTime CreateAt {get;set;} = DateTime.Now;

public DateTime? UpdatedAt{get;set;}  = DateTime.Now;
}
