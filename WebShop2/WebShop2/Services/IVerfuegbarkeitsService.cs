namespace WebShop.Services
{
    public interface IVerfuegbarkeitsService
    {
        bool IsAvailable(string produkt);
    }
}
