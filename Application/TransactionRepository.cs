﻿using BankAccountKata.Interfaces;

namespace BankAccountKata.Application
{
    public class TransactionRepository : ITransactionRepository
    {
        private IClock clock;
        private List<Transaction> transactions = new();

        public TransactionRepository(IClock clock)
        {
            this.clock = clock;
        }

        public List<Transaction> AllTransactions()
        {
            return transactions;
        }

        public void WithDraw(int amount)
        {
            var transactionWithDraw = new Transaction(clock.DateAsString(), -amount);
            transactions.Add(transactionWithDraw);
        }

        public void AddDeposit(int amount)
        {
            var transactionDeposit = new Transaction(clock.DateAsString(), amount);
            transactions.Add(transactionDeposit);
        }
    }
}