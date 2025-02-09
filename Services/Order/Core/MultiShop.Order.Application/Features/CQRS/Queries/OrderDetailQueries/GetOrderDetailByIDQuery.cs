using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries
{
    public class GetOrderDetailByIDQuery
    {
        public int ID { get; set; }

        public GetOrderDetailByIDQuery(int id)
        {
            ID = id;
        }
    }
}
