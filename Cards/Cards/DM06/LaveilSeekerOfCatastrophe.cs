using TriggeredAbilities;
using ContinuousEffects;

namespace Cards.Cards.DM06
{
    class LaveilSeekerOfCatastrophe : Engine.Creature
    {
        public LaveilSeekerOfCatastrophe() : base("Laveil, Seeker of Catastrophe", 8, 8500, Engine.Race.MechaThunder, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new OneShotEffects.YouMayUntapThisCreatureEffect()));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
