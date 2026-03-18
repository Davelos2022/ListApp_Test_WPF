using ListApp.Models;
using ListApp.Interfaces;
using System.IO;
using System.Text;
using ListApp.Data;

namespace ListApp.Services
{
    public class SerializerService : ISerializerService
    {
        #region Methods
        public void Serialize(ListRandom list, Stream s)
        {
            (List<string> data, List<int> rnd) = list.Export();

            using var writer = new BinaryWriter(s, Encoding.UTF8, leaveOpen: true);

            writer.Write(DataConstantsInfo.FILE_SIGNATURE);
            writer.Write(DataConstantsInfo.VERSION);
            writer.Write(data.Count);

            for (int i = 0; i < data.Count; i++)
            {
                writer.Write(data[i] ?? string.Empty);
                writer.Write(rnd[i]);
            }
        }

        public ListRandom Deserialize(Stream s)
        {
            using var reader = new BinaryReader(s, Encoding.UTF8, leaveOpen: true);

            var magic = reader.ReadUInt32();
            if (magic != DataConstantsInfo.FILE_SIGNATURE)
                throw new InvalidDataException(DataConstantsInfo.ERROR_READ_FILE_TEXT);

            var version = reader.ReadInt32();
            if (version != DataConstantsInfo.VERSION)
                throw new InvalidDataException(string.Format(DataConstantsInfo.ERROR_VERSION_TEXT, version));

            int count = reader.ReadInt32();
            if (count < 0) throw new InvalidDataException
                    (string.Format(DataConstantsInfo.ERROR_NEGATIVE_COUNT_TEXT));

            var data = new List<string>(count);
            var rnd = new List<int>(count);

            for (int i = 0; i < count; i++)
            {
                data.Add(reader.ReadString());
                rnd.Add(reader.ReadInt32());
            }

            var list = new ListRandom();
            list.Build(data, rnd);

            return list;
        }
        #endregion
    }
}
