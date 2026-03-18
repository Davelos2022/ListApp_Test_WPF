using Microsoft.Win32;
using ListApp.Interfaces;

namespace ListApp.Services
{
    public class FileDialogService : IFileDialogService
    {
        #region Methods
        public string? ShowSaveDialog(string filter, string defaultExt)
        {
            var dlg = new SaveFileDialog
            {
                Filter = filter,
                DefaultExt = defaultExt
            };

            return dlg.ShowDialog() == true ? dlg.FileName : null;
        }

        public string? ShowOpenDialog(string filter, string defaultExt)
        {
            var dlg = new OpenFileDialog
            {
                Filter = filter,
                DefaultExt = defaultExt
            };

            return dlg.ShowDialog() == true ? dlg.FileName : null;
        }
        #endregion
    }
}
