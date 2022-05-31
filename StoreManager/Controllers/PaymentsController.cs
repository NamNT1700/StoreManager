using AutoMapper;
using Entities.DataTransferObjects.PaymentDTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Store;
using System;
using System.Threading.Tasks;

namespace StoreManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public PaymentsController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpPost("CreatePayment")]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentForCreationDto payment)
        {

            try
            {
                if (payment == null)
                {
                    _logger.LogError("payment object sent from client is null.");
                    return BadRequest("payment object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid payment object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var paymentEntity = _mapper.Map<Payments>(payment);

                await _repository.Payments.CreatePayments(paymentEntity);
                _repository.Save();

                var createdPayment = _mapper.Map<PaymentDto>(paymentEntity);

                return Ok(createdPayment);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreatePayment action: {ex.Message}");
                return StatusCode(500, $"Something went wrong inside CreatePayment action: {ex.Message}");
            }
        }

        [HttpPut("Payment")]
        public async Task<IActionResult> UpdatePayments(int customerID, [FromBody] PaymentForUpdateDto payment)
        {
            try
            {
                if (payment == null)
                {
                    _logger.LogError("payment object sent from client is null.");
                    return BadRequest("payment object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid payment object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var paymentEntity = await _repository.Payments.GetPaymentByNumber(customerID);
                if (paymentEntity == null)
                {
                    _logger.LogError($"payment with customerNumber: {customerID}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(payment, paymentEntity);
                await _repository.Payments.UpdatePayments(paymentEntity);
                _repository.Save();
                return Ok(paymentEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdatePayments action: {ex.Message}");
                return StatusCode(500, $"Something went wrong inside UpdatePayments action: {ex.Message}");
            }
        }
    }
}
