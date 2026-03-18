using ListApp.Models;
using ListApp.Services;

namespace ListApp.Factories
{
    #region Methods
    public static class ListRandomFactory
    {
        public static ListRandom CreateListRandom(string rawData)
        {
            if (rawData is not null)
            {
                ListRandom list = new ListRandom();

                List<string> data = rawData.Split(',', StringSplitOptions.RemoveEmptyEntries
                    | StringSplitOptions.TrimEntries).ToList();

                List<int> indices = UtilService.GetRandomIndices(data.Count);
                list.Build(data, indices);

                return list;
            }
            else
            {
                throw new ArgumentNullException(nameof(rawData));
            }
        }
    }
    #endregion
}
