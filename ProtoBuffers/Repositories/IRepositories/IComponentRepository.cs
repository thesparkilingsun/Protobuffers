using DummyDB.Models;
using ProtoBuf.Serializers;
using System.ComponentModel;
using Component = DummyDB.Models.Component;

namespace ProtoBuffers.Repositories.IRepositories
{
    public interface IComponentRepository : IRepository<Component>

    {
        public string GetComponentCodeById(int id);
        public Task<Component> GetComponent(int id, CancellationToken cancellationToken);
        public Task DeleteComponent(int id, CancellationToken cancellationToken);
        public Task UpdateComponent(Component component, CancellationToken cancellationToken);
        

    }
}
