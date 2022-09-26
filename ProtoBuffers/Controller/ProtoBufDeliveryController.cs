using DummyDB.Models;
using Microsoft.AspNetCore.Mvc;
using ProtoBuf.Grpc.Configuration;
using ProtoBuffers.Services;

namespace ProtoBuffers.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ProtoBufDeliveryController : ControllerBase
    {
        private readonly DeliverProtoBuffService _deliver;
        public ProtoBufDeliveryController(DeliverProtoBuffService deliver)
        {
            _deliver = deliver ?? throw new ArgumentNullException(nameof(deliver));
        }

        [HttpGet,Route("/component")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Component>> GetSerializedComponent(int id, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Component val;
            try
            {
                val = await _deliver.GetSerializedComponentAsync(id, cancellationToken);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return val;
        }

        [HttpGet, Route("/orderData")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<OrderData>> GetSerializedOrderData(int id, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            OrderData val;
            try
            {
                val = await _deliver.GetSerializedOrderData(id, cancellationToken);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return val;
        }
    }
}
