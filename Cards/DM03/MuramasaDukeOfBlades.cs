using TriggeredAbilities;
using Engine;
using Interfaces;
using OneShotEffects;

namespace Cards.DM03;

public sealed class MuramasaDukeOfBlades : Creature
{
    public MuramasaDukeOfBlades() : base("Muramasa, Duke of Blades", 6, 3000, Race.Human, Civilization.Fire)
    {
        AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new MuramasaDukeOfBladesEffect()));
    }
}
