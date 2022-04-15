using Cards.ContinuousEffects;

namespace Cards.Cards.DM04
{
    class AncientGiant : Creature
    {
        public AncientGiant() : base("Ancient Giant", 8, 9000, Engine.Subtype.Giant, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect(Engine.Civilization.Darkness));
            AddDoubleBreakerAbility();
        }
    }
}
