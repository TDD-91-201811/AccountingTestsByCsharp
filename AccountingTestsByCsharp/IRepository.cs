using System.Collections.Generic;

namespace AccountingTestsByCsharp
{
    public interface IRepository<T>
    {
        List<Budget> GetAll();
    }
}