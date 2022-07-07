using BankingSystemAPI.Data;
using BankingSystemAPI.Models;
using BankingSystemAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingSystemAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankingSystemController : ControllerBase
    {
        private readonly BankingSystemService _service;
        public BankingSystemController(IBankingSystemRepo repository)
        {
            _service = new BankingSystemService(repository);
        }

        [HttpPost("CreateUser")]
        public ActionResult CreateUser()
        {
            try
            {
                _service.CreateUser();
            }
            catch (Exception ex)
            {
                /** Log exception here **/
                return StatusCode(500);
            }
            return StatusCode(201);
        }

        [HttpPost("CreateAccount/{userID}/{amount}")]
        public ActionResult CreateAccount(int userID, decimal amount)
        {
            try
            {
                _service.CreateAccount(userID, amount);
            }
            catch (Exception ex)
            {
                /** Log exception here **/
                return StatusCode(500);
            }
            return StatusCode(201);
        }

        [HttpDelete("DeleteAccount/{userID}/{accountID}")]
        public ActionResult DeleteAccount(int userID, string accountID)
        {
            try
            {
                _service.DeleteAccount(userID, accountID);
            }
            catch (Exception ex)
            {
                /** Log exception here **/
                return StatusCode(500);
            }
            return StatusCode(200);
        }

        [HttpPost("Deposit")]
        public ActionResult Deposit(Transaction transaction)
        {
            try
            {
                _service.Deposit(transaction);
            }
            catch (Exception ex)
            {
                /** Log exception here **/
                return StatusCode(500);
            }
            return StatusCode(200);
        }

        [HttpPost("Withdraw")]
        public ActionResult Withdraw(Transaction transaction)
        {
            try
            {
                _service.Withdraw(transaction);
            }
            catch (Exception ex)
            {
                /** Log exception here **/
                return StatusCode(500);
            }
            return StatusCode(200);
        }

        [HttpGet("GetUserByID/{id}")]
        public ActionResult<User> GetUserByID(int id)
        {
            try
            {
                var user = _service.GetUserById(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                /** Log exception here **/
                return StatusCode(500);
            }
        }

        [HttpGet("GetUsers")]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            try
            {
                var users = _service.GetUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                /** Log exception here **/
                return StatusCode(500);
            }
        }
    }
}
