// MainWindowViewModel.cs
public class MainWindowViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private ObservableCollection<TaskItem> tasks;
    public ObservableCollection<TaskItem> Tasks
    {
        get { return tasks; }
        set
        {
            tasks = value;
            OnPropertyChanged();
        }
    }

    public ICommand AddTaskCommand { get; private set; }
    public ICommand ChangeStatusCommand { get; private set; }
    public ICommand DeleteTaskCommand { get; private set; }

    public MainWindowViewModel()
    {
        Tasks = new ObservableCollection<TaskItem>();
        AddTaskCommand = new RelayCommand(param => OpenAddTaskWindow());
        ChangeStatusCommand = new RelayCommand(param => ChangeTaskStatus(param as TaskItem));
        DeleteTaskCommand = new RelayCommand(param => DeleteTask(param as TaskItem));
    }

    private void OpenAddTaskWindow()
    {
        var addTaskWindow = new AddTaskWindow();
        var addTaskViewModel = new AddTaskWindowViewModel();
        addTaskViewModel.TaskAdded += AddTaskViewModel_TaskAdded;
        addTaskWindow.DataContext = addTaskViewModel;
        addTaskWindow.ShowDialog();
    }

    private void AddTaskViewModel_TaskAdded(TaskItem task)
    {
        Tasks.Add(task);
    }

    private void ChangeTaskStatus(TaskItem task)
    {
        task.IsCompleted = !task.IsCompleted;
    }

    private void DeleteTask(TaskItem task)
    {
        Tasks.Remove(task);
    }

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
