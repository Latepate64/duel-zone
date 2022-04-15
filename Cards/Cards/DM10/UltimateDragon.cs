using Cards.ContinuousEffects;
using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM10
{
    class UltimateDragon : Creature
    {
        public UltimateDragon() : base("Ultimate Dragon", 6, 5000, Engine.Subtype.ArmoredDragon, Civilization.Fire)
        {
            AddStaticAbilities(new UltimateDragonPowerEffect(), new UltimateDragonBreakerEffect());
        }
    }

    class UltimateDragonPowerEffect : PowerModifyingMultiplierEffect
    {
        public UltimateDragonPowerEffect() : base(5000)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new UltimateDragonPowerEffect();
        }

        public override string ToString()
        {
            return "This creature gets +5000 power for each of your other creatures in the battle zone that has Dragon in its race.";
        }

        protected override int GetMultiplier(IGame game)
        {
            return game.BattleZone.GetOtherCreatures(GetController(game).Id, GetSourceCard(game).Id).Count(x => x.IsDragon);
        }
    }

    class UltimateDragonBreakerEffect : CrewBreakerEffect
    {
        public override IContinuousEffect Copy()
        {
            return new UltimateDragonBreakerEffect();
        }

        public override int GetAmount(IGame game, Engine.ICard creature)
        {
            var ability = GetSourceAbility(game);
            return IsSourceOfAbility(creature, game) ? game.BattleZone.GetCreatures(ability.Controller).Count(x => x.Id != ability.Source && x.IsDragon) : 1;
        }

        public override string ToString()
        {
            return "Crew breaker - Dragon";
        }
    }
}
