using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
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
        /// Constructor.
        /// </summary>
        public IdeaController(IdeaService ideaService)
        {
            _ideaService = ideaService;
        }

        private readonly IdeaService _ideaService;

        /// <summary>
        /// Gets the list of ideas.
        /// </summary>
        [HttpGet("")]
        [SwaggerResponse(200, "List of ideas obtained.", typeof(IPagedList<Idea>))]
        [SwaggerOperation(Summary = "Gets the list of ideas", Description = "Requires admin privileges", OperationId = "GetIdeas", Tags = new[] { "Idea" })]
        public async Task<IPagedList<Idea>> Index(int pageIndex = 0, int pageSize = 20) => await _ideaService.GetIdeasAsync(pageIndex, pageSize);
    }
}