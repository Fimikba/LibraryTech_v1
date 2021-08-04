using LibraryTechWebApp.DataAccessLayer;
using LibraryTechWebApp.Domains;
using LibraryTechWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTechWebApp.BusinessLogic
{
    public class StatisticAnalizer
    {
        private ILtSqlRepositoryable _repository;

        public StatisticAnalizer(ILtSqlRepositoryable repository)
        {
            _repository = repository;
        }


        public IQueryable<Book> GetTopSellingStatistics()
        {
            return _repository.BooksForStatistic.OrderByDescending(b => b.User.Count);
        }

        public IQueryable<Book> GetTopReadBySubsStatistics()
        {
            return _repository.BooksForStatistic.OrderByDescending(b => b.UserHowRecentlyReadBySubs.Count);
        }
    }
}
