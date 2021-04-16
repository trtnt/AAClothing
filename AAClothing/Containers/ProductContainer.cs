using AAClothing.Containers.Interfaces;
using AAClothing.DAL;
using AAClothing.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAClothing.Containers
{
    public class ProductContainer : IContainerDAL<ProductDTO>
    {
        protected readonly IProductDAL _context;

        public ProductContainer(IProductDAL context)
        {
            _context = context;
        }

        public List<ProductDTO> GetAll()
        {
            return _context.GetAll();
        }

        public ProductDTO GetByID(long id)
        {
            return _context.GetByID(id);
        }
    }
}
