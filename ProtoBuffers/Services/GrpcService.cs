using DummyDB.Models;
using ProtoBuffers.Repositories;
using ProtoBuffers.Repositories.IRepositories;

namespace ProtoBuffers.Services
{
    public class GrpcService
    {


        private readonly IComponentRepository _componentRepository;
        public GrpcService(IComponentRepository componentRepositoryy)
        {
            _componentRepository = componentRepositoryy ?? throw new ArgumentNullException(nameof(componentRepositoryy));
        }

        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task<Component> GetComponent(int id, CancellationToken cancellation)
        {
            return _componentRepository.GetComponent(id, cancellation);
        }
    }
}
