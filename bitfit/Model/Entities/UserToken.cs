namespace bitfit.Model.Entities
{
    public class UserToken : User
    {

        public string AccessToken { get; set; }
        public UserToken(User user)
        {
            this.Id = user.Id;
            this.Email = user.Email;
            this.Name = user.Name;
        }
    }
}
