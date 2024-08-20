using CardsAPI.Data;
using CardsAPI.Infrastructure.RepositoryInterface;
using CardsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CardsAPI.Infrastructure.DataRepository
{
    public class SCardsRepo : ISCardsRepo
    {

        private readonly CardsAPIContext _context;
        public SCardsRepo(CardsAPIContext context)
        {
            _context = context;
        }

        public async Task<SCards> AddCard(SCards cards)
        {
            _context.sCards.Add(cards);
            await _context.SaveChangesAsync();
            return cards;
        }

        public async Task<IEnumerable<SCards>> GetAllCards()
        {
            var deck = await _context.sCards.ToListAsync();
            return deck;
        }

        public async Task<SCards> GetCardsById(Guid id)
        {
            var card = await _context.sCards.FindAsync(id);
            return card;
        }

        public async Task DeleteCard(Guid id)
        {
            var card = await _context.sCards.FindAsync(id);
            if (card != null)
            {
                _context.sCards.Remove(card);
                await _context.SaveChangesAsync();

            }
        }

        public async Task UpdateCardStat(Guid id, String stat)
        {
            SCards card = await _context.sCards.FindAsync(id);

            if (card != null)
            {
                card.Stat = stat;
                _context.sCards.Entry(card).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateCard(Guid id, SCards cards)
        {

           
                SCards c = await _context.sCards.FindAsync(id);
                if (c != null)
                {
                    c.Question = cards.Question;
                    c.Answer = cards.Answer;
                    c.Stat = cards.Stat;
                    _context.sCards.Entry(c).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
            
          

         
        }

    }
}
