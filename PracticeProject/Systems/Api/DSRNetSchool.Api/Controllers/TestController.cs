using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSRNetSchool.Api.Controllers
{
    //[Route("api/[controller]")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        /// <summary>
        /// Get data 1
        /// </summary>
        /// <response code="200">String items</response>
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        [ApiVersion("1.0")]
        [HttpGet("")]
        public async Task<IEnumerable<string>> GetData1()
        {
            var result = new List<string>()
            {
                "Item_1",
                "Item_2",
                "Item_3",
                "Item_4",
                "Item_5",
            };

            return result;
        }



        /// <summary>
        /// Get data 2
        /// </summary>
        /// <response code="200">String items</response>
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        [ApiVersion("2.0")]
        [HttpGet("")]
        public async Task<IEnumerable<string>> GetData2(string? prefix)
        {
            var result = new List<string>()
            {
                prefix + "___Item_1",
                prefix + "___Item_1_2",
                prefix + "___Item_1_3",
                prefix + "___Item_1_4",
                prefix + "___Item_1_5",
            };

            return result;
        }




    }
}
