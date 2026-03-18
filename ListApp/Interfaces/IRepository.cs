using ListApp.Models;

namespace ListApp.Interfaces
{
    public interface IRepository
    {
        void Save(string path, ListRandom list);
        ListRandom Load(string path);
    }
}
