
using minileveldb.interfaces;

namespace minileveldb
{
    public class SkipListImpl : ISkipList
    {
        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool ContainKey(string key)
        {
            throw new NotImplementedException();
        }

        public void Delete(string key)
        {
            throw new NotImplementedException();
        }

        public string? Get(string key)
        {
            throw new NotImplementedException();
        }

        public void Put(string key, string value)
        {
            throw new NotImplementedException();
        }

        public int Size()
        {
            throw new NotImplementedException();
        }

        public int GetCurrentMaxLevel()
        {
            throw new NotImplementedException();
        }

        public int GetLevelCount()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> GetElementCountForEachLevel()
        {
            throw new NotImplementedException();
        }

        public int CountStepsToFind(string key)
        {
            throw new NotImplementedException();
        }
    }
}
