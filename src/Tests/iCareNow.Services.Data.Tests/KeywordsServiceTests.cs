namespace iCareNow.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using iCareNow.Data.Common.Repositories;
    using iCareNow.Data.Models;

    using MockQueryable.Moq;

    using Moq;

    using Xunit;

    public class KeywordsServiceTests : BaseServiceTests
    {
        private Mock<IDeletableEntityRepository<Keyword>> repository;

        public KeywordsServiceTests()
        {
            this.repository = new Mock<IDeletableEntityRepository<Keyword>>();
        }

        [Fact]
        public async Task CreateKeywordShouldReturnValidValueOfAddedKeyword()
        {
            this.repository.Setup(r => r.AllAsNoTracking()).Returns(new List<Keyword>
            {
                new Keyword { Value = "Keyword1" },
                new Keyword { Value = "Keyword2" },
            }.AsQueryable());
            this.repository.Setup(m => m.AddAsync(It.IsAny<Keyword>())).Callback(() => { return; });
            this.repository.Setup(m => m.SaveChangesAsync()).Callback(() => { return; });

            var service = new KeywordsService(this.repository.Object, null);
            var keyword = await service.CreateKeywordAsync("Keyword3");

            this.repository.Verify(x => x.AllAsNoTracking(), Times.Once);
            this.repository.Verify(m => m.AddAsync(It.IsAny<Keyword>()), Times.Once());
            this.repository.Verify(m => m.SaveChangesAsync(), Times.Once());

            Assert.Equal("Keyword3", keyword.Value);
        }

        [Fact]
        public async Task CreateKeywordShouldIncreasesCountWhenAdd()
        {
            var list = new List<Keyword>();

            this.repository.Setup(m => m.AddAsync(It.IsAny<Keyword>()))
            .Callback(() => { list.Add(this.Mapper.Map<Keyword>(new Keyword { Id = 1, Value = "KeywordTest" })); });
            this.repository.Setup(m => m.SaveChangesAsync()).Callback(() => { return; });
            this.repository.Setup(r => r.AllAsNoTracking()).Returns(list.AsQueryable().BuildMock());

            var service = new KeywordsService(this.repository.Object, null);
            var result = await service.GetCountAsync();
            Assert.Equal(list.Count(), result);

            var keyword = await service.CreateKeywordAsync("Keyword2");

            var secondResult = await service.GetCountAsync();
            Assert.Equal(list.Count(), secondResult);
        }

        [Fact]
        public async Task CreateKeywordShouldReturnKeywordIfExist()
        {
            this.repository.Setup(r => r.AllAsNoTracking()).Returns(new List<Keyword>
            {
                new Keyword { Value = "Keyword1", Id = 1 },
                new Keyword { Value = "Keyword2", Id = 2 },
            }.AsQueryable());

            var service = new KeywordsService(this.repository.Object, null);
            var keyword = await service.CreateKeywordAsync("Keyword2");
            Assert.Equal(2, keyword.Id);
            Assert.Equal("Keyword2", keyword.Value);
            this.repository.Verify(x => x.AllAsNoTracking(), Times.Once);
        }

        [Fact]
        public async Task RemoveAllKeywordsForArticleShouldWorkCorrectly()
        {
            var list = new List<ArticleKeyword>();

            var articleKeyword1 = new ArticleKeyword { Id = 2, ArticleId = "8f2ced39-b0f7-4c69-a782-3d487ed9d5d0", KeywordId = 3 };
            list.Add(articleKeyword1);

            var articleKeyword2 = new ArticleKeyword { Id = 4, ArticleId = "b767a2fa-ffec-44fe-b22a-a0c1265ec521", KeywordId = 4 };
            list.Add(articleKeyword2);

            var count = list.Count;

            var repository = new Mock<IRepository<ArticleKeyword>>();
            repository.Setup(m => m.Delete(It.IsAny<ArticleKeyword>()))
            .Callback(() => { list.Remove(articleKeyword1); });
            repository.Setup(m => m.SaveChangesAsync()).Callback(() => { return; });
            repository.Setup(r => r.All()).Returns(list.AsQueryable().BuildMock());

            var service = new KeywordsService(null, repository.Object);
            await service.RemoveAllKeywordsForArticleAsync(articleKeyword1.ArticleId);

            Assert.NotEqual(count, list.Count());
        }
    }
}
