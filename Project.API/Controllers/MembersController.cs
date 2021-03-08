using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.API.Commands.Members;
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
    public class MembersController : ControllerBase
    {
        private readonly IMemberRepository memberRepository;
        private readonly IAccountRepository accountRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IMapper mapper;

        public MembersController(IMemberRepository memberRepository, IMapper mapper, IAccountRepository accountRepository, ICompanyRepository companyRepository)
        {
            this.memberRepository = memberRepository;
            this.accountRepository = accountRepository;
            this.companyRepository = companyRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post(CreateMemberCommand command)
        {
            var member = mapper.Map<Member>(command);

            try
            {
                memberRepository.Add(member);
                return StatusCode(201, new { Message = "Member successfully created." });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("Import")]
        public IActionResult ImportMembersWithAccountsFromJson(List<ImportMemberCommand> commandList)
        {
            try
            {
                foreach (var memberImport in commandList)
                {
                    var member = new Member()
                    {
                        Id = Guid.NewGuid(),
                        Name = memberImport.Name,
                        Address = memberImport.Address
                    };
                    memberRepository.Add(member);

                    foreach (var accountImport in memberImport.Accounts)
                    {
                        var company = companyRepository.GetByName(accountImport.Name);

                        if (company == null)
                        {
                            company = new Company()
                            {
                                Id = Guid.NewGuid(),
                                Name = accountImport.Name
                            };

                            companyRepository.Add(company);
                        }

                        var account = new Account()
                        {
                            MemberId = member.Id,
                            CompanyId = company.Id,
                            Balance = accountImport.Balance,
                            Status = Enum.Parse<AccountStatus>(accountImport.Status.ToUpper())
                        };

                        accountRepository.Add(account);
                    }
                }
                return StatusCode(201, new { Message = "Members with accounts successfully imported." });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(mapper.Map<List<MemberDTO>>(memberRepository.GetAll().ToList()));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }        
    }
}
