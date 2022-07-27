using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Common {
    public static class DomainEventMannager {
        public static void Raise<Ag>(DomainEvent<Ag> @event) where Ag:BaseAggregate {
            var handlers= Setting.Settings.TheServiceProvider.GetServices<IDomainEventHandler<Ag>>();
            if (handlers.Any())
                foreach (var handler in handlers)
                    handler.HandleAsync(@event);
        }
    }
}
