using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Commands.CreateOrderingCommand
{
    public class RemoveOrderingCommand : IRequest
    {
        public int ID { get; set; }

        public RemoveOrderingCommand(int id)
        {
            ID = id;
        }
    }
}
