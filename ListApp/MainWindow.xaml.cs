using ListApp.Data;
using ListApp.Factories;
using ListApp.Interfaces;
using ListApp.Models;
using System.Windows;

namespace ListApp
{
    public partial class MainWindow : Window
    {
        #region Propertys
        private readonly IFileDialogService _dialogs;
        private readonly IRepository _repo;

        private ListRandom _current;
        #endregion

        #region Initialization
        public MainWindow(IFileDialogService dialogs, IRepository repo)
        {
            InitializeComponent();

            _dialogs = dialogs;
            _repo = repo;
        }
        #endregion

        #region Methods
        private void BtnGenerate_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TxtData.Text))
            {
                MessageBox.Show(DataConstantsInfo.ERROR_INPUT_TEXT, DataConstantsInfo.
                    TITLE_ERROR_TEXT, MessageBoxButton.OK, MessageBoxImage.Warning);

                return;
            }

            try
            {
                _current = ListRandomFactory.CreateListRandom(TxtData.Text);

                GridOriginal.ItemsSource = _current.Enumerate();
                GridRestored.ItemsSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(DataConstantsInfo.ERROR_GENERATE_TEXT, ex.Message),
                    DataConstantsInfo.TITLE_ERROR_TEXT, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnSerialize_Click(object sender, RoutedEventArgs e)
        {
            if (_current == null)
            {
                MessageBox.Show(DataConstantsInfo.ERROR_GENERATE_NULL_TEXT, DataConstantsInfo.TITLE_ERROR_TEXT,
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var path = _dialogs.ShowSaveDialog(
                filter: DataConstantsInfo.VALUE_FILTER_TEXT,
                defaultExt: DataConstantsInfo.DEFAULT_FILE_TEXT
            );


            if (path == null) return;

            try
            {
                _repo.Save(path, _current);

                MessageBox.Show(string.Format(DataConstantsInfo.SAVE_INFO_TEXT, _current.Count, path),
                    DataConstantsInfo.TITLE_OK_TEXT,
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(DataConstantsInfo.ERROR_SAVE_TEXT, ex),
                                DataConstantsInfo.TITLE_ERROR_TEXT, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnDeserialize_Click(object sender, RoutedEventArgs e)
        {
            var path = _dialogs.ShowOpenDialog(
                filter: DataConstantsInfo.VALUE_FILTER_TEXT,
                defaultExt: DataConstantsInfo.DEFAULT_FILE_TEXT
            );


            if (path == null) return;

            try
            {
                _current = _repo.Load(path);

                MessageBox.Show(string.Format(DataConstantsInfo.LOAD_INFO_TEXT, _current.Count, path),
                    DataConstantsInfo.TITLE_OK_TEXT,
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );

                GridRestored.ItemsSource = _current.Enumerate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(DataConstantsInfo.ERROR_LOAD_TEXT, ex),
                               DataConstantsInfo.TITLE_ERROR_TEXT, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
