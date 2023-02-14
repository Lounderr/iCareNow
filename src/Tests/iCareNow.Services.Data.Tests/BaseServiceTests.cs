namespace iCareNow.Services.Data.Tests
{
    using System.Reflection;
    using AutoMapper;

    using iCareNow.Services.Mapping;

    using iCareNow.Web;

    public class BaseServiceTests
    {
        private IMapper mapper;

        public BaseServiceTests()
        {
            AutoMapperConfig.RegisterMappings(Assembly.Load("iCareNow.Web.ViewModels"));
            this.mapper = this.GetMapper();
            this.Mapper = this.mapper;
        }

        protected IMapper Mapper { get; set; }

        private IMapper GetMapper()
        {
            var mappingProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
            return new Mapper(configuration);
        }
    }
}
