
namespace minileveldb
{
    public class SkipListNode
    {
        public string Key { get; }
        public string Value { get; set; }
        public List<SkipListNode?> Forward { get; }

        public SkipListNode(string key, string value, int level)
        {
            Key = key;
            Value = value;
            Forward = new List<SkipListNode?>(new SkipListNode?[level + 1]);
        }
    }
}
