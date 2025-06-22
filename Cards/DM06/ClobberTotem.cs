using ContinuousEffects;

namespace Cards.DM06
{
    sealed class ClobberTotem : Engine.Creature
    {
        public ClobberTotem() : base("Clobber Totem", 6, 4000, Interfaces.Race.MysteryTotem, Interfaces.Civilization.Nature)
        {
            AddStaticAbilities(new PowerAttackerEffect(2000));
            AddStaticAbilities(new ThisCreatureCannotBeBlockedByAnyCreatureThatHasMaxPowerEffect(5000));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
