using Engine;

namespace Cards
{
    public interface ICardFactory
    {
        Card Create(string name);
    }
}