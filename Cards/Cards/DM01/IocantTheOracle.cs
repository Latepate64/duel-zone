using Cards.ContinuousEffects;
using ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM01
{
    class IocantTheOracle : Creature
    {
        public IocantTheOracle() : base("Iocant, the Oracle", 2, 2000, Race.LightBringer, Civilization.Light)
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
            AddStaticAbilities(new IocantTheOracleEffect());
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }
    }

    class IocantTheOracleEffect : ContinuousEffect, IPowerModifyingEffect
    {
        public IocantTheOracleEffect() : base()
        {
        }

        public override IContinuousEffect Copy()
        {
            return new IocantTheOracleEffect();
        }

        public void ModifyPower(IGame game)
        {
            if (game.BattleZone.GetCreatureCount(Controller.Id, Race.AngelCommand) > 0)
            {
                (Source as Creature).IncreasePower(2000);
            }
        }

        public override string ToString()
        {
            return "While you have at least 1 Angel Command in the battle zone, this creature gets +2000 power.";
        }
    }
}
