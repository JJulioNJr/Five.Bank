using Five.Bank.Api.Models.Inputs;
using Five.Bank.Api.Models.Outputs;
using Five.Bank.Domain.Contracts.V1;
using Five.Bank.Domain.Entities.V1;
using Five.Bank.Domain.Exceptions.V1;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Net;

namespace Five.Bank.Api.Controllers.V1;
[Route("api/v1/custumers")]
[ApiController]
public class CustomerController : ControllerBase {

    private readonly ICustomerRepository _repository;
    private readonly IAddressClient _addressClient;

    public CustomerController(
        ICustomerRepository repository,
        IAddressClient addressClient) {
        _repository = repository;
        _addressClient = addressClient;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CustomerInputModel model) {
        try {
            var address = await _addressClient.GetByZipCode(model.ZipCode);

            if (address is null) return BadRequest(new { Message = "Dados inválidos." });

            var customer = new Customer(
                model.Name,
                model.Document,
                model.Birthday,
                address);

            if (!customer.Validate()) return BadRequest(new { Message = "Dados inválidos." });

            await _repository.AddAsync(customer);

            return StatusCode((int)HttpStatusCode.Created, "Cliente cadastrado com sucesso!!!");
        } catch (DomainException e) {
            return BadRequest(new { e.Message });
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id) {
        try {
            var customer = await _repository.GetByIdAsync(id);

            if (customer is null) return NotFound();

            var model = new CustomerOutputModel(customer.Id, customer.Name);

            return Ok(model);
        } catch (DomainException e) {
            return BadRequest(new { e.Message });
        }
    }
}
