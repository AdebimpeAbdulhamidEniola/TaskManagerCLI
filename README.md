
# TaskManager CLI

A command-line interface application built with C# by Abdulhamid Eniola Adebimpe. This app allows users to add, update, delete, and view tasks, making it easy to manage to-do lists directly from the terminal. It includes features to save task lists, ensuring persistent storage between sessions.It's built for people as an app for productivity.


## Features

- Add, Update, and Delete tasks
- Mark a task as in progress or done
- List all tasks
- List all tasks that are done
- List all tasks that are not done
- List all tasks that are in progress



## How To Run?
To utilise the program on commmand line / terminal enter the following commands

### Adding new tasks
- dotnet run add <task - description>

### Updating and Deleting task
- dotnet run update <task-id> <task-description>
- dotnet run delete <task-id>

### Marking a task as in progress or done
- dotnet run mark-in-progress <task-id>
- dotnet run mark-done

### Listing all tasks
- dotnet run list

### Listing tasks by status
- dotnet run list done
- dotnet run list todo
- dotnet run list in-progress

## Screenshots

- ![Task Class](/Screenshots/taskclass.png)
- ![Datahandler Class](/Screenshots/datahandlerclass.png)
- ![Task Operation](/Screenshots/3.png)
-![Task Operation](/Screenshots/5.png)

## Project URL
[TaskManagerCLILink](url "https://github.com/AdebimpeAbdulhamidEniola/TaskManagerCLI.git")

## Credits

An handwork of Adebimpe Abdulhamid Eniola. The angry C# developer.
