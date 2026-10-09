using Abilities.Static;
using Interfaces;
using TriggeredAbilities;

namespace Cards.DM11;

public sealed class EvilIncarnate : EvolutionCreature
{
    public EvilIncarnate() : base("Evil Incarnate", 6, 11000, Race.DevilMask, Civilization.Darkness)
    {
        AddTriggeredAbility(new EvilIncarnateAbility());
        AddAbilities(new DoubleBreakerAbility());
    }
}
