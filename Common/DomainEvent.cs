using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
    public abstract class DomainEvent<S> {
        //protected Dictionary
        public DateTime CreateDateTime { get; protected set; }
       // public ReadOnlyDictionary<string,SingleValueObject<object>> EventSpecefics { get; }
    }
}
