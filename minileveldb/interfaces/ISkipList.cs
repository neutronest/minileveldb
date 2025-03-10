﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minileveldb.interfaces
{
    public interface ISkipList
    {
        void Put(string key, string value);

        string? Get(string key);

        void Delete(string key);

        bool ContainKey(string key);

        void Clear();

        int Size();

        int GetLevelCount();

        int GetCurrentMaxLevel();

        IEnumerable<int> GetElementCountForEachLevel();
    }
}
