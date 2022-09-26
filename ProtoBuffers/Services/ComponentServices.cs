using DummyDB.Models;
using Microsoft.EntityFrameworkCore;
using ProtoBuffers.Repositories;
using ProtoBuffers.Repositories.IRepositories;

namespace ProtoBuffers.Services
{
    public class ComponentServices
    {
        private readonly IComponentRepository _componentRepository;
        

        public ComponentServices(IComponentRepository componentRepository) : base()
        {
            _componentRepository = componentRepository ?? throw new ArgumentNullException(nameof(componentRepository));
                
        }

        public string Code(int id) => _componentRepository.GetComponentCodeById(id);

        public async Task<Component> GetIdComponent(int id, CancellationToken cancellationToken)
        {
            var comp = await _componentRepository.GetById(id, cancellationToken);
           
            return comp;
        }

        public async Task<Component[]> GetAllTheComponent(CancellationToken cancellationToken)
        {
            return await _componentRepository.GetAll(cancellationToken);

        }

        public  Task AddComponent(Component c, CancellationToken cancellationToken) => _componentRepository.Add(c, cancellationToken);
       

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
          
            await _componentRepository.DeleteComponent(id,cancellationToken);
        }

        public async Task Update(Component comp, CancellationToken cancellationToken)
        {
            await _componentRepository.UpdateComponent(comp,cancellationToken);

        }
    }



}
