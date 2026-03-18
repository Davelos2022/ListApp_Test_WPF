namespace ListApp.Interfaces
{
    public interface IFileDialogService
    {
        string? ShowSaveDialog(string filter, string defaultExt);

        string? ShowOpenDialog(string filter, string defaultExt);
    }
}
