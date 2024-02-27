using System;
using System.Collections.Generic;

// Định nghĩa delegate cho sự kiện thay đổi trạng thái của công việc
delegate void TaskStatusChangedEventHandler(object sender, TaskStatusChangedEventArgs e);

// Định nghĩa lớp chứa thông tin về sự kiện
class TaskStatusChangedEventArgs : EventArgs
{
    public string TaskName { get; set; }
    public bool IsCompleted { get; set; }
}

// Định nghĩa lớp công việc
class Task
{
    public string Name { get; set; }
    private bool isCompleted;

    // Sự kiện thay đổi trạng thái của công việc
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

    // Phương thức kích hoạt sự kiện khi trạng thái của công việc thay đổi
    protected virtual void OnTaskStatusChanged()
    {
        TaskStatusChanged?.Invoke(this, new TaskStatusChangedEventArgs { TaskName = Name, IsCompleted = IsCompleted });
    }
}

// Lớp quản lý danh sách công việc
class TaskManager
{
    private List<Task> tasks = new List<Task>();

    // Phương thức thêm công việc mới
    public void AddTask(Task task)
    {
        tasks.Add(task);
        task.TaskStatusChanged += HandleTaskStatusChanged;
    }

    // Phương thức hiển thị danh sách công việc cùng trạng thái
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

    // Phương thức đánh dấu công việc là đã hoàn thành hoặc chưa hoàn thành
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

    // Xử lý sự kiện thay đổi trạng thái của công việc
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

        // Thêm công việc
        Task task1 = new Task { Name = "Task 1" };
        Task task2 = new Task { Name = "Task 2" };
        taskManager.AddTask(task1);
        taskManager.AddTask(task2);

        // Hiển thị danh sách công việc chưa hoàn thành
        taskManager.DisplayTasks(false);

        // Đánh dấu công việc là đã hoàn thành và hiển thị lại danh sách
        taskManager.MarkTaskStatus("Task 1", true);
        taskManager.DisplayTasks(false);

        Console.ReadLine();
    }
}
