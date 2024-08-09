﻿using Microsoft.AspNetCore.Mvc;
using nopCommerceApi.Models.SpecyficationAttribute;
using nopCommerceApi.Models.SpecyficationAttributeGroup;
using nopCommerceApi.Services.SpecificationAttribute;

namespace nopCommerceApi.Controllers.SpecificationAttribute
{
    /// <summary>
    /// Specification attributes are product features i.e, screen size, number of USB-ports, visible on product details page. 
    /// Specification attributes can be used for filtering products on the category details page. Unlike product attributes, 
    /// specification attributes are used for information purposes only. 
    /// You can add attributes to existing product on a product details page
    /// Note: Specification attribute need to have option and group! If not, it will be ignored.
    /// For example: Product (specification attribute group) -> color (specification attribute) -> red, blue, green (specification attribute option)
    /// </summary>
    [Route("specification-attribute")]
    [ApiController]
    public class SpecificationAttributeController : ControllerBase
    {
        private readonly ISpecificationAttributeService _specificationAttributeService;
        private readonly SpecificationAttributeGroupService _specificationAttributeGroupService;

        public SpecificationAttributeController(ISpecificationAttributeService specificationAttributeService, SpecificationAttributeGroupService specificationAttributeGroupService)
        {
            _specificationAttributeService = specificationAttributeService;
            _specificationAttributeGroupService = specificationAttributeGroupService;
        }

        #region specificationAttributeService

        /// <summary>
        /// Get all specification attributes
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllSpecificationAttributes()
        {
            var specificationAttributes = await _specificationAttributeService.GetAllAsync();
            return Ok(specificationAttributes);
        }

        /// <summary>
        /// Get specification attribute by id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecificationAttributeById(int id)
        {
            var specificationAttribute = await _specificationAttributeService.GetByIdAsync(id);
            return Ok(specificationAttribute);
        }

        /// <summary>
        /// Create a specification attribute
        /// </summary>
        /// <remarks>
        /// Note: Specification attribute need to have option and group! If not, it will be ignored. \
        /// For example: Product (specification attribute group) -> color (specification attribute) -> red, blue, green (specification attribute option)
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> CreateSpecificationAttribute([FromBody] SpecificationAttributeCreateDto specificationAttributeCreateDto)
        {
            var specificationAttribute = await _specificationAttributeService.CreateAsync(specificationAttributeCreateDto);
            return Created("specificationAttributes", specificationAttribute);
        }

        /// <summary>
        /// Update a specification attribute
        /// </summary>
        /// <remarks>
        /// Note: Specification attribute need to have option and group! If not, it will be ignored. \
        /// For example: Product (specification attribute group) -> color (specification attribute) -> red, blue, green (specification attribute option)
        /// </remarks>
        [HttpPut]
        public async Task<IActionResult> UpdateSpecificationAttribute([FromBody] SpecificationAttributeUpdateDto specificationAttributeUpdateDto)
        {
            await _specificationAttributeService.UpdateAsync(specificationAttributeUpdateDto);

            return Ok(specificationAttributeUpdateDto);
        }

        /// <summary>
        /// Delete a specification attribute
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecificationAttribute(int id)
        {
            await _specificationAttributeService.DeleteAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Get specification attribute by name
        /// </summary>
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetSpecificationAttributeByName(string name)
        {
            var specificationAttribute = await _specificationAttributeService.GetByNameAsync(name);
            return Ok(specificationAttribute);
        }

        #endregion

        #region specificationAttributeGroupService

        /// <summary>
        /// Get all attribute specyfication group associate with specification attributes
        /// </summary>
        [HttpGet("group")]
        public async Task<IActionResult> GetAllSpecificationAttributeGroups()
        {
            var specificationAttributeGroups = await _specificationAttributeGroupService.GetAllAsync();
            return Ok(specificationAttributeGroups);
        }

        /// <summary>
        /// Get attribute specyfication group associate with specification attributes by id
        /// </summary>
        [HttpGet("group/{id}")]
        public async Task<IActionResult> GetSpecificationAttributeGroupById(int id)
        {
            var specificationAttributeGroup = await _specificationAttributeGroupService.GetByIdAsync(id);
            return Ok(specificationAttributeGroup);
        }

        /// <summary>
        /// Create attribute specyfication group associate with specification attributes
        /// </summary>
        [HttpPost("group")]
        public async Task<IActionResult> CreateSpecificationAttributeGroup([FromBody] SpecificationAttributeGroupCreateDto specificationAttributeGroupCreateDto)
        {
            var specificationAttributeGroup = await _specificationAttributeGroupService.CreateAsync(specificationAttributeGroupCreateDto);
            return Created("specificationAttributeGroups", specificationAttributeGroup);
        }

        /// <summary>
        /// Update attribute specyfication group associate with specification attributes
        /// </summary>
        [HttpPut("group")]
        public async Task<IActionResult> UpdateSpecificationAttributeGroup([FromBody] SpecificationAttributeGroupUpdateDto specificationAttributeGroupUpdateDto)
        {
            await _specificationAttributeGroupService.UpdateAsync(specificationAttributeGroupUpdateDto);

            return Ok(specificationAttributeGroupUpdateDto);
        }

        /// <summary>
        /// Delete attribute specyfication group associate with specification attributes
        /// </summary>
        [HttpDelete("group/{id}")]
        public async Task<IActionResult> DeleteSpecificationAttributeGroup(int id)
        {
            await _specificationAttributeGroupService.DeleteAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Get attribute specyfication group associate with specification attributes
        /// </summary>
        [HttpGet("group/name/{name}")]
        public async Task<IActionResult> GetSpecificationAttributeGroupByName(string name)
        {
            var specificationAttributeGroup = await _specificationAttributeGroupService.GetByNameAsync(name);
            return Ok(specificationAttributeGroup);
        }

        #endregion
    }
}