using WebShop.Entities;

namespace WebShop.Repositories
{
    public class BestellungenRepository: CrudRepository<TblBestellung>, IBestellungenRepository
    {
        public BestellungenRepository(WebShopContext context) : base(context)
        {
        }       
    }
}
