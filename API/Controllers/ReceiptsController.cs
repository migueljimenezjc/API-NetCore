using System;
using System.Net;
using API.Core.Interfaces;
using API.Entities.Entities;
using API.Entities.Response;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ReceiptsController : ControllerBase
    {
        private readonly IDataRepository<Receipt> _dataRepository;
        public ReceiptsController(IDataRepository<Receipt> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Receipt
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_dataRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500, "Unable to process request");
            }
        }

        // GET: api/Receipt/5
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {
            try
            {
                if (_dataRepository.Count(id) <= 0)
                    return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "Not found");

                return Ok(_dataRepository.Get(id));
            }
            catch (Exception)
            {
                return StatusCode(500, "Unable to process request");
            }
        }

        // POST: api/Receipt
        [HttpPost]
        public IActionResult Post(string provider, double amount, string currency, string date, string commentary)
        {
            ResponseAPI response = new ResponseAPI();
            Receipt receipt = new Receipt();
            receipt.provider = provider;
            receipt.amount = amount;
            receipt.currency = currency;
            receipt.date = Convert.ToDateTime(date);
            receipt.commentary = commentary;

            try
            {
                response = _dataRepository.Validate(receipt);
                if (response.Code != 0)
                    return StatusCode(response.Code.GetHashCode(), response.Message);

                _dataRepository.Add(receipt);
                return StatusCode(HttpStatusCode.Created.GetHashCode(), receipt);
            }
            catch (Exception)
            {
                return StatusCode(500, "Unable to process request");
            }
        }

        // PUT: api/Receipt/5
        [HttpPut]
        public IActionResult Put(int id, string provider, decimal amount, string currency, string date, string commentary)
        {
            ResponseAPI response = new ResponseAPI();
            try
            {
                if (_dataRepository.Count(id) <= 0)
                    return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "Not found");

                Receipt newReceipt = new Receipt();
                newReceipt.provider = provider;
                newReceipt.amount = Convert.ToDouble(amount);
                newReceipt.currency = currency;
                newReceipt.date = Convert.ToDateTime(date);
                newReceipt.commentary = commentary;

                response = _dataRepository.Validate(newReceipt);
                if (response.Code != 0)
                    return StatusCode(response.Code.GetHashCode(), response.Message);

                _dataRepository.Update(_dataRepository.Get(id), newReceipt);
                return Ok(newReceipt);
            }
            catch (Exception)
            {
                return StatusCode(500, "Unable to process request");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_dataRepository.Count(id) <= 0)
                    return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "Not found");

                _dataRepository.Delete(id);
                return StatusCode(HttpStatusCode.OK.GetHashCode(), "Deleted");
            }
            catch (Exception)
            {
                return StatusCode(500, "Unable to process request");
            }
        }
    }
}