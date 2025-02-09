using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByUserIDQueryHandler : IRequestHandler<GetOrderingByUserIDQuery, List<GetOrderingByUserIDQueryResult>>
    {
        private readonly IOrderingRepository _orderingRepository;

        public GetOrderingByUserIDQueryHandler(IOrderingRepository orderingRepository)
        {
            _orderingRepository = orderingRepository;
        }
   
        public async Task<List<GetOrderingByUserIDQueryResult>> Handle(GetOrderingByUserIDQuery request, CancellationToken cancellationToken)
        {
            var values = _orderingRepository.GetOrderingByUserID(request.Id);
            return values.Select(x => new GetOrderingByUserIDQueryResult
            {
                OrderDate = x.OrderDate,
                OrderingID = x.OrderingID,
                TotalPrice = x.TotalPrice,
                UserID = x.UserID
            }).ToList();
        }
    }
}

