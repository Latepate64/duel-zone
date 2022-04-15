using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM06
{
    class ClobberTotem : Creature
    {
        public ClobberTotem() : base("Clobber Totem", 6, 4000, Engine.Subtype.MysteryTotem, Civilization.Nature)
        {
            AddPowerAttackerAbility(2000);
            AddStaticAbilities(new ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect(5000));
            AddDoubleBreakerAbility();
        }
    }
}
