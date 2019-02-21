using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace AspNetCore.SignalR.AzureServiceBus.Internal
{
    internal class AllMessageRecipient : SignalRMessageRecipient
    {
        public IReadOnlyList<string> ExcludedConnectionIds { get; set; }

        public override Task SendCoreAsync(IMessageSender sender, string method, object[] args, CancellationToken cancellationToken)
        {
            return sender.SendAllExceptAsync(method, args, ExcludedConnectionIds ?? Array.Empty<string>(), cancellationToken);
        }
    }
}
