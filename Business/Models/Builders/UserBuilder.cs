namespace Business.Models.Builders
{
    public class UserBuilder
    {
        private User user = new User();

        public UserBuilder() => this.Reset();

        public void Reset()
        {
            this.user = new User();
        }

        public UserBuilder AddId(int id)
        {
            this.user.Id = id;
            return this;
        }

        public UserBuilder AddName(string name)
        {
            this.user.Name = name;
            return this;
        }

        public UserBuilder AddUsername(string username)
        {
            this.user.Username = username;
            return this;
        }

        public UserBuilder AddEmail(string email)
        {
            this.user.Email = email;
            return this;
        }

        public UserBuilder AddAddress(Address address)
        {
            this.user.Address = address;
            return this;
        }

        public UserBuilder AddPhone(string phone)
        {
            this.user.Phone = phone;
            return this;
        }

        public UserBuilder AddWebsite(string website)
        {
            this.user.Website = website;
            return this;
        }
        
        public UserBuilder AddCompany(Company company)
        {
            this.user.Company = company;
            return this;
        }
        
        public User Build() => this.user;
    }
}