using iCareNow.Data.Common.Repositories;
using iCareNow.Data.Models;
using iCareNow.Services.Mapping;
using iCareNow.Web.ViewModels.Articles;

using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

using static System.Net.Mime.MediaTypeNames;

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
                Content = WebUtility.HtmlEncode(inputModel.Content),
            };

            await this.articlesRepository.AddAsync(article);
            await this.articlesRepository.SaveChangesAsync();
        }

        public Task<T> GetArticleByIdAsync<T>(string id)
        {
            return this.articlesRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();
        }
    }
}
