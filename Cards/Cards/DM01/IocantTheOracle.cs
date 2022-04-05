using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM01
{
    class IocantTheOracle : Creature
    {
        public IocantTheOracle() : base("Iocant, the Oracle", 2, 2000, Common.Subtype.LightBringer, Common.Civilization.Light)
        {
            AddBlockerAbility();
            AddStaticAbilities(new IocantTheOracleEffect());
            AddThisCreatureCannotAttackPlayersAbility();
        }
    }

    class IocantTheOracleEffect : ContinuousEffect, IPowerModifyingEffect
    {
        public IocantTheOracleEffect() : base(new TargetFilter())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new IocantTheOracleEffect();
        }

        public void ModifyPower(IGame game)
        {
            if (game.BattleZone.GetCreatures(game.GetAbility(SourceAbility).Controller).Any(x => x.HasSubtype(Subtype.AngelCommand)))
            {
                GetAffectedCards(game).ToList().ForEach(x => x.Power += 2000);
            }
        }

        public override string ToString()
        {
            return "While you have at least 1 Angel Command in the battle zone, this creature gets +2000 power.";
        }
    }
}
