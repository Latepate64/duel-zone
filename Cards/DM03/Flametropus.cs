using TriggeredAbilities;
using Engine;
using Interfaces;

namespace Cards.DM03;

public sealed class Flametropus : Creature
{
    public Flametropus() : base("Flametropus", 4, 3000, Race.RockBeast, Civilization.Fire)
    {
        AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new FlametropusOneShotEffect()));
    }
}
