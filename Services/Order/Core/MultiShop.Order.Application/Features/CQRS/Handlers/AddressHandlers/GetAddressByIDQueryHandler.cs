using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIDQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIDQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task<GetAddressByIDQueryResult> Handle(GetAddressByIDQuery query)
        {
            var values = await _repository.GetByIDAsync(query.ID);
            return new GetAddressByIDQueryResult
            {
                AddressID = values.AddressID,
                City = values.City,
                Detail = values.Detail1,
                District = values.District,
                UserID = values.UserID
            };
        }
    }
}
