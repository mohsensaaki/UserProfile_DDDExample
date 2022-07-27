using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common {
    public class Identity<IT>  where IT : Identity<IT> {
        public string? GUID { get; protected set; }
        public bool IsComb { get; protected set; } = false;

        public override string ToString() {
            return $"{GUID}, combined: {IsComb}";
        }
        protected Identity() { }

        public static Identity<IT> New() {
            return new Identity<IT>() { GUID = $"{GetEnityName()}-{Guid.NewGuid()}" };
        }
        private static string GetEnityName() {
            var entityName = typeof(IT).Name;
            string perfix = entityName.ToLower().EndsWith("id") ? entityName.Remove(entityName.Length - 2, 2) : entityName;
            return perfix;
        }

        private static string GetPureGuid(string id) {
            return id.Replace($"{GetEnityName()}_", "");
        }

        public static bool IsValid(string id) {
            string perfix = GetEnityName();
            if (id.StartsWith(perfix) != true) return false;
            if (Guid.TryParse(GetPureGuid(id), out Guid casted)) return false;
            return true;
        }

        public static System.Collections.ObjectModel.ReadOnlyCollection<string> Validate(string id) {
            List<string> errors = new List<string>();
            string perfix = GetEnityName();
            if (!id.StartsWith(perfix))
                errors.Add("An id mus be started with entity name.");
            if (Guid.TryParse(id.Replace($"{perfix}_", ""), out Guid casted))
                errors.Add("the id format is wrong. the id must be in hexa decimal and rrange in 8-4-4-12");
            return errors.AsReadOnly();
        }

        public static Identity<IT> NewComb() {
            var guidComb = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            return new Identity<IT>() { GUID = $"{GetEnityName()}-{guidComb}", IsComb = true };
        }
    }
}
