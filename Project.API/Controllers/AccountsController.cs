using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.API.Commands.Accounts;
using Project.Domain.DTOs;
using Project.Domain.Enums;
using Project.Domain.Interfaces.Repositories;
using Project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository accountRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IMemberRepository memberRepository;
        private readonly IMapper mapper;

        public AccountsController(IAccountRepository accountRepository, ICompanyRepository companyRepository, IMemberRepository memberRepository, IMapper mapper)
        {
            this.accountRepository = accountRepository;
            this.companyRepository = companyRepository;
            this.memberRepository = memberRepository;
            this.mapper = mapper;            
        }

        [HttpPost]
        public IActionResult Post(CreateAccountCommand command)
        {
            var account = mapper.Map<Account>(command);

            if (!accountRepository.Exists(account))
            {
                try
                {
                    accountRepository.Add(account);
                    return StatusCode(201, new { Message = "Account successfully created." });
                }
                catch (FormatException e)
                {
                    return StatusCode(400, e.Message);
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            else
            {
                return StatusCode(409, new { Message = "The account already exists for this member." });
            }            
        }

        [HttpPut]
        [Route("Collect")]
        public IActionResult Collect(PointsTransactionAccountCommand command)
        {
            Account account = accountRepository.GetById(Guid.Parse(command.AccountId));

            if (account == null)
                return StatusCode(404, new { Message = "The account was not found." });            

            if (command.Amount <= 0)
                return StatusCode(400, new { Message = "The value provided is not valid." });

            if (account.MemberId == Guid.Parse(command.MemberID))
            {
                try
                {
                    account.Balance += command.Amount;
                    accountRepository.Update(account);
                    return Ok(new { Message = $"The amount of {command.Amount} points was collected and the new balance for this account is {account.Balance}" });
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            else
            {
                return StatusCode(403, new { Message = "Member does not match the account" });
            }            
        }

        [HttpPut]
        [Route("Redeem")]
        public IActionResult Redeem(PointsTransactionAccountCommand command)
        {
            Account account = accountRepository.GetById(Guid.Parse(command.AccountId));

            if (account == null)
                return StatusCode(404, new { Message = "The account was not found." });

            if (command.Amount <= 0)
                return StatusCode(400, new { Message = "The value provided is not valid." });

            if (account.Status == AccountStatus.INACTIVE)
                return StatusCode(401, new { Message = "Inactive accounts are not subject to redeem transactions" });

            if (account.Balance - command.Amount < 0)
                return StatusCode(400, new { Message = "The value exceeds the account balance." });

            if (account.MemberId == Guid.Parse(command.MemberID))
            {
                try
                {
                    account.Balance -= command.Amount;
                    accountRepository.Update(account);
                    return Ok(new { Message = $"The amount of {command.Amount} points was redeemed and the new balance for this account is {account.Balance}" });
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            else
            {
                return StatusCode(403, new { Message = "Member does not match the account" });
            }



        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {                
                return Ok(mapper.Map<List<AccountDTO>>(accountRepository.GetAll().ToList()));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }            
        }
    }
}
