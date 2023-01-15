namespace iCareNow.Services
{
    public interface INormalizer
    {
        public string NormalizeFirstName(string firstName);

        public string NormalizeLastName(string lastName);
    }
}
