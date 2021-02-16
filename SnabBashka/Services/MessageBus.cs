using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SnabBashka.Models.SupplyDpt;

namespace SnabBashka.Services
{
    public class MessageBus
    {
        private readonly ConcurrentDictionary<MessageSubscriber, Func<IMessage, Task>> _consumers;

        public MessageBus()
        {
            _consumers = new ConcurrentDictionary<MessageSubscriber, Func<IMessage, Task>>();
        }

        public async Task SendTo<TReceiver>(IMessage message)
        {
            var messageType = message.GetType();
            var receiverType = typeof(TReceiver);

            var tasks = _consumers
                .Where(s => s.Key.MessageType == messageType && s.Key.ReceiverType == receiverType)
                .Select(s => s.Value(message));

            await Task.WhenAll(tasks);
        }

        public IDisposable Receive<TMessage>(object receiver, Func<TMessage, Task> handler) where TMessage : IMessage
        {
            var sub = new MessageSubscriber(receiver.GetType(), typeof(TMessage), s => _consumers.TryRemove(s, out var _));

            _consumers.TryAdd(sub, (@event) => handler((TMessage)@event));

            return sub;
        }
    }

    public interface IMessage { }

    class MessageSubscriber : IDisposable
    {
        private readonly Action<MessageSubscriber> _action;

        public Type ReceiverType { get; }
        public Type MessageType { get; }

        public MessageSubscriber(Type receiverType, Type messageType, Action<MessageSubscriber> action)
        {
            ReceiverType = receiverType;
            MessageType = messageType;
            _action = action;
        }

        public void Dispose()
        {
            _action?.Invoke(this);
        }
    }

    public class InvoiceMessage : IMessage
    {
        public InvoiceMessage(Invoice invoice)
        {
            Invoice = invoice;
        }

        public Invoice Invoice { get; set; }
    }
}
