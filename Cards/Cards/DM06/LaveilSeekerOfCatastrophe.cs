using Common;

namespace Cards.Cards.DM06
{
    class LaveilSeekerOfCatastrophe : Creature
    {
        public LaveilSeekerOfCatastrophe() : base("Laveil, Seeker of Catastrophe", 8, 8500, Subtype.MechaThunder, Civilization.Light)
        {
            AddAbilities(new StaticAbilities.BlockerAbility(), new TriggeredAbilities.AtTheEndOfYourTurnAbility(new OneShotEffects.YouMayUntapThisCreatureEffect()), new StaticAbilities.DoubleBreakerAbility());
        }
    }
}
