using DuelMastersCards.ContinuousEffects;
using DuelMastersCards.StaticAbilities;
using DuelMastersModels;
using DuelMastersModels.Abilities;

namespace DuelMastersCards.Cards
{
    class IocantTheOracle : Creature
    {
        public IocantTheOracle() : base("Iocant, the Oracle", 2, Civilization.Light, 2000, Subtype.LightBringer)
        {
            Abilities.Add(new BlockerAbility());

            // While you have at least 1 Angel Command in the battle zone, this creature gets +2000 power.
            Abilities.Add(new StaticAbility(new IocantTheOracleEffect()));

            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
