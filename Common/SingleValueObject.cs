using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
    public class SingleValueObject<T> where T:struct {
        private readonly T _value;
        private string _name;

        public T Value { get { return _value; } }
        public string Name { get { return _name; } }

        private SingleValueObject(string name, T value) {
            this._value = value;
            _name = name;
        }

        public static SingleValueObject<T> Create(string name,T value) {
            return new SingleValueObject<T>(name,value);
        }
    }
}
