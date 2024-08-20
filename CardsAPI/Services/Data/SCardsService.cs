using CardsAPI.Services.ServiceInterface;
using CardsAPI.Infrastructure.RepositoryInterface;
using CardsAPI.Models;


namespace CardsAPI.Services.Data
{
    public class SCardsService : ISCardsService
    {
        private readonly ISCardsRepo _cardsRepo;
        public SCardsService(ISCardsRepo cardsRepo)
        {
            _cardsRepo = cardsRepo;
        }

        public async Task<SCards> AddCard(SCards cards)
        {
            return await _cardsRepo.AddCard(cards);
        }

        public async Task<IEnumerable<SCards>> GetAllCards()
        {
            return await _cardsRepo.GetAllCards();
        }

        public async Task<SCards> GetCardsById(Guid id)
        {
            return await _cardsRepo.GetCardsById(id);
        }

        public async Task DeleteCard(Guid id)
        {
            await _cardsRepo.DeleteCard(id);
        }

        public async Task UpdateCardStat(Guid id, String stat)
        {
            await _cardsRepo.UpdateCardStat(id, stat);
        }

        public async Task UpdateCard(Guid id, SCards cards)
        {
            await _cardsRepo.UpdateCard(id,cards);
        }
    }
}
