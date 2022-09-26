using DummyDB.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Net.Http.Headers;
using ProtoBuf;
using ProtoBuffers.DTO;
using ProtoBuffers.Repositories.IRepositories;

namespace ProtoBuffers
{
    public class FormatMediaFormatter : OutputFormatter
    {
        public FormatMediaFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/x-protobuf"));
        }

        public override bool CanWriteResult(OutputFormatterCanWriteContext context)
        {
            if (typeof(IConvertableToDTO).IsAssignableFrom(context.ObjectType))
            {
                return base.CanWriteResult(context);
            }
            return false;
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
        {
            var httpContext = context.HttpContext;

            if (context.Object is not IConvertableToDTO component)
            {
                throw new ArgumentException("Object was not a Component.");
            }

            var dto = component.ConvertToDTO();
            var byteArray = dto.Serialize();
            httpContext.Response.ContentType = "application/x-protobuf";
            httpContext.Response.ContentLength = byteArray.Length;
            await httpContext.Response.Body.WriteAsync(byteArray);
        }
    }
}
