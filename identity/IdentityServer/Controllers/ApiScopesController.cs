using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Skoruba.IdentityServer4.Admin.Api.Dtos.ApiScopes;

namespace Server.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiScopesController : ControllerBase
    {
        //private readonly IApiErrorResources _errorResources;
        //private readonly IApiScopeService _apiScopeService;

        public ApiScopesController(/*IApiErrorResources errorResources, IApiScopeService apiScopeService*/)
        {
            //_errorResources = errorResources;
            //_apiScopeService = apiScopeService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiScopesApiDto>> GetScopes(string search, int page = 1, int pageSize = 10)
        {
           // var apiScopesDto = await _apiScopeService.GetApiScopesAsync(search, page, pageSize);
            ApiScopesApiDto apiScopesApiDto = null;//apiScopesDto.ToApiScopeApiModel<ApiScopesApiDto>();

            return Ok(apiScopesApiDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiScopeApiDto>> GetScope(int id)
        {
           // var apiScopesDto = await _apiScopeService.GetApiScopeAsync(id);
            ApiScopeApiDto apiScopeApiDto = null;// apiScopesDto.ToApiScopeApiModel<ApiScopeApiDto>();

            return Ok(apiScopeApiDto);
        }

        [HttpGet("{id}/Properties")]
        public async Task<ActionResult<ApiScopePropertiesApiDto>> GetScopeProperties(int id, int page = 1, int pageSize = 10)
        {
            //var apiScopePropertiesDto = await _apiScopeService.GetApiScopePropertiesAsync(id, page, pageSize);
            ApiScopePropertiesApiDto apiScopePropertiesApiDto = null;//apiScopePropertiesDto.ToApiScopeApiModel<ApiScopePropertiesApiDto>();

            return Ok(apiScopePropertiesApiDto);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostScope([FromBody] ApiScopeApiDto apiScopeApi)
        {
            //var apiScope = apiScopeApi.ToApiScopeApiModel<ApiScopeDto>();

            //if (!apiScope.Id.Equals(default))
            //{
            //    return BadRequest(_errorResources.CannotSetId());
            //}

            //var id = await _apiScopeService.AddApiScopeAsync(apiScope);
            //apiScope.Id = id;

            return CreatedAtAction(nameof(GetScope), new { scopeId = "id" }, new ApiScope());
        }

        [HttpPost("{id}/Properties")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostProperty(int id, [FromBody] ApiScopePropertyApiDto apiScopePropertyApi)
        {
            //var apiResourcePropertiesDto = apiScopePropertyApi.ToApiScopeApiModel<ApiScopePropertiesDto>();
            //apiResourcePropertiesDto.ApiScopeId = id;

            //if (!apiResourcePropertiesDto.ApiScopePropertyId.Equals(default))
            //{
            //    return BadRequest(_errorResources.CannotSetId());
            //}

            //var propertyId = await _apiScopeService.AddApiScopePropertyAsync(apiResourcePropertiesDto);
            //apiScopePropertyApi.Id = propertyId;

            return CreatedAtAction(nameof(GetProperty), new { propertyId = ""}, apiScopePropertyApi);
        }

        [HttpGet("Properties/{propertyId}")]
        public async Task<ActionResult<ApiScopePropertyApiDto>> GetProperty(int propertyId)
        {
            //var apiScopePropertyAsync = await _apiScopeService.GetApiScopePropertyAsync(propertyId);
            ApiScopePropertyApiDto resourcePropertyApiDto = null;// apiScopePropertyAsync.ToApiScopeApiModel<ApiScopePropertyApiDto>();

            return Ok(resourcePropertyApiDto);
        }

        [HttpDelete("Properties/{propertyId}")]
        public async Task<IActionResult> DeleteProperty(int propertyId)
        {
            //var apiScopePropertiesDto = new ApiScopePropertiesDto { ApiScopePropertyId = propertyId };

            //await _apiScopeService.GetApiScopePropertyAsync(apiScopePropertiesDto.ApiScopePropertyId);
            //await _apiScopeService.DeleteApiScopePropertyAsync(apiScopePropertiesDto);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutScope([FromBody] ApiScopeApiDto apiScopeApi)
        {
            //var apiScope = apiScopeApi.ToApiScopeApiModel<ApiScopeDto>();

            //await _apiScopeService.GetApiScopeAsync(apiScope.Id);

            //await _apiScopeService.UpdateApiScopeAsync(apiScope);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScope(int id)
        {
            //var apiScope = new ApiScopeDto { Id = id };

            //await _apiScopeService.GetApiScopeAsync(apiScope.Id);

            //await _apiScopeService.DeleteApiScopeAsync(apiScope);

            return Ok();
        }
    }
}
