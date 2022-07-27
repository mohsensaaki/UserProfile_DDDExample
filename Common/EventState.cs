using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
    public abstract class EventState<T> where T : struct {
        protected T _state;

        public T State { get => _state; }
        public EventState(T state) {
            _state = state;
        }
        public virtual ReadOnlyDictionary<string, string> Flated() {
            Dictionary<string, string> flatted = new Dictionary<string, string>();
            var prperties = State.GetType().GetProperties();
            ItreateOverProperties(flatted, prperties, State);
            return new ReadOnlyDictionary<string, string>(flatted);
        }

        private void ItreateOverProperties(Dictionary<string, string> flatted, System.Reflection.PropertyInfo[] prperties, object obj, string perfix = "") {
            foreach (var p in prperties) {
                if (p.PropertyType == typeof(string) || p.PropertyType.IsPrimitive)
                    PrimitiveHandel(flatted, obj, perfix, p);
                else if (p.PropertyType.GetInterfaces().Contains(typeof(IEnumerable)))
                    CollectionHandle(flatted, obj, perfix, p);
                else if (p.PropertyType.IsClass)
                    ItreateOverProperties(flatted, p.GetType().GetProperties(), p.GetValue(obj), $"{perfix}{p.Name}_");
                else
                    continue;
            }
        }

        private void CollectionHandle(Dictionary<string, string> flatted, object obj, string perfix, System.Reflection.PropertyInfo p) {
            int i = 0;
            if (p.GetValue(obj) != null)
                foreach (var item in p.GetValue(obj) as ICollection) {
                    ItreateOverProperties(flatted, item.GetType().GetProperties(), item, $"{perfix}{p.Name}@{i++}_");
                }
        }

        private void PrimitiveHandel(Dictionary<string, string> flatted, object obj, string perfix, System.Reflection.PropertyInfo p) {
            flatted.Add($"{perfix}{p.Name}", p.GetValue(obj).ToString());
        }
    }
}
