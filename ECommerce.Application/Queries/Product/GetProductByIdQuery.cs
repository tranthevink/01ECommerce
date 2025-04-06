using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.DTOs;
using MediatR;

namespace ECommerce.Application.Queries.Product
{
    public record GetProductByIdQuery(Guid Id) : IRequest<ProductDto>;
}
