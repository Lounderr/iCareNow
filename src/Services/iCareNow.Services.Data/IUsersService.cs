namespace iCareNow.Services.Data
{
    public interface IUsersService
    {
        public string NormalizeFirstName(string firstName);

        public string NormalizeLastName(string firstName);
    }
}
