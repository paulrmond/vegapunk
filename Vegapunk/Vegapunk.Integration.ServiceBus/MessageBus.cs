using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegapunk.Integration.ServiceBus
{
    internal class MessageBus : IMessageBus
    {
        public Task PublishMessage(object message, string topic_name)
        {
            throw new NotImplementedException();
        }
    }
}
