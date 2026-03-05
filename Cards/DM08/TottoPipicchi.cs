using ContinuousEffects;
using Interfaces;

namespace Cards.DM08;

public sealed class TottoPipicchi : Creature
{
    public TottoPipicchi() : base("Totto Pipicchi", 3, 1000, Race.FireBird, Civilization.Fire)
    {
        AddStaticAbilities(new TottoPipicchiEffect());
    }
}
