namespace ListApp.Models
{
    public class ListNode
    {
        #region Properties
        public ListNode? Previous { get; set; }
        public ListNode? Next { get; set; }
        public ListNode? Random { get; set; }
        public string Data { get; set; } = string.Empty;
        #endregion
    }
}
