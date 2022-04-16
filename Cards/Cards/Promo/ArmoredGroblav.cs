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
        public ArmoredGroblavEffect() : base(1000)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ArmoredGroblavEffect();
        }

        public override string ToString()
        {
            return "While attacking, this creature gets +1000 power for each other fire creature in the battle zone.";
        }

        protected override int GetMultiplier(IGame game)
        {
            return game.BattleZone.GetOtherCreatures(GetSourceCard(game).Id, Civilization.Fire).Count();
        }
    }
}
