using System;
using System.Collections.Generic;
using System.Text;

namespace NSE.Core.Messages
{
    public abstract class Message
    {
        public string MessageType { get; private set; }
        public Guid AggregateId { get; set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
