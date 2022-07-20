using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AmazingApp.Services
{
    public interface IRelationDataStore<T>
    {
        Task<IEnumerable<T>> GetRelationList();
    }
}
