using Cards.TriggeredAbilities;
using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM02
{
    class SpiralGrass : Creature
    {
        public SpiralGrass() : base("Spiral Grass", 4, 2500, Subtype.StarlightTree, Civilization.Light)
        {
            AddAbilities(new StaticAbilities.BlockerAbility(), new BlockAbility(new SpiralGrassEffect()));
        }
    }

    class SpiralGrassEffect : OneShotEffect
    {
        public SpiralGrassEffect()
        {
        }

        public override void Apply(Game game, Ability source)
        {
            game.AddDelayedTriggeredAbility(new AfterBattleAbility(new OneShotEffects.UntapAreaOfEffect(new TargetFilter())), new Engine.Durations.Once());
        }

        public override OneShotEffect Copy()
        {
            return new SpiralGrassEffect();
        }

        public override string ToString()
        {
            return "Untap it after it battles.";
        }
    }
}
