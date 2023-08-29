using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    //[ApiVersion("1.0", Deprecated =true)]
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/books")]
    [ApiExplorerSettings(GroupName = "v1")]

    //[Route("api/{v:apiversion}/books")]
    //[ResponseCache(CacheProfileName ="5mins")]
    //[HttpCacheExpiration(CacheLocation =CacheLocation.Public,MaxAge =80)]
    public class BooksController : ControllerBase
    {

        private readonly IServiceManager _manager;

        public BooksController(IServiceManager manager)
        {
            _manager = manager; 
        }

        [Authorize(Roles ="User, Editor, Admin")]
        [HttpHead]
        [HttpGet(Name ="GetAllBooks")]
        [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
        //[ResponseCache(Duration =60)]
        public async Task<IActionResult> GetAllBooks([FromQuery]BookParameters bookParameters)
        {
            var linkParameters = new LinkParameters()
            {
                BookParameters = bookParameters,
                HttpContext = HttpContext
            };
            var linkResult = await _manager.BookService.GetAllBooksAsync(linkParameters, false);

            Response.Headers.Add("X-Pagination",JsonSerializer.Serialize(linkResult.metaData));
            return linkResult.linkResponse.HasLinks ?
                Ok(linkResult.linkResponse.LinkedEntities) :
                Ok(linkResult.linkResponse.ShapedEntities);
        }

        [Authorize(Roles = "User, Editor, Admin")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneBooks([FromRoute(Name = "id")] int id)
        {

            var book = await _manager.BookService.GetOneBookByIdAsync(id, false);



            return Ok(book);
        }


        [Authorize]
        [HttpGet("details")]
        public async Task<IActionResult> GetAllBooksWithDetailsAsync()
        {
            return Ok(await _manager.BookService.GetAllBooksWithDetailsAsync(false));
        }


        //[ServiceFilter(typeof(LogFilterAttribute))]
        [Authorize(Roles = "Admin, Editor")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost(Name = "CreateOneBook")]
        public async Task<IActionResult> CreateOneBook([FromBody] BookDtoForInsertions bookDto)
        {
            // filter yüzünden gerek kalmayna kod parçası

            //if (bookDto is null)
            //    return BadRequest();

            //if (!ModelState.IsValid)
            //    return UnprocessableEntity(ModelState);

            var book = await _manager.BookService.CreateOneBookAsync(bookDto);    
            return StatusCode(201, book);  //CreatedAtRoute()
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] BookDtoForUpdate bookDto)
        {
            //if (bookDto is null)
            //    return BadRequest();

            //if (!ModelState.IsValid)
            //    return UnprocessableEntity(ModelState);

            await _manager.BookService.UpdateOneBookAsync(id, bookDto, false);



            return NoContent();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async  Task<IActionResult> DeleteOneBook([FromRoute(Name = "id")] int id)
        {
            await _manager.BookService.DeleteOneBookAsync(id, false);
            return NoContent();
        }

        [HttpPatch]
        [Route("{id:int}")]
        public async Task<IActionResult> PartiallyUpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<BookDtoForUpdate> bookPatch)
        {
            //if(bookPatch is null)
            //    return BadRequest();

            var result = await _manager.BookService.GetOneBookForPatchAsync(id, false);

            bookPatch.ApplyTo(result.bookDtoForUpdate,ModelState);
            TryValidateModel(result.bookDtoForUpdate);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _manager.BookService.SaveChangesForPatchAsync(result.bookDtoForUpdate, result.book);

            return NoContent();
        }


        [HttpOptions]
        public IActionResult GetBooksOptions()
        {
            Response.Headers.Add("Allow", "GET, PUT, POST, PATH, DELETE, HEAD, OPTIONS");
            return Ok();
        }

    }
}