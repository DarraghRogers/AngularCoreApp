using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularCoreWebApp.Controllers.Resources;
using AngularCoreWebApp.Models;
using AngularCoreWebApp.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularCoreWebApp.Controllers
{
    public class MakesController : Controller
    {

        private readonly AngularCoreWebAppDbContext context;
        private readonly IMapper mapper;

        public MakesController(AngularCoreWebAppDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("/api/makes")]
        public async Task<IEnumerable<MakeResource>> GetMakes()
        {
           var makes = await context.Makes.Include(m => m.Models).ToListAsync();
            
            return mapper.Map<List<Make>, List<MakeResource>>(makes);
        }
    }
}