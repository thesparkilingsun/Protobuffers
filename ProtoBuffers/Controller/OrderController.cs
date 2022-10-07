using DummyDB.Models;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using ProtoBuffers.Services;

namespace ProtoBuffers.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderDataService _orderDataService;
        public OrderController(OrderDataService orderDataService)
        {
            _orderDataService = orderDataService ?? throw new ArgumentNullException(nameof(orderDataService));
        }

        
        [HttpGet,Route("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<OrderData[]>> GetAllData(CancellationToken cancellationToken)
        {
            OrderData[] orderData;
            try
            {
                orderData = await _orderDataService.GetAllODAsync(cancellationToken);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Message: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return orderData;
        }

        [HttpGet, Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<OrderData>> GetByIdData(int id, CancellationToken cancellationToken)
        {
            OrderData orderData;
            try
            {
                orderData = await _orderDataService.GetOrderDataByIdAsync(id, cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return orderData;
        }

        [HttpGet,Route("date")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DateOnly>> GetDateFromOrderData(int id, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            DateOnly date;
            try
            {
                date = await _orderDataService.GetOrderDateAsync(id, cancellationToken);
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return date;
        }

        [HttpGet, Route("time")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TimeOnly>> GetTimeFromOrderData(int id, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            TimeOnly time;
            try
            {
                time = await _orderDataService.GetOrderTimeAsync(id, cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return time;
        }

        [HttpPost,Route("insert")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> InsertOrderData(OrderData ord,CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
               await _orderDataService.AddAsyncOrderData(ord, cancellationToken);
            }catch(Exception ex)
            {
                Console.WriteLine($"Exception ex", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok("Successful entry");
        }

        [HttpPatch,Route("edit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> EditOrderData(OrderData ord, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _orderDataService.EditOrderDataAsy(ord, cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception ex", ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok("Successful entry"); 
        }

    }
}
