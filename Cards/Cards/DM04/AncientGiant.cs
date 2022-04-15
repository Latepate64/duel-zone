using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM04
{
    class AncientGiant : Creature
    {
        public AncientGiant() : base("Ancient Giant", 8, 9000, Engine.Subtype.Giant, Civilization.Nature)
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedByCivilizationCreaturesEffect(Civilization.Darkness));
            AddDoubleBreakerAbility();
        }
    }
}
