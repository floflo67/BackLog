namespace UnitOfWork.Entities
{
    /// <summary>
    /// An idea status object stored in the database.
    /// </summary>
    public enum IdeaStatus
    {
        /// <summary>
        /// Idea has been created.
        /// </summary>
        Created = 1,

        /// <summary>
        /// Idea has been accepted.
        /// </summary>
        Accepted = 2,

        /// <summary>
        /// Idea has been deleted.
        /// </summary>
        Deleted = 3,

        /// <summary>
        /// Idea has been refused.
        /// </summary>
        Refused = 4,

        /// <summary>
        /// Idea has been archived.
        /// </summary>
        Archived = 5,

        /// <summary>
        /// Idea can be voted on.
        /// </summary>
        UpForVote = 6,
    }
}