using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.DM06
{
    sealed class LaveilSeekerOfCatastrophe : Engine.Creature
    {
        public LaveilSeekerOfCatastrophe() : base("Laveil, Seeker of Catastrophe", 8, 8500, Interfaces.Race.MechaThunder, Interfaces.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new OneShotEffects.YouMayUntapThisCreatureEffect()));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
