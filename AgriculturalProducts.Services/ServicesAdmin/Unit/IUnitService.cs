using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Services
{
    public interface IUnitService : IBaseService<Unit>
    {
        void InsertUnit(List<Unit> unit);
        void UpdateUnit(List<Unit> unit);
        IEnumerable<Unit> GetAllUnit();
        void DeleteUnit(List<Unit> unit);
        Task<Unit> FindUnitById(Guid id);

    }
}
