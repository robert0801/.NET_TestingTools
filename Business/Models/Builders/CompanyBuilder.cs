namespace Business.Models.Builders
{
    public class CompanyBuilder
    {
        private Company company = new Company();
        public CompanyBuilder()
        { 
            this.Reset();
        }

        public void Reset()
        {
            this.company = new Company();
        }

        public CompanyBuilder AddName(string name)
        {
            this.company.Name = name;
            return this;
        }

        public CompanyBuilder AddCatchPhrase(string catchPhrase)
        {
            this.company.CatchPhrase = catchPhrase;
            return this;
        }

        public CompanyBuilder AddBs(string bs)
        {
            this.company.Bs = bs;
            return this;
        }
       
        public Company Build() => company;
    }
}