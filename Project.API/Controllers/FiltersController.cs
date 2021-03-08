using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    public class FiltersController : ControllerBase
    {
        private readonly IMemberRepository memberRepository;
        private readonly IMapper mapper;
        public FiltersController(IMemberRepository memberRepository, IMapper mapper)
        {
            this.memberRepository = memberRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("BalanceStatusFilter")]
        public IActionResult FilterMembersByMinimumBalanceAndStatus(int minBalance, string status)
        {
            List<Member> members = memberRepository.GetAll().ToList();
            foreach (var member in members)
            {
                member.Accounts = member.Accounts.Where(a => a.Balance >= minBalance && a.Status == Enum.Parse<AccountStatus>(status.ToUpper())).ToList();
            }
            members = members.Where(m => m.Accounts.Count > 0).ToList();

            return Ok(mapper.Map<List<MemberDTO>>(members));
        }
    }
}
