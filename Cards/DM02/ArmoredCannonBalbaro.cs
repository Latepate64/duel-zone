using Engine;
using Engine.ContinuousEffects;
using Interfaces;

namespace Cards.DM02
{
    class ArmoredCannonBalbaro : EvolutionCreature
    {
        public ArmoredCannonBalbaro() : base("Armored Cannon Balbaro", 3, 3000, Race.Human, Civilization.Fire)
        {
            AddStaticAbilities(new ArmoredCannonBalbaroEffect());
        }
    }

    class ArmoredCannonBalbaroEffect(int power = 2000) : ContinuousEffects.PowerAttackerMultiplierEffect(power)
    {
        public override IContinuousEffect Copy()
        {
            return new ArmoredCannonBalbaroEffect();
        }

        public override string ToString()
        {
            return $"While attacking, this creature gets +{Power} power for each other Human in the battle zone.";
        }

        protected override int GetMultiplier(IGame game)
        {
            return game.BattleZone.GetOtherCreatureCount(Source.Id, Race.Human);
        }
    }
}
