using Abilities.Static;
using TriggeredAbilities;

namespace Cards.DM06
{
    sealed class LaveilSeekerOfCatastrophe : Creature
    {
        public LaveilSeekerOfCatastrophe() : base("Laveil, Seeker of Catastrophe", 8, 8500, Interfaces.Race.MechaThunder, Interfaces.Civilization.Light)
        {
            AddAbilities(new BlockerAbility());
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new OneShotEffects.YouMayUntapThisCreatureEffect()));
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
