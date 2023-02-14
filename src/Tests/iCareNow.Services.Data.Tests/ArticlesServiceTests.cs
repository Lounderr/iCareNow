using iCareNow.Data.Common.Repositories;
using iCareNow.Data.Models;
using iCareNow.Web.ViewModels.Articles;

using MockQueryable.Moq;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Xunit;

namespace iCareNow.Services.Data.Tests
{
    public class ArticlesServiceTests : BaseServiceTests
    {
        private Mock<IDeletableEntityRepository<Article>> repository;

        public ArticlesServiceTests()
        {
            this.repository = new Mock<IDeletableEntityRepository<Article>>();
        }

        [Fact]
        public void GetAllShouldWorkCorrectly()
        {
            var articles = new List<Article>();
            articles.Add(new Article
            {
                Id = "31e2a3ac-07cd-4f5f-896f-bba116b3b94a",
                Title = "Title 1",
                Content = "<h1>Work</h1>",
                BioSystem = "Test1",
                Keywords = new List<ArticleKeyword> { new ArticleKeyword { Keyword = new Keyword { Value = "Test keyword 33" } } },
            });
            articles.Add(new Article
            {
                Id = "8559844c-5599-460c-b6a5-59cedfc45dcc",
                Title = "Tezstq 1",
                Content = "<h1>Work</h1>",
                BioSystem = "Test22",
                Keywords = new List<ArticleKeyword> { new ArticleKeyword { Keyword = new Keyword { Value = "Test keyword 3" } } },
            });
            articles.Add(new Article
            {
                Id = "2f01b17c-c6c5-407d-a04b-d099699a2b73",
                Title = "Fackt 11",
                Content = "<h1>Work</h1>",
                BioSystem = "Test3",
                Keywords = new List<ArticleKeyword> { new ArticleKeyword { Keyword = new Keyword { Value = "Test keyword11" } } },
            });

            this.repository = new Mock<IDeletableEntityRepository<Article>>();
            this.repository.Setup(r => r.AllAsNoTracking()).Returns(articles.BuildMock());

            var service = new ArticlesService(this.repository.Object, null, null);
            var result = service.GetAll<ArticleInputModel>();

            Assert.Equal(articles.Count, result.Count());
            this.repository.Verify(x => x.AllAsNoTracking(), Times.Once);
        }

        [Fact]
        public void GetAllArticlesBasedOnBioSystemsShouldWorkCorrectly()
        {
            var articles = new List<Article>();
            articles.Add(new Article
            {
                Id = "31e2a3ac-07cd-4f5f-896f-bba116b3b94a",
                Title = "Title 1",
                Content = "<h1>Work</h1>",
                BioSystem = "Test1",
                Keywords = new List<ArticleKeyword> { new ArticleKeyword { Keyword = new Keyword { Value = "Test keyword 33" } } },
            });
            articles.Add(new Article
            {
                Id = "8559844c-5599-460c-b6a5-59cedfc45dcc",
                Title = "Tezstq 1",
                Content = "<h1>Work</h1>",
                BioSystem = "Test22",
                Keywords = new List<ArticleKeyword> { new ArticleKeyword { Keyword = new Keyword { Value = "Test keyword 3" } } },
            });
            articles.Add(new Article
            {
                Id = "2f01b17c-c6c5-407d-a04b-d099699a2b73",
                Title = "Fackt 11",
                Content = "<h1>Work</h1>",
                BioSystem = "Test3",
                Keywords = new List<ArticleKeyword> { new ArticleKeyword { Keyword = new Keyword { Value = "Test keyword11" } } },
            });

            this.repository = new Mock<IDeletableEntityRepository<Article>>();
            this.repository.Setup(r => r.AllAsNoTracking()).Returns(articles.BuildMock());

            var articleIds = new string[2];
            articleIds[0] = "31e2a3ac-07cd-4f5f-896f-bba116b3b94a";
            articleIds[1] = "2f01b17c-c6c5-407d-a04b-d099699a2b73";

            var bioSystemIds = new string[1];
            bioSystemIds[0] = "Test3";

            var service = new ArticlesService(this.repository.Object, null, null);
            var result = service.GetAllArticlesBasedOnBioSystems<ArticleInputModel>(articleIds, bioSystemIds);

            Assert.Single(result);
            this.repository.Verify(x => x.AllAsNoTracking(), Times.Once);
        }

