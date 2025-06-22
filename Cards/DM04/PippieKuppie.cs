using Engine;
using Interfaces;

namespace Cards.DM04;

public class PippieKuppie : Creature
{
    public PippieKuppie() : base("Pippie Kuppie", 2, 1000, Race.FireBird, Civilization.Fire)
    {
        AddStaticAbilities(new PippieKuppieEffect());
    }
}
