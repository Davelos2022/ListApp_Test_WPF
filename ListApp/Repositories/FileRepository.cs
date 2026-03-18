using ListApp.Interfaces;
using ListApp.Models;
using System.IO;

namespace ListApp.Repositories
{
    public class FileRepository : IRepository
    {
        #region Properties
        private readonly ISerializerService _serializer;
        #endregion

        #region Initilaze
        public FileRepository(ISerializerService serializer) => _serializer = serializer;
        #endregion

        #region Methods
        public void Save(string path, ListRandom list)
        {
            using var fs = File.Create(path);
            _serializer.Serialize(list, fs);
        }

        public ListRandom Load(string path)
        {
            using var fs = File.OpenRead(path);
            return _serializer.Deserialize(fs);
        }
        #endregion
    }
}
