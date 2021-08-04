using LibraryTechWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using LibraryTechWebApp.Models;

namespace LibraryTechWebApp.BusinessLogic
{
    public class Cart
    {
        private List<BookAsCartRecord> _listRecords;

        public List<BookAsCartRecord> Records => _listRecords;

        public Cart()
        {
            _listRecords = new List<BookAsCartRecord>();
        }

        public virtual void Add(BookAsCartRecord book)
        {
            BookAsCartRecord record = _listRecords
                .FirstOrDefault(b => b.BookId == book.BookId);
            if (record == null)
            {
                _listRecords.Add(book);
            }
        }

        public virtual void Remove(BookAsCartRecord book)
        {
            BookAsCartRecord record = _listRecords
                .FirstOrDefault(b => b.BookId == book.BookId);
            if (record != null) _listRecords.Remove(record);
        }

        public virtual void Clear()
        {
            _listRecords.Clear();
        }

        public decimal TotalCoast =>
            _listRecords.Sum(r => r.Price);
    }
}
