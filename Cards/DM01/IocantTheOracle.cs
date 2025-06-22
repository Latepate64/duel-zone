using ContinuousEffects;
using Engine;
using Interfaces;

namespace Cards.DM01;

public sealed class IocantTheOracle : Creature
{
    public IocantTheOracle() : base("Iocant, the Oracle", 2, 2000, Race.LightBringer, Civilization.Light)
    {
        AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        AddStaticAbilities(new IocantTheOracleEffect());
        AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
    }
}
