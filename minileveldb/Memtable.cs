using minileveldb.interfaces;

namespace minileveldb
{
    public class Memtable : IMemTable
    {
        public ISkipList skipList;

        public Memtable(ISkipList skipList)
        {
            this.skipList = skipList;
        }

        public string Get(string key)
        {
            throw new NotImplementedException();
        }

        public void Put(string key, string value)
        {
            throw new NotImplementedException();
        }
    }
}
