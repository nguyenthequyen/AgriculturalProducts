using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Services
{
    public class StatusCartsService : BaseService<StatusCart>, IStatusCartsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStatusCartsRepository _reponsitory;
        public StatusCartsService(IUnitOfWork unitOfWork, IStatusCartsRepository reponsitory) : base(unitOfWork, reponsitory)
        {
            _unitOfWork = unitOfWork;
            _reponsitory = reponsitory;
        }

        public List<StatusCart> GetStatusCart(Guid id)
        {
            return _reponsitory.GetStatusCart(id);
        }

        public StatusCart GetStatusCartsClient()
        {
            return _reponsitory.GetStatusCartsClient();
        }

        public void InsertStatusCart(StatusCart statusCart)
        {
            statusCart.CreatedDate = DateTime.Now;
            statusCart.ModifyDate = DateTime.Now;
            statusCart.Id = Guid.NewGuid();
            Add(statusCart);
            _unitOfWork.Commit();
        }
    }
}
