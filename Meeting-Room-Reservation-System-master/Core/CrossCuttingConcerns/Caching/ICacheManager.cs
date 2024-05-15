using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        void Add(string key, object value, int duration);
        T Get<T>(string key);//veri türünden bağımsız data getirme
        bool IsAdd(string key);//casheden var mı
        void Remove(string key);//sil
        object Get(string key);
        void RemoveByPattern(string pattern);//içinde ...v olanları uçur

    }
}
