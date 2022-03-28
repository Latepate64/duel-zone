using Cards.ContinuousEffects;

namespace Cards.Cards.DM04
{
    class CannonShell : Creature
    {
        public CannonShell() : base("Cannon Shell", 4, 1000, Common.Subtype.ColonyBeetle, Common.Civilization.Nature)
        {
            ShieldTrigger = true;
            AddStaticAbilities(new ThisCreatureGetsPowerForEachShieldYouHaveEffect(1000));
        }
    }
}
