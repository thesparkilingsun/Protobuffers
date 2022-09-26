using DummyDB.Models;
using Microsoft.AspNetCore.Mvc;
using ProtoBuf.Meta;
using ProtoBuffers.Payload;
using ProtoBuffers.Services;

namespace ProtoBuffers.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly ItemsService _itemsService;
        public ItemsController(ItemsService itemsService)
        {
                _itemsService = itemsService ?? throw new ArgumentNullException(nameof(itemsService));
        }

        [HttpGet, Route("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Items>> GetAll(CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Items[] item;
            try
            {
                item = await _itemsService.GetAllItems(cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            

            return Ok(item);
        }

        [HttpGet,Route("{id:int}/component-details")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Component>> GetDetailsShipping (int id,CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); };
            Component comp;
            try
            {
                comp = await _itemsService.GetShippingDetails(id, cancellationToken);
            }catch(Exception ex)
            {
                Console.WriteLine($"Message {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(comp);
        }

        [HttpPost,Route("insert")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> InsertItems(Items item,CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState); 
            }
            try
            {
                 
                await _itemsService.AddItem(item, cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok("success");

        }

    }
}
