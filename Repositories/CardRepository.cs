using CCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System.Linq;
namespace CCWebApp.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly APIDBContext _context;

        public CardRepository(APIDBContext context)
        {
            _context = context;
        }

        public IQueryable<Account> accounts => _context.Accounts;

        //public async Task<IEnumerable<Account>> List_Account()
        //{
        //    return await _context.Accounts.ToListAsync();
        //}

        public async Task<IEnumerable<Account>> List_Account()
        {
            var query = from a in _context.Accounts
                        join c in _context.Customers on a.CustomerID equals c.CustomerId
                        join b in _context.Banks on a.BankID equals b.BankId                        
                        select new Account
                        {
                            AccountId = a.AccountId,
                            CustomerID = c.CustomerId,
                            CustomerName = c.CustomerName,
                            AccountNo = a.AccountNo,
                            CardNo = a.CardNo,
                            BankID = a.BankID,
                            BankName = b.BankName,
                            CreditLimit = a.CreditLimit,
                            InterestRate = a.InterestRate,
                            Balance = a.Balance,
                            PaymentDueDate = a.PaymentDueDate
                        };

                return await query.ToListAsync();
        }

        public async Task<IEnumerable<Customer>> List_Customer()
        {

            return await _context.Customers.ToListAsync();
        }

        public async Task<IEnumerable<Bank>> List_Bank()
        {
            return await _context.Banks.ToListAsync();
        }   

        public IEnumerable<Account> GetByAccountNo(string account_no)
        {
            var query = from a in _context.Accounts
                        join c in _context.Customers on a.CustomerID equals c.CustomerId
                        join b in _context.Banks on a.BankID equals b.BankId
                        where a.AccountNo.Contains(account_no)
                        select new Account
                        {
                            AccountId = a.AccountId,
                            CustomerID = c.CustomerId,
                            CustomerName = c.CustomerName,
                            AccountNo = a.AccountNo,
                            CardNo = a.CardNo,
                            BankID = a.BankID,
                            BankName = b.BankName,
                            CreditLimit = a.CreditLimit,
                            InterestRate = a.InterestRate,
                            Balance = a.Balance,
                            PaymentDueDate = a.PaymentDueDate
                        };

            return (IEnumerable<Account>)query.ToList();
            //return _context.Accounts.Where(d => d.AccountNo.Contains(account_no)).ToList();

        }
    }
}
