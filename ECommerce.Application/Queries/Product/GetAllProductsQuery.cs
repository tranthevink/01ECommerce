using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.DTOs.Product;
using MediatR;

namespace ECommerce.Application.Queries.Product
{
    public class GetAllProductsQuery : IRequest<List<ProductDto>>
    {
    }
}
