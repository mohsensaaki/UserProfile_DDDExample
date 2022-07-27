// See https://aka.ms/new-console-template for more information
using CommonExamples.aggregate;
using CommonExamples.Event;
using CommonExamples.identity;

Console.WriteLine($"standard form: {TestId.New()}");
Console.WriteLine($"combination form: {TestId.NewComb()}");

Console.WriteLine(TestId.IsValid("Test-ffffffff-ffff-ffff-ffff-ffffffffffff"));

CommonExamples.Event.Eventstate s = new CommonExamples.Event.Eventstate(new CommonExamples.Event.SomeThingChanged() {
    Name = "mohsen",
    Items = new List<CommonExamples.Event.SomeThingChanged>(new[] { new SomeThingChanged() { Name = "hassan" } })
});

s.Flated();

