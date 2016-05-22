using System.Collections.Generic;
using Domain;

namespace DAL.Interfaces
{
    public interface IArticleRepository : IEFRepository<Article>
    {
        Article FindArticleByName(string articleName);

        List<Article> AllWithTranslations();

        void DeleteArticleWithTranslations(params object[] id);
    }
}