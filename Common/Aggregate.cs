using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
    public abstract class Aggregate<Identity,Ag>: BaseAggregate where Identity:Identity<Identity> where Ag:Aggregate<Identity,Ag> {

        public Aggregate(Identity id) {
            //SetId();
            Id= id;
        }

        protected void SetId() {
            if (Identity<Identity>.IsValid(_id.GUID ?? String.Empty))
                Id = _id;
            else
                throw new InvalidOperationException(String.Join(",",Identity<Identity>.Validate(_id.GUID?? String.Empty)));
        }

        public Identity<Identity>? Id { get; protected set; }
        private Identity? _id;


    }
}
