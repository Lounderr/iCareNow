namespace iCareNow.Services.Data
{
    public interface IUsersService
    {
        string NormalizeFirstName(string firstName);

        string NormalizeLastName(string firstName);

        string CapitalizeName(string name);
    }
}
