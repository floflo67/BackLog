using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWork.Entities;

namespace Service
{
    public partial class IdeaService
    {
        public async Task<IPagedList<Idea>> GetIdeasAsync(int pageIndex = 0, int pageSize = 20)
        {
            return await _unitOfWork.GetRepository<Idea>().GetPagedListAsync(
                include: source => source.Include(idea => idea.Votes).ThenInclude(vote => vote.User),
                orderBy: source => source.OrderByDescending(idea => idea.Votes.Count),
                pageIndex: pageIndex,
                pageSize: pageSize);
        }
    }
}