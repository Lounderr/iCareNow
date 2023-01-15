namespace iCareNow.Services
{
    public class UserDataNormalizer : INormalizer
    {
        public string NormalizeFirstName(string firstName)
        {
            if (firstName == null)
            {
                return null;
            }

            return firstName.Normalize().ToUpperInvariant();
        }

        public string NormalizeLastName(string lastName)
        {
            if (lastName == null)
            {
                return null;
            }

            return lastName.Normalize().ToUpperInvariant();
        }
    }
}
