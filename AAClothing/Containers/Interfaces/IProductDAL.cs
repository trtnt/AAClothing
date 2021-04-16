using AAClothing.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAClothing.Containers.Interfaces
{
    public interface IProductDAL : IContainerDAL<ProductDTO>
    {
        void insert(ProductDTO productdto);
        void update(ProductDTO productdto);
    }
}
