using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using NZWalks.API.Models.DTOs;
using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Repositories;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.CustomActionFilters;

namespace NZWalks.API.Controllers
{
    // /api/walks
    [Route("api/[controller]")]
    [ApiController]

    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }
        // Create Walk
        // POST: /api/walks
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        { 
            // Map AddWalkRequestDto to Walk Domain Model
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

            await walkRepository.CreateAsync(walkDomainModel);

            return Ok(mapper.Map<WalkDTO>(walkDomainModel));
            
        }

        // GET Walks
        // GET: /api/walks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walksDomainModel = await walkRepository.GetAllAsync();
            // Map Domain Model to DTO
            return Ok(mapper.Map<List<WalkDTO>>(walksDomainModel));
        }

        // GET Walk by Id
        // GET: /api/Walks/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.GetByIdAsync(id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDTO>(walkDomainModel));
        }

        // Update Walk by Id
        // PUT:/api/Walks/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto UpdateWalkRequestDto)
        {
           
            // Map Dto to Doamil Model
            var walkDomailModel = mapper.Map<Walk>(UpdateWalkRequestDto);

            // Check if the walk exists
            walkDomailModel = await walkRepository.UpdateAsync(id, walkDomailModel);

            if (walkDomailModel == null)
            {
                return NotFound();
            }

            // Convert Domail Model to DTO and return DTO
            return Ok(mapper.Map<WalkDTO>(walkDomailModel));
          
            
        }

        // Delete Walk by Id
        // DELETE:/api/Walks/{id}
        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Delete ([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.DeleteAsync(id);

            // check if the walk exist
            if (walkDomainModel == null)
            {
                return NotFound();
            }

            // Convert Domail Model to DTO and return DTO
            return Ok(mapper.Map<WalkDTO>(walkDomainModel));


        }
    }
}
