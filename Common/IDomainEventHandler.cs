using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
    public interface IDomainEventHandler<Ag> where Ag:BaseAggregate {
        Task HandleAsync(DomainEvent<Ag> e);
    }
}
