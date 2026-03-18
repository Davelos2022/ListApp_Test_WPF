namespace ListApp.Data
{
    public class DataConstantsInfo
    {
        #region DataInfo
        public const string VALUE_FILTER_TEXT = "Binary (*.bin)|*.bin|All (*.*)|*.*";
        public const string DEFAULT_FILE_TEXT = ".bin";

        public const uint FILE_SIGNATURE = 0x4C524E44;
        public const int VERSION = 1;
        #endregion

        #region MessageInfo
        //Tite
        public const string TITLE_ERROR_TEXT = "Error";
        public const string TITLE_OK_TEXT = "Successfully";

        //Errors
        public const string ERROR_GENERATE_NULL_TEXT = "First click Generate";
        public const string ERROR_GENERATE_TEXT = "Error generation: {0}";
        public const string ERROR_LOAD_TEXT = "Error loading {0}";
        public const string ERROR_SAVE_TEXT = "Error save {0}";
        public const string ERROR_INPUT_TEXT = "Enter the elements separated by a comma";
        public const string ERROR_BUILD_LIST_TEXT = "Error create list";
        public const string ERROR_RANDOM_INDICES_TEXT = "Random index {0} out of range [0..{1}] at position {2}";

        public const string ERROR_READ_FILE_TEXT = "Invalid file format: magic header mismatch.";
        public const string ERROR_VERSION_TEXT = "Unsupported format version: {0}.";
        public const string ERROR_NEGATIVE_COUNT_TEXT = "Negative count.";

        //Info
        public const string SAVE_INFO_TEXT = "Save {0} nodes in file\n\nPath: {1}";
        public const string LOAD_INFO_TEXT = "Load {0} nodes from file\n\nPath :{1}";
        #endregion
    }
}
