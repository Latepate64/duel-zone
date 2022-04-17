using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM02
{
    class ArmoredCannonBalbaro : EvolutionCreature
    {
        public ArmoredCannonBalbaro() : base("Armored Cannon Balbaro", 3, 3000, Race.Human, Civilization.Fire)
        {
            AddStaticAbilities(new ArmoredCannonBalbaroEffect());
        }
    }

    class ArmoredCannonBalbaroEffect : ContinuousEffects.PowerAttackerMultiplierEffect
    {
        public ArmoredCannonBalbaroEffect() : base(2000)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new ArmoredCannonBalbaroEffect();
        }

        public override string ToString()
        {
            return "While attacking, this creature gets +2000 power for each other Human in the battle zone.";
        }

        protected override int GetMultiplier(IGame game)
        {
            return game.BattleZone.GetOtherCreatures(GetSourceCard(game).Id, Race.Human).Count();
        }
    }
}
