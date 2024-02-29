using System;
using System.Collections.Generic;


delegate void TaskStatusChangedEventHandler(object sender, TaskStatusChangedEventArgs e);


class TaskStatusChangedEventArgs : EventArgs
{
    public string TaskName { get; set; }
    public bool IsCompleted { get; set; }
}


class Task
{
    public string Name { get; set; }
    private bool isCompleted;

 
    public event TaskStatusChangedEventHandler TaskStatusChanged;

    public bool IsCompleted
    {
        get { return isCompleted; }
        set
        {
            if (isCompleted != value)
            {
                isCompleted = value;
                OnTaskStatusChanged();
            }
        }
    }

   
    protected virtual void OnTaskStatusChanged()
    {
        TaskStatusChanged?.Invoke(this, new TaskStatusChangedEventArgs { TaskName = Name, IsCompleted = IsCompleted });
    }
}


class TaskManager
{
    private List<Task> tasks = new List<Task>();

    
    public void AddTask(Task task)
    {
        tasks.Add(task);
        task.TaskStatusChanged += HandleTaskStatusChanged;
    }

    
    public void DisplayTasks(bool completed)
    {
        Console.WriteLine($"Tasks with status {(completed ? "completed" : "not completed")}:");
        foreach (var task in tasks)
        {
            if (task.IsCompleted == completed)
            {
                Console.WriteLine($"- {task.Name} ({(task.IsCompleted ? "completed" : "not completed")})");
            }
        }
        Console.WriteLine();
    }


    public void MarkTaskStatus(string taskName, bool completed)
    {
        Task task = tasks.Find(t => t.Name == taskName);
        if (task != null)
        {
            task.IsCompleted = completed;
        }
        else
        {
            Console.WriteLine($"Task '{taskName}' not found.");
        }
    }

   
    private void HandleTaskStatusChanged(object sender, TaskStatusChangedEventArgs e)
    {
        Console.WriteLine($"Task '{e.TaskName}' status changed to {(e.IsCompleted ? "completed" : "not completed")}");
    }
}

class Program
{
    static void Main()
    {
        TaskManager taskManager = new TaskManager();

       
        Task task1 = new Task { Name = "Task 1" };
        Task task2 = new Task { Name = "Task 2" };
        taskManager.AddTask(task1);
        taskManager.AddTask(task2);

       
        taskManager.DisplayTasks(false);

       
        taskManager.MarkTaskStatus("Task 1", true);
        taskManager.DisplayTasks(false);

        Console.ReadLine();
    }
}
