using ListApp.Data;

namespace ListApp.Models
{
    public class ListRandom
    {
        #region Properties
        public ListNode? Head { get; private set; }
        public ListNode? Tail { get; private set; }
        public int Count { get; private set; }
        #endregion

        #region Initialize
        public void Build(IList<string> data, IList<int> randomIndices)
        {
            if (data is not null && randomIndices is not null)
            { 
                List<ListNode> nodes = CreateNodes(data);

                GlueNodes(nodes);
                InitializeNodes(nodes);
                ApplyRandomIndices(nodes, randomIndices);
            }
            else
            {
                throw new ArgumentException(DataConstantsInfo.ERROR_BUILD_LIST_TEXT);
            }
        }
        private void InitializeNodes(List<ListNode> nodes)
        {
            if (nodes != null && nodes.Count > 0)
            {
                Head = nodes.FirstOrDefault();
                Tail = nodes.LastOrDefault();
                Count = nodes.Count;
            }
        }
        #endregion

        #region Methods
        private List<ListNode> CreateNodes(IList<string> data)
        {
            List<ListNode> nodes = new List<ListNode>();

            foreach (var d in data)
            {
                nodes.Add(new ListNode { Data = d });
            }

            return nodes;
        }

        private void GlueNodes(List<ListNode> nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (i > 0)
                {
                    nodes[i].Previous = nodes[i - 1];
                    nodes[i - 1].Next = nodes[i];
                }
            }
        }

        private void ApplyRandomIndices(List<ListNode> nodes, IList<int> randomIndices)
        {
            int n = nodes.Count;

            for (int i = 0; i < n; i++)
            {
                int rnd = (i < randomIndices.Count) ? randomIndices[i] : -1;

                if (rnd != -1 && (rnd < 0 || rnd >= n))
                    throw new ArgumentOutOfRangeException(nameof(randomIndices), 
                        string.Format(DataConstantsInfo.ERROR_RANDOM_INDICES_TEXT, rnd, n -1, i));

                nodes[i].Random = (rnd >= 0 && rnd < n) ? nodes[rnd] : null;
            }
        }

        public (List<string> data, List<int> random) Export()
        {
            List<string> data = new List<string>();
            List<int> rnd = new List<int>();

            Dictionary<ListNode, int> map = new Dictionary<ListNode, int>(Count);

            int index = 0;

            for (var cur = Head; cur != null; cur = cur.Next)
            {
                data.Add(cur.Data);
                map[cur] = index++;
            }

            for (var cur = Head; cur != null; cur = cur.Next)
            {
                rnd.Add(cur.Random != null && 
                    map.TryGetValue(cur.Random, out var r) ? r : -1);
            }

            return (data, rnd);
        }

        public IEnumerable<ViewModelNode> Enumerate()
        {
            Dictionary<ListNode, int> map = new Dictionary<ListNode, int>();
            int idx = 0;

            for (var cur = Head; cur != null; cur = cur.Next)
            {
                map[cur] = idx++;
            }

            for (var cur = Head; cur != null; cur = cur.Next)
            {
                yield return new ViewModelNode
                {
                    Index = map[cur],
                    Data = cur.Data,
                    RandomIndex = cur.Random != null &&
                    map.TryGetValue(cur.Random, out var r) ? r : -1
                };
            }
        }
        #endregion
    }
}
