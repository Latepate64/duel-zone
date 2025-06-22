using Engine;
using Interfaces;

namespace Cards.DM04;

public class GregoriaPrincessOfWar : Creature
{
    public GregoriaPrincessOfWar() : base("Gregoria, Princess of War", 6, 5000, Race.DarkLord, Civilization.Darkness)
    {
        AddStaticAbilities(new GregoriaPrincessOfWarEffect());
    }
}
