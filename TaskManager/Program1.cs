namespace TaskManager1;

enum TaskCategories
{
    Work,
    Personal,
    Errands,
    Others
}

class Task1
{
    public string Name { get; set; }
    public string Description { get; set; }
    public TaskCategories Categories { get; set; }
    public bool isCompleted { get; set; }
}

class UtilityFunctions
{
    public List<Task1> tasks;
    private const string FilePath = "task.csv";

    public UtilityFunctions()
    {
        tasks = new List<Task1>();
    }

    public async Task LoadTask()
    {
        if (File.Exists(FilePath))
        {
            var lines = await File.ReadAllLinesAsync(FilePath);
            
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                var task = new Task1
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

    public void AddTask(Task1 task)
    {
        tasks.Add(task);
    }
}