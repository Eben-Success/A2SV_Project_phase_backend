using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

enum TaskCategories
{
    Work,
    Personal,
    Errands,
    Others
}

class MyTask
{
    public string Name { get; set; }
    public string Description { get; set; }
    public TaskCategories Categories { get; set; }
    public bool IsCompleted { get; set; }
}

class TaskManager
{
    private List<MyTask> tasks;
    private const string FilePath = "task.csv";

    public TaskManager()
    {
        tasks = new List<MyTask>();
    }

    public async Task LoadTasksAsync()
    {
        if (File.Exists(FilePath))
        {
            var lines = await File.ReadAllLinesAsync(FilePath);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                var task = new MyTask
                {
                    Name = parts[0],
                    Description = parts[1],
                    Categories = (TaskCategories)Enum.Parse(typeof(TaskCategories), parts[2]),
                    IsCompleted = bool.Parse(parts[3])
                };
                tasks.Add(task);
            }
        }
    }

    public async Task SaveTasksAsync()
    {
        var lines = tasks.Select(task => $"{task.Name},{task.Description},{task.Categories},{task.IsCompleted}");
        await File.WriteAllLinesAsync(FilePath, lines);
    }

    public void AddTask(MyTask task)
    {
        tasks.Add(task);
    }

    public void DisplayTasks(TaskCategories? category = null)
    {
        Console.WriteLine("Tasks:");
        var filteredTasks = category.HasValue ? tasks.Where(task => task.Categories == category) : tasks;
        foreach (var task in filteredTasks)
        {
            Console.WriteLine($"Name: {task.Name}, Description: {task.Description}, Category: {task.Categories}, Completed: {task.IsCompleted}");
        }
    }

    public void AddTaskFromUserInput()
    {
        Console.WriteLine("Enter task name:");
        var name = Console.ReadLine();

        Console.WriteLine("Enter task description:");
        var description = Console.ReadLine();

        Console.WriteLine("Enter task category (Work, Personal, Errands, Others):");
        var categoryInput = Console.ReadLine();
        if (!Enum.TryParse(categoryInput, out TaskCategories category))
        {
            Console.WriteLine("Invalid category. Task will be added to 'Others' category.");
            category = TaskCategories.Others;
        }

        var task = new MyTask
        {
            Name = name,
            Description = description,
            Categories = category,
            IsCompleted = false
        };

        AddTask(task);
        Console.WriteLine("Task added successfully.");
    }
}

class Program
{
    static async Task Main()
    {
        TaskManager taskManager = new TaskManager();
        await taskManager.LoadTasksAsync();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add a new task");
            Console.WriteLine("2. Display all tasks");
            Console.WriteLine("3. Exit");

            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    taskManager.AddTaskFromUserInput();
                    await taskManager.SaveTasksAsync();
                    break;
                case "2":
                    taskManager.DisplayTasks();
                    break;
                case "3":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
