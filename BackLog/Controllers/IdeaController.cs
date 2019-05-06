using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using UnitOfWork.Entities;

namespace BackLog.Controllers
{
    /// <summary>
    /// Idea Controller.
    /// </summary>
    [Route("api/idea")]
    [ApiController]
    [Produces("application/json")]
    [SwaggerTag("Create, read, update, and delete Ideas")]
    public class IdeaController : Controller
    {
        /// <summary>
        /// Gets the list of ideas.
        /// </summary>
        [HttpGet]
        [SwaggerResponse(200, "List of ideas obtained.", typeof(IEnumerable<Idea>))]
        [SwaggerOperation(Summary = "Gets the list of ideas", Description = "Requires admin privileges", OperationId = "GetIdeas", Tags = new[] { "Idea" })]
        public IEnumerable<Idea> Index()
        {
            return new List<Idea>();
        }
    }
}