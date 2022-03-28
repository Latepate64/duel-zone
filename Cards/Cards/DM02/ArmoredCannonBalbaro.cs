using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM02
{
    class ArmoredCannonBalbaro : EvolutionCreature
    {
        public ArmoredCannonBalbaro() : base("Armored Cannon Balbaro", 3, 3000, Subtype.Human, Civilization.Fire)
        {
            AddStaticAbilities(new ArmoredCannonBalbaroEffect());
        }
    }

    class ArmoredCannonBalbaroEffect : ContinuousEffects.PowerAttackerMultiplierEffect
    {
        public ArmoredCannonBalbaroEffect() : base(2000, new CardFilters.BattleZoneSubtypeCreatureFilter(Subtype.Human))
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
    }
}
