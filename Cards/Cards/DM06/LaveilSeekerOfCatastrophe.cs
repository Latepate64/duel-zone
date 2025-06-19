using Cards.ContinuousEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.DM06
{
    class LaveilSeekerOfCatastrophe : Creature
    {
        public LaveilSeekerOfCatastrophe() : base("Laveil, Seeker of Catastrophe", 8, 8500, Engine.Race.MechaThunder, Engine.Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(new OneShotEffects.YouMayUntapThisCreatureEffect()));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
