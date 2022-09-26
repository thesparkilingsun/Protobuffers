using DummyDB.Models;

namespace ProtoBuffers.Payload
{
    public class ComponentPayload
    {
        public int Id { get; set; }
        public string Code { get; set; } = default!;
        public bool Fetch { get; set; } = false;
        public string Path { get; set; } = default!;

        public static ComponentPayload FromComponent(DummyDB.Models.Component component) => new()
        {
            Id = component.Id,
            Code = component.Code,
            Fetch = component.Fetch,
            Path = component.Path,
        };
    }
}
