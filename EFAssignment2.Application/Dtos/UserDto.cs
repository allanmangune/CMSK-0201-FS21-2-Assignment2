namespace  EFAssignment2.Application.Dtos
{
    public class UserDto
    {
        /// <summary>
        /// Gets or sets the user's ID.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the user's name. 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the user's email address.
        ///</summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the user's phone number.
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}