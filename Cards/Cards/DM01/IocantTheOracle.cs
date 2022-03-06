using Cards.ContinuousEffects;
using Cards.StaticAbilities;
using Engine.Abilities;

namespace Cards.Cards.DM01
{
    class IocantTheOracle : Creature
    {
        public IocantTheOracle() : base("Iocant, the Oracle", 2, 2000, Common.Subtype.LightBringer, Common.Civilization.Light)
        {
            Abilities.Add(new BlockerAbility());

            // While you have at least 1 Angel Command in the battle zone, this creature gets +2000 power.
            Abilities.Add(new StaticAbility(new IocantTheOracleEffect()));

            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
