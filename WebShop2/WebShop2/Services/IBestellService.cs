using WebShop.Entities;

namespace WebShop.Services
{
    public interface IBestellService
    {
        BestellStatus ErfasseBestellung(TblBestellung bestellung);
    }
}
