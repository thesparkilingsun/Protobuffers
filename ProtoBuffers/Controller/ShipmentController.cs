
using DummyDB.Models;
using Microsoft.AspNetCore.Mvc;
using ProtoBuffers.Services;

namespace ProtoBuffers.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ShipmentController : ControllerBase
    {
        private readonly ShipmentServices _shipServices;

        public ShipmentController(ShipmentServices shipServices)
        {
            _shipServices = shipServices ?? throw new ArgumentNullException(nameof(shipServices));
        }

        [HttpGet,Route("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Shipment[]>> GetShipmentAll(CancellationToken cancellationToken)
        {
            Shipment[] shipment;
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                shipment = await _shipServices.GetAllShipments(cancellationToken);
            }
            catch(Exception ex) 
            {   
                Console.WriteLine(ex); 
                return StatusCode(StatusCodes.Status500InternalServerError); 
            }
            return Ok(shipment);
        }


        [HttpGet,Route("{id:int})")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<Shipment>> GetShipmentById(int id,CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Shipment shipment;
            try
            {
                shipment = await _shipServices.GetShipmentByIDAsync(id, cancellationToken);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Message {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(shipment);
        }


        [HttpPatch,Route("edit/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ShipLoad>> Edit(int id,Shipment shipload, CancellationToken cancellationToken)
         {
            ShipLoad shipment;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                shipment = await _shipServices.EditShipment(id, shipload, cancellationToken);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return shipment;
        }

        [HttpPost,Route("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> AddShipment(Shipment ship,CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                 await _shipServices.AddShipmentAsync(ship, cancellationToken);
            }catch(Exception ex)
            {
                Console.WriteLine($"Message:{ex} ");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok("SuccessFull");
        }

        [HttpDelete, Route("remove")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteShipment(int id, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _shipServices.DeleteShipmentByID(id, cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message:{ex} ");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok("SuccessFull");
        }


    }
}
