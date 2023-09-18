using CCWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CCWebApp.Repositories
{
    public interface ICardRepository
    {

        Task<IEnumerable<Account>> List_Account();
        Task<IEnumerable<Customer>> List_Customer();
        Task<IEnumerable<Bank>> List_Bank();
        IEnumerable<Account> GetByAccountNo(string account_no);
    }
}
