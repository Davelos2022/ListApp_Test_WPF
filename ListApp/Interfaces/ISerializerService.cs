using ListApp.Models;
using System.IO;

namespace ListApp.Interfaces
{
    public interface ISerializerService
    {
        void Serialize(ListRandom list, Stream s);
        ListRandom Deserialize(Stream s);
    }
}
