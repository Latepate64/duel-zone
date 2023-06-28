using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM10
{
    class UltimateDragon : Creature
    {
        public UltimateDragon() : base("Ultimate Dragon", 6, 5000, Race.ArmoredDragon, Civilization.Fire)
        {
            AddStaticAbilities(new UltimateDragonPowerEffect(), new UltimateDragonBreakerEffect());
        }
    }

    class UltimateDragonPowerEffect : PowerModifyingMultiplierEffect
    {
        public UltimateDragonPowerEffect(int power = 5000) : base(power)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new UltimateDragonPowerEffect();
        }

        public override string ToString()
        {
            return $"This creature gets +{Power} power for each of your other creatures in the battle zone that has Dragon in its race.";
        }

        protected override int GetMultiplier()
        {
            return Game.BattleZone.GetOtherCreatures(Applier, Source).Count(x => x.IsDragon);
        }
    }

    class UltimateDragonBreakerEffect : CrewBreakerEffect
    {
        public override IContinuousEffect Copy()
        {
            return new UltimateDragonBreakerEffect();
        }

        public override int GetAmount(ICard creature)
        {
            return IsSourceOfAbility(creature) ? Game.BattleZone.GetCreatures(Applier).Count(x => !IsSourceOfAbility(x) && x.IsDragon) : 1;
        }

        public override string ToString()
        {
            return "Crew breaker - Dragon";
        }
    }
}
