using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.API.Commands.Companies;
using Project.Domain.DTOs;
using Project.Domain.Interfaces.Repositories;
using Project.Domain.Models;
using System;
using System.Collections.Generic;

namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IMapper mapper;

        public CompaniesController(ICompanyRepository companyRepository, IMapper mapper)
        {
            this.companyRepository = companyRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post(CreateCompanyCommand command)
        {
            if (!companyRepository.Exists(command.Name))
            {
                var company = mapper.Map<Company>(command);

                try
                {
                    companyRepository.Add(company);
                    return StatusCode(201, new { Message = "Company successfully created." });
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            else
            {
                return StatusCode(409, new { Message = "The company already exists." });
            }            
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(mapper.Map<List<CompanyDTO>>(companyRepository.GetAll()));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
