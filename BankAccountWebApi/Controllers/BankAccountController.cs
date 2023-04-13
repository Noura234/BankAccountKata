using BankAccountKata.Application;
using BankAccountKata.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BankAccountWebApi.Controllers
{
    [ApiController]
    [Route("api/bank-account")]
    public class BankAccountController : ControllerBase
    {
        private readonly IBankAccount _bankAccountService;

        public BankAccountController(IBankAccount bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }

        [HttpPost, Route("deposit/{amount:int}")]
        public IActionResult Deposit(int amount)
        {
            try
            {
                _bankAccountService.Deposit(amount);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost, Route("withdraw/{amount:int}")]
        public IActionResult WithDraw(int amount)
        {
            try
            {
                _bankAccountService.WithDraw(amount);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, Route("operations")]
        public IActionResult History()
        {
            List<Transaction> result = _bankAccountService.AllTransactions();
            return Ok(result);
        }
    }
}