        [Fact]
        public void GetAllArticlesBasedOnBioSystemsShouldReturnAllArticlesWithinIdsIfBioSystemIdsAreNull()
        {
            var articles = new List<Article>();
            articles.Add(new Article
            {
                Id = "31e2a3ac-07cd-4f5f-896f-bba116b3b94a",
                Title = "Title 1",
                Content = "<h1>Work</h1>",
                BioSystem = "Test1",
                Keywords = new List<ArticleKeyword> { new ArticleKeyword { Keyword = new Keyword { Value = "Test keyword 33" } } },
            });
            articles.Add(new Article
            {
                Id = "8559844c-5599-460c-b6a5-59cedfc45dcc",
                Title = "Tezstq 1",
                Content = "<h1>Work</h1>",
                BioSystem = "Test22",
                Keywords = new List<ArticleKeyword> { new ArticleKeyword { Keyword = new Keyword { Value = "Test keyword 3" } } },
            });
            articles.Add(new Article
            {
                Id = "2f01b17c-c6c5-407d-a04b-d099699a2b73",
                Title = "Fackt 11",
                Content = "<h1>Work</h1>",
                BioSystem = "Test3",
                Keywords = new List<ArticleKeyword> { new ArticleKeyword { Keyword = new Keyword { Value = "Test keyword11" } } },
            });

            this.repository = new Mock<IDeletableEntityRepository<Article>>();
            this.repository.Setup(r => r.AllAsNoTracking()).Returns(articles.BuildMock());

            var articleIds = new string[2];
            articleIds[0] = "31e2a3ac-07cd-4f5f-896f-bba116b3b94a";
            articleIds[1] = "2f01b17c-c6c5-407d-a04b-d099699a2b73";

            var bioSystemIds = Array.Empty<string>();

            var service = new ArticlesService(this.repository.Object, null, null);
            var result = service.GetAllArticlesBasedOnBioSystems<ArticleInputModel>(articleIds, bioSystemIds);

            Assert.Equal(2, result.Count());
            this.repository.Verify(x => x.AllAsNoTracking(), Times.Once);
        }

        [Theory]
        [InlineData("Title 1", 1)]
        [InlineData("keyword", 3)]
        [InlineData("1", 3)]
        [InlineData("TEST!!!!!!!", 0)]

        public void GetAllArticlesBySearchShouldWorkCorrectly(string search, int exprectedResultCount)
        {
            var articles = new List<Article>();
            articles.Add(new Article
            {
                Id = "31e2a3ac-07cd-4f5f-896f-bba116b3b94a",
                Title = "Title 1",
                Content = "<h1>Work</h1>",
                BioSystem = "Test1",
                Keywords = new List<ArticleKeyword> { new ArticleKeyword { Keyword = new Keyword { Value = "Test keyword 33" } } },
            });
            articles.Add(new Article
            {
                Id = "8559844c-5599-460c-b6a5-59cedfc45dcc",
                Title = "Tezstq 1",
                Content = "<h1>Work</h1>",
                BioSystem = "Test22",
                Keywords = new List<ArticleKeyword> { new ArticleKeyword { Keyword = new Keyword { Value = "Test keyword 3" } } },
            });
            articles.Add(new Article
            {
                Id = "2f01b17c-c6c5-407d-a04b-d099699a2b73",
                Title = "Fackt 11",
                Content = "<h1>Work</h1>",
                BioSystem = "Test3",
                Keywords = new List<ArticleKeyword> { new ArticleKeyword { Keyword = new Keyword { Value = "Test keyword11" } } },
            });

            this.repository = new Mock<IDeletableEntityRepository<Article>>();
            this.repository.Setup(r => r.All()).Returns(articles.BuildMock());

            var service = new ArticlesService(this.repository.Object, null, null);

            var result = service.GetAllArticlesBySearch<ArticleInputModel>(search);

            Assert.Equal(exprectedResultCount, result.Count());
            this.repository.Verify(x => x.All(), Times.Once);
        }

