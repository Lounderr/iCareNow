using iCareNow.Data.Common.Repositories;
using iCareNow.Data.Models;
using iCareNow.Web.ViewModels.Articles;

using System.Threading.Tasks;

namespace iCareNow.Services.Data
{
    public class ArticlesService : IArticlesService
    {
        private readonly IDeletableEntityRepository<Article> articlesRepository;

        public ArticlesService(IDeletableEntityRepository<Article> articlesRepository)
        {
            this.articlesRepository = articlesRepository;
        }

        public async Task CreateAsync(CreateArticleInputModel inputModel)
        {
            var article = new Article
            {
                Content = inputModel.Content,
            };

            await this.articlesRepository.AddAsync(article);
            await this.articlesRepository.SaveChangesAsync();
        }
    }
}
