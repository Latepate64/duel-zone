using Engine;

namespace Cards.Cards.DM01;

class IocantTheOracle : Creature
{
    public IocantTheOracle() : base("Iocant, the Oracle", 2, 2000, Race.LightBringer, Civilization.Light)
    {
        AddBlockerAbility();
        AddStaticAbilities(new IocantTheOracleEffect(Race.AngelCommand, 2000));
        AddThisCreatureCannotAttackPlayersAbility();
    }
}
