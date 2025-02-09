using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands
{
    public class RemoveAddressCommand
    {
        public int ID { get; set; }

        public RemoveAddressCommand(int id)
        {
            ID = id;
        }
    }
}
