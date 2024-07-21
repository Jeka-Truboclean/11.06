// TaskItem.cs
public class TaskItem : INotifyPropertyChanged
{
    private string title;
    public string Title
    {
        get { return title; }
        set
        {
            if (title != value)
            {
                title = value;
                OnPropertyChanged();
            }
        }
    }

    private bool isCompleted;
    public bool IsCompleted
    {
        get { return isCompleted; }
        set
        {
            if (isCompleted != value)
            {
                isCompleted = value;
                OnPropertyChanged();
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
