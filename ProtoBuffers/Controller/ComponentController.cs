using DummyDB.Models;
using Microsoft.AspNetCore.Mvc;
using ProtoBuffers.Payload;
using ProtoBuffers.Services;

namespace ProtoBuffers.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ComponentController : ControllerBase
    {
        private readonly ComponentServices _services;
        private readonly GrpcService _grpcService;
        

        public ComponentController(ComponentServices services, GrpcService grpcService)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
            _grpcService = grpcService ?? throw new ArgumentNullException(nameof(grpcService));
           
        }

        [HttpGet, Route("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ComponentPayload>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ComponentPayload>>> GetAll(CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Component[] compnt;
            try
            {
                compnt = await _services.GetAllTheComponent(cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            var converted = compnt.Select(ComponentPayload.FromComponent);

            return Ok(converted);
        }

        [HttpGet, Route("get/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ComponentPayload>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ComponentPayload>>> GetById(int id, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Component compnt;
            try
            {
                compnt = await _services.GetIdComponent(id, cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(compnt);
        }

        [HttpGet, Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Component>> GrpcService(int id, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Component val;
            try
            {
                val = await _grpcService.GetComponent(id, cancellationToken);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return val;
        }

        [HttpPost, Route("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Add([FromBody] ComponentLoad componentLoad, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Component compn = new() { Code = componentLoad.Code, Fetch = componentLoad.Fetch, Path = componentLoad.Path };
            try
            {
                await _services.AddComponent(compn, cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok("Success");
        }

        [HttpPatch, Route("edit")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Update(Component component, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _services.Update(component, cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok("Success");

        }

        [HttpPut, Route("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _services.Delete(id, cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"message {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok("Success");

        }

    }
}
