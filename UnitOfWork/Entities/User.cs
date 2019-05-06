namespace UnitOfWork.Entities
{
    /// <summary>
    /// A user object stored in the database.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Firstname of the user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Lastname of the user.
        /// </summary>
        public string LastName { get; set; }
    }
}