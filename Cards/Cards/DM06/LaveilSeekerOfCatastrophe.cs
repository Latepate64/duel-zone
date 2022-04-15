using Common;

namespace Cards.Cards.DM06
{
    class LaveilSeekerOfCatastrophe : Creature
    {
        public LaveilSeekerOfCatastrophe() : base("Laveil, Seeker of Catastrophe", 8, 8500, Engine.Subtype.MechaThunder, Civilization.Light)
        {
            AddBlockerAbility();
            AddAtTheEndOfYourTurnAbility(new OneShotEffects.YouMayUntapThisCreatureEffect());
            AddDoubleBreakerAbility();
        }
    }
}
