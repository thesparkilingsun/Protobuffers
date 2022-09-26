using Microsoft.AspNetCore.Mvc.Formatters;

namespace ProtoBuffers.Repositories.IRepositories
{

    public interface IProtoServices
    {

        Task GetProtoDTOAsync(int id, CancellationToken cancellationToken);
       
    }
}
