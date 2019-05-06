using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using UnitOfWork.Entities;

namespace Service
{
    /// <summary>
    /// Base class used for the service related to ideas.
    /// </summary>
    public partial class IdeaService
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="unitOfWork">Unit of work.</param>
        /// <param name="logger">Logger.</param>
        public IdeaService(IUnitOfWork unitOfWork, ILogger<IdeaService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;

            // seeding
            var repo = _unitOfWork.GetRepository<Idea>();

            if (repo.Count() == 0)
            {
                repo.Insert(new Idea()
                {
                    Id = 1,
                    Status = IdeaStatus.Created,
                    Text = "Idée 1",
                    Votes = new List<Vote>()
                    {
                        new Vote() {
                            Id = 1,
                            HasVotedFor = true,
                            HasVotedAgainst = false,
                            User = new User()
                            {
                                Id = 1,
                                FirstName = "Florian",
                                LastName = "REISS"
                            }
                        },
                        new Vote() {
                            Id = 2,
                            HasVotedFor = false,
                            HasVotedAgainst = true,
                            User = new User()
                            {
                                Id = 2,
                                FirstName = "James",
                                LastName = "Bond"
                            }
                        }
                    }
                });

                repo.Insert(new Idea()
                {
                    Id = 2,
                    Status = IdeaStatus.Created,
                    Text = "Idée 2",
                });

                repo.Insert(new Idea()
                {
                    Id = 3,
                    Status = IdeaStatus.Refused,
                    Text = "Idée 3",
                });

                _unitOfWork.SaveChanges();
            }
        }

        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
    }
}