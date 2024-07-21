// AddTaskWindowViewModel.cs
public class AddTaskWindowViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public event Action<TaskItem> TaskAdded;

    private string newTaskTitle;
    public string NewTaskTitle
    {
        get { return newTaskTitle; }
        set
        {
            newTaskTitle = value;
            OnPropertyChanged();
        }
    }

    private bool isCompleted;
    public bool IsCompleted
    {
        get { return isCompleted; }
        set
        {
            isCompleted = value;
            OnPropertyChanged();
        }
    }

    public ICommand AddTaskCommand { get; private set; }

    public AddTaskWindowViewModel()
    {
        AddTaskCommand = new RelayCommand(param => AddTask(), param => !string.IsNullOrEmpty(NewTaskTitle));
    }

    private void AddTask()
    {
        TaskItem newTask = new TaskItem
        {
            Title = NewTaskTitle,
            IsCompleted = IsCompleted
        };

        TaskAdded?.Invoke(newTask);
    }

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
