using TriggeredAbilities;
using Interfaces;
using OneShotEffects;
using Abilities.Static;

namespace Cards.DM12;

public sealed class AuraPegasusAvatarOfLife : VortexEvolutionCreature
{
    public AuraPegasusAvatarOfLife() : base("Aura Pegasus, Avatar of Life", 6, 12000, Civilization.Light,
        Civilization.Nature, Race.Pegasus, Race.HornedBeast, Race.AngelCommand)
    {
        AddTriggeredAbility(new WheneverThisCreatureAttacksOrLeavesTheBattleZoneAbility(new AuraPegasusEffect()));
        AddAbilities(new TripleBreakerAbility());
    }
}
