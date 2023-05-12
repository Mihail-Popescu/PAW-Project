using System;
using System.Collections.Generic;
using System.Linq;
using ProiectPAW__MVC_.Models;
using ProiectPAW__MVC_.Data;

namespace ProiectPAW__MVC_.Repositories
{
    public class CardRepository
    {
        private readonly ProiectPAWDbContext _context;

        public CardRepository(ProiectPAWDbContext context)
        {
            _context = context;
        }

        public void AddCard(Card card)
        {
            _context.Card.Add(card);
            _context.SaveChanges();
        }

        public void UpdateCard(Card card)
        {
            _context.Card.Update(card);
            _context.SaveChanges();
        }

        public void RemoveCard(int cardId)
        {
            var card = _context.Card.Find(cardId);
            if (card != null)
            {
                _context.Card.Remove(card);
                _context.SaveChanges();
            }
        }

        public Card GetCardById(int cardId)
        {
            return _context.Card.FirstOrDefault(c => c.CardId == cardId);
        }

        public List<Card> GetAllCards()
        {
            return _context.Card.ToList();
        }
    }
}