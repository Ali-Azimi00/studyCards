using CardsAPI.Models;

namespace CardsAPI.Infrastructure.RepositoryInterface
{
    public interface ISCardsRepo
    {
        Task<IEnumerable<SCards>> GetAllCards();
        Task<SCards> GetCardsById(Guid id);
        Task<SCards> AddCard(SCards card);
        Task UpdateCardStat(Guid id, String stat);
        Task UpdateCard(Guid id, SCards card);
        Task DeleteCard(Guid id);
    }
}