        [Fact]
        public void GetAllSearchArticlesLettersShouldReturnAllLettersForArticles()
        {
            var articles = new List<ArticleInListViewModel>();
            articles.Add(new ArticleInListViewModel
            {
                Id = "31e2a3ac-07cd-4f5f-896f-bba116b3b94a",
                Title = "Title 1",
            });
            articles.Add(new ArticleInListViewModel
            {
                Id = "8559844c-5599-460c-b6a5-59cedfc45dcc",
                Title = "Radaw 1",
            });
            articles.Add(new ArticleInListViewModel
            {
                Id = "2f01b17c-c6c5-407d-a04b-d099699a2b73",
                Title = "Fackt 11",
            });

            var service = new ArticlesService(null, null, null);

            var result = service.GetAllSearchArticlesLetters(articles);

            Assert.Equal(3, result.Count());
        }

        [Fact]
        public async Task DeleteArticleShouldWorkCorrectly()
        {
            var list = new List<Article>();
            var article = new Article
            {
                Id = "31e2a3ac-07cd-4f5f-896f-bba116b3b94a",
                Title = "Title 1",
                Content = "<h1>Work</h1>",
                BioSystem = "Test1",
                Keywords = new List<ArticleKeyword> { new ArticleKeyword { Keyword = new Keyword { Value = "Test keyword 33" } } },
            };
            list.Add(article);

            var count = list.Count;

            this.repository = new Mock<IDeletableEntityRepository<Article>>();
            this.repository.Setup(m => m.Delete(It.IsAny<Article>()))
            .Callback(() => { list.Remove(article); });
            this.repository.Setup(m => m.SaveChangesAsync()).Callback(() => { return; });
            this.repository.Setup(r => r.All()).Returns(list.AsQueryable().BuildMock());

            var service = new ArticlesService(this.repository.Object, null, null);
            await service.DeleteAsync("31e2a3ac-07cd-4f5f-896f-bba116b3b94a");

            Assert.NotEqual(count, list.Count());
        }

        [Fact]
        public async Task GetArticleByIdShouldReturnRigthArticle()
        {
            var list = new List<Article>();
            var article1 = new Article
            {
                Id = "31e2a3ac-07cd-4f5f-896f-bba116b3b94a",
                Title = "Title 1",
                Content = "<h1>Work</h1>",
                BioSystem = "Test1",
                Keywords = new List<ArticleKeyword> { new ArticleKeyword { Keyword = new Keyword { Value = "Test keyword 33" } } },
            };
            list.Add(article1);
            var article2 = new Article
            {
                Id = "8559844c-5599-460c-b6a5-59cedfc45dcc",
                Title = "Title 1",
                Content = "<h1>Work</h1>",
                BioSystem = "Test1",
                Keywords = new List<ArticleKeyword> { new ArticleKeyword { Keyword = new Keyword { Value = "Test keyword 33" } } },
            };
            list.Add(article2);

            this.repository = new Mock<IDeletableEntityRepository<Article>>();
            this.repository.Setup(m => m.SaveChangesAsync()).Callback(() => { return; });
            this.repository.Setup(r => r.AllAsNoTracking()).Returns(list.AsQueryable().BuildMock());

            var service = new ArticlesService(this.repository.Object, null, null);
            var result = await service.GetArticleByIdAsync<ArticleInputModel>("31e2a3ac-07cd-4f5f-896f-bba116b3b94a");

            Assert.Equal(article1.Id, result.Id);
            Assert.Equal(article1.Title, result.Title);
            Assert.Equal(article1.Content, result.Content);
        }

