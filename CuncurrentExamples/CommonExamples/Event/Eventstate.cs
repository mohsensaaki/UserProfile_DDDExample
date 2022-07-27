using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonExamples.Event {
    public struct SomeThingChanged {
        public string Name { get; set; }
        public System.Collections.Generic.IEnumerable<SomeThingChanged> Items { get; set; }
    }
    public class Eventstate : Common.EventState<SomeThingChanged> {
        public Eventstate(SomeThingChanged state) : base(state) {
        }
    }
}
