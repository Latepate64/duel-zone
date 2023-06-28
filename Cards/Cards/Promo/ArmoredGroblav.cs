using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.Promo
{
    class ArmoredGroblav : EvolutionCreature
    {
        public ArmoredGroblav() : base("Armored Groblav", 5, 6000, Race.Human, Civilization.Fire)
        {
            AddStaticAbilities(new ArmoredGroblavEffect());
            AddDoubleBreakerAbility();
        }
    }

    class ArmoredGroblavEffect : ContinuousEffects.PowerAttackerMultiplierEffect
    {
        public ArmoredGroblavEffect(int power = 1000) : base(power)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ArmoredGroblavEffect();
        }

        public override string ToString()
        {
            return $"While attacking, this creature gets +{Power} power for each other fire creature in the battle zone.";
        }

        protected override int GetMultiplier()
        {
            return Game.BattleZone.GetOtherCreatures(Source, Civilization.Fire).Count();
        }
    }
}
