using ProtoBuf;
using ProtoBuf.Serializers;
using ProtoBuffers.Repositories.IRepositories;
using System.IdentityModel.Tokens.Jwt;
using Component = DummyDB.Models.Component;


namespace ProtoBuffers.Repositories
{
    public class ComponentRepository : GenericRepository<Component>, IComponentRepository
    {
        public ComponentRepository(DbContextClass dbContextClass) : base(dbContextClass)
        {
        }

        public async Task DeleteComponent(int id, CancellationToken cancellationToken)
        {
            Component comp;
            comp = _dbSet.Find(id)!;
            _ = _dbContextClass.Remove(comp);
            _ = await _dbContextClass.SaveChangesAsync(cancellationToken);
        }

        public Task<Component> GetComponent(int id, CancellationToken cancellationToken)
        {
            return base.GetById(id, cancellationToken);
        }

        public string GetComponentCodeById(int id)
        {
            return _dbSet.Find(id)!.Code.ToString();
        }


        public async Task UpdateComponent(Component component, CancellationToken cancellationToken)
        {
            await Update(component, cancellationToken);
        }



    }
}
