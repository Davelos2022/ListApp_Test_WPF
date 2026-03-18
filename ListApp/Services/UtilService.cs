namespace ListApp.Services
{
    public static class UtilService
    {
        #region Methods
        public static List<int> GetRandomIndices(int count)
        {
            if (count > 0)
            {
                List<int> result = new List<int>(count);

                for (int i = 0; i < count; i++)
                {
                    result.Add(Random.Shared.Next(count));
                }

                return result;
            } 
            else
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }
        }
        #endregion
    }
}
