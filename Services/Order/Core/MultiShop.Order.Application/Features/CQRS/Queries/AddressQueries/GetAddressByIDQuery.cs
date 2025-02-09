using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries
{
    public class GetAddressByIDQuery
    {
        public int ID { get; set; }

        public GetAddressByIDQuery(int id)
        {
            ID = id;
        }
    }
}
