using Common;
using CommonExamples.identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonExamples.aggregate {
    public class TestAggregate : Aggregate<identity.TestId, TestAggregate> {
        public TestAggregate(TestId id) : base(id) {
        }
    }
}
