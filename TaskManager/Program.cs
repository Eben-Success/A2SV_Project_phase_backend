using System;
using System.Threading.Tasks;

enum TaskCategories
{
    Work,
    Personal,
    Errands,
    Others
}

class Task
{
    public string Name { get; set; }
    public string Description { get; set; }
    public TaskCategories Categories { get; set; }
    public bool isCompleted { get; set; }
}

class TaskManager
{
    private List<Task> tasks;
    private const string FilePath = "task.csv";

    public TaskManager()
    {
        tasks = new List<Task>();
    }

    public async Task LoadTask()
    {
        try
        {
            if (File.Exists(FilePath))
            {
                var lines = await File.ReadAllLinesAsync(FilePath);

                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    var task = new Task
                    {
                        Name = parts[0],
                        Description = parts[1],
                        Categories = (TaskCategories)Enum.Parse(typeof(TaskCategories), parts[2]),
                        isCompleted = bool.Parse(parts[3])
                    };
                    tasks.Add(task);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error loading tasks: {e.Message}");
        }
    }

    public async Task SaveTask()
    {
        try
        {
            var lines = tasks.Select(task => $"{task.Name}, {task.Description}, {task.Categories}, {task.isCompleted}");
            await File.WriteAllLinesAsync(FilePath, lines);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error saving tasks: {e.Message}");
        }
    }

    public void AddTask(Task task)
    {
        tasks.Add(task);
    }

    public void DisplayTask(TaskCategories? categories = null)
    {
        Console.WriteLine("Tasks:");

        IEnumerable<Task> filteredTasks = tasks;

        if (categories.HasValue)
        {
            filteredTasks = tasks.Where(task => task.Categories == categories.Value);
        }

        foreach (var task in filteredTasks)
        {
            Console.WriteLine($"Name: {task.Name}, Description: {task.Description}, Categories: {task.Categories}, Completed: {task.isCompleted}");
        }
    }
}

class Program
{
    static async Task Main()
    {
        TaskManager taskManager = new TaskManager();

        // Load tasks from file
        await taskManager.LoadTask();

        // Add tasks
        taskManager.AddTask(new Task { Name = "Task 1", Description = "Description 1", Categories = TaskCategories.Work, isCompleted = false });
        taskManager.AddTask(new Task { Name = "Task 2", Description = "Description 2", Categories = TaskCategories.Personal, isCompleted = false });

        // Display tasks
        taskManager.DisplayTask();

        // Save tasks to file
        await taskManager.SaveTask();
    }
}
