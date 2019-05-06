namespace UnitOfWork.Entities
{
    /// <summary>
    /// An vote object stored in the database.
    /// </summary>
    public class Vote
    {
        /// <summary>
        /// Indicate if the vote is against the idea.
        /// </summary>
        public bool HasVotedAgainst { get; set; }

        /// <summary>
        /// Indicate if the vote is for the idea.
        /// </summary>
        public bool HasVotedFor { get; set; }

        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User who casted the vote.
        /// </summary>
        public User User { get; set; }
    }
}