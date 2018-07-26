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
    public class FeaturesController : Controller
    {
        private readonly AngularCoreWebAppDbContext context;
        private readonly IMapper mapper;

        public FeaturesController(AngularCoreWebAppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("/api/features")]
        public async Task<IEnumerable<FeatureResource>> GetResources()
        {
            var features = await context.Features.ToListAsync();

            return mapper.Map<List<Feature>, List<FeatureResource>>(features);

        }
    }
}