        [Fact]
        public async Task GetArticleKeywordsShouldReturnRigthKeywords()
        {
            var list = new List<ArticleKeyword>();

            var articleKeyword1 = new ArticleKeyword
            {
                Id = 2,
                ArticleId = "8f2ced39-b0f7-4c69-a782-3d487ed9d5d0",
                Keyword = new Keyword { Value = "Test keyword 33" },
            };
            list.Add(articleKeyword1);

            var articleKeyword2 = new ArticleKeyword { Id = 4, ArticleId = "8f2ced39-b0f7-4c69-a782-3d487ed9d5d0", Keyword = new Keyword { Value = "Test keyword 22" } };
            list.Add(articleKeyword2);

            var articleKeyword3 = new ArticleKeyword { Id = 3, ArticleId = "31e2a3ac-07cd-4f5f-896f-bba116b3b94a", Keyword = new Keyword { Value = "Test keywor22" } };
            list.Add(articleKeyword3);

            var repository = new Mock<IRepository<ArticleKeyword>>();
            repository.Setup(r => r.AllAsNoTracking()).Returns(list.AsQueryable().BuildMock());

            var service = new ArticlesService(null, repository.Object, null);
            var result = await service.GetArticleKeywords("8f2ced39-b0f7-4c69-a782-3d487ed9d5d0");

            Assert.Equal("Test keyword 33, Test keyword 22", result);
        }

        [Fact]
        public void GetAllBioSystemsShouldReturnAllSystems()
        {
            var service = new ArticlesService(null, null, null);

            var result = service.GetAllBioSystems();

            var expectedCount = typeof(BioSystem).GetFields(BindingFlags.Public | BindingFlags.Static).ToList().Count;
            Assert.Equal(expectedCount, result.Count());
        }

        [Fact]
        public async Task CreateArticleShouldWorkCorrectly()
        {
            var list = new List<Article>();

            this.repository.Setup(m => m.AddAsync(It.IsAny<Article>()))
            .Callback(() => { list.Add(new Article { Title = "Title", Content = "Content", BioSystem = "BioSystem" }); });
            this.repository.Setup(m => m.SaveChangesAsync()).Callback(() => { return; });
            this.repository.Setup(r => r.AllAsNoTracking()).Returns(list.AsQueryable().BuildMock());

            var keywordRepository = new Mock<IDeletableEntityRepository<Keyword>>();

            var keywordsList = new List<Keyword>();

            keywordRepository.Setup(m => m.AddAsync(It.IsAny<Keyword>()))
            .Callback(() => { keywordsList.Add(this.Mapper.Map<Keyword>(new Keyword { Id = 1, Value = "KeywordTest" })); });
            keywordRepository.Setup(m => m.SaveChangesAsync()).Callback(() => { return; });
            keywordRepository.Setup(r => r.AllAsNoTracking()).Returns(keywordsList.AsQueryable().BuildMock());

            var articleKeywordsList = new List<ArticleKeyword>();

            var articleKeyword2 = new ArticleKeyword { Id = 4, ArticleId = "b767a2fa-ffec-44fe-b22a-a0c1265ec521", KeywordId = 4 };
            var articleKeywordsrepository = new Mock<IRepository<ArticleKeyword>>();
            articleKeywordsrepository.Setup(m => m.AddAsync(It.IsAny<ArticleKeyword>()))
            .Callback(() => { articleKeywordsList.Add(articleKeyword2); });
            articleKeywordsrepository.Setup(m => m.SaveChangesAsync()).Callback(() => { return; });
            articleKeywordsrepository.Setup(r => r.All()).Returns(articleKeywordsList.AsQueryable().BuildMock());

            var keywordsService = new KeywordsService(keywordRepository.Object, null);

            var service = new ArticlesService(this.repository.Object, articleKeywordsrepository.Object, keywordsService);
            var result = await service.GetCountAsync();
            Assert.Equal(list.Count(), result);

            var articleInputModel = new CreateArticleInputModel { Title = "Title", Content = "content", BioSystem = "byoSystem", Keywords = "addadad, addad" };

            await service.CreateAsync(articleInputModel);

            var secondResult = await service.GetCountAsync();
            Assert.Equal(list.Count(), secondResult);
        }
    }
}
