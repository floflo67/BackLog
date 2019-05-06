using System.Collections.Generic;

namespace UnitOfWork.Entities
{
    /// <summary>
    /// An idea object stored in the database.
    /// </summary>
    public class Idea
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Status of the idea.
        /// </summary>
        public IdeaStatus Status { get; set; }

        /// <summary>
        /// Text displayed for the idea.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Votes associated to the idea.
        /// </summary>
        public List<Vote> Votes { get; set; }
    }
}