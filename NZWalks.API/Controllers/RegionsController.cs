using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models;
using NZWalks.API.Models.Dto;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly WalksContext context;
        private readonly IMapper mapper;
        private readonly IGenericRepository<Region> regionRepo;

        public RegionsController(WalksContext context, IMapper mapper,IGenericRepository<Region> RegionRepo)
        {
            this.context = context;
            this.mapper = mapper;
            regionRepo = RegionRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regions = await regionRepo.GetAllAsync() ;
            return Ok(regions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var region = await regionRepo.GetAsync(id);
            return Ok(region);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegion([FromBody] CreateRegionDto regionDto)
        {
            var region = mapper.Map<Region>(regionDto);

            await regionRepo.Create(region);

            return Ok(region);
        }

        [HttpPut]
        [Route("{Id}")]

        public async Task<IActionResult> UpdateRegion([FromRoute] int Id, [FromBody] Region newRegion)
        {
            if(Id != newRegion.Id)
            {
                return BadRequest();
            }
            var region = await regionRepo.GetAsync(Id);
            if (region == null)
            {
                return NotFound();
            }
            region.RegionImageUrl = newRegion.RegionImageUrl;
            region.Code = newRegion.Code;
            region.Name = newRegion.Name;

            await regionRepo.Update(region);
            return Ok(region);
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] int Id)
        {
            var region = await regionRepo.GetAsync(Id);
            if (region == null)
            {
                return BadRequest();
            }
            await regionRepo.Delete(region);

            return NoContent();
        }
    }
}
