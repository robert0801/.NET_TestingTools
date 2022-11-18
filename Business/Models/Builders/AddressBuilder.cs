namespace Business.Models.Builders
{
    public class AddressBuilder
    {
        private Address address = new Address();
        public AddressBuilder() => this.Reset();

        public void Reset()
        {
            this.address = new Address();
        }

        public AddressBuilder AddStreet(string street)
        {
            this.address.Street = street;
            return this;
        }

        public AddressBuilder AddSuite(string suite)
        {
            this.address.Suite = suite;
            return this;
        }

         public AddressBuilder AddCity(string city)
        {
            this.address.City = city;
            return this;
        }
        
        public AddressBuilder AddZipcode(string zipcode)
        {
            this.address.Zipcode = zipcode;
            return this;
        }
        
        public AddressBuilder AddGeo(Geo geo)
        {
            this.address.Geo = geo;
            return this;
        }
       
        public Address Build() => address;
    }
}