using Microsoft.AspNetCore.Mvc.Formatters;

namespace ProtoBuffers.Repositories.IRepositories
{
    public interface IFormatMedia<T>
    {
        public abstract bool CanWriteResult(OutputFormatterCanWriteContext context);
        public abstract Task WriteResponseBodyAsync(OutputFormatterWriteContext context);

    }
}
