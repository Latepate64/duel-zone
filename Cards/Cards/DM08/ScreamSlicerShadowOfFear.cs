using Common;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM08
{
    class ScreamSlicerShadowOfFear : Creature
    {
        public ScreamSlicerShadowOfFear() : base("Scream Slicer, Shadow of Fear", 6, 4000, Subtype.Ghost, Civilization.Darkness)
        {
            AddTriggeredAbility(new TriggeredAbilities.WheneverYouPutDragonoidOrDragonIntoTheBattleZoneAbility(new ScreamSlicerShadowOfFearEffect()));
        }
    }

    class ScreamSlicerShadowOfFearEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var creatures = game.BattleZone.Creatures.Where(x => x.Power == game.BattleZone.Creatures.Min(x => x.Power.Value));
            return new ScreamSlicerShadowOfFearDestroyEffect(creatures.ToArray()).Apply(game, source);
        }

        public override IOneShotEffect Copy()
        {
            return new ScreamSlicerShadowOfFearEffect();
        }

        public override string ToString()
        {
            return "Destroy the creature that has the least power in the battle zone. If there's a tie, you choose from among the tied creatures.";
        }
    }

    class ScreamSlicerShadowOfFearDestroyEffect : OneShotEffects.DestroyEffect
    {
        public ScreamSlicerShadowOfFearDestroyEffect(params Engine.ICard[] cards) : base(new CardFilters.TargetsFilter(cards), 1, 1, true) 
        {
        }

        public override IOneShotEffect Copy()
        {
            return new ScreamSlicerShadowOfFearDestroyEffect();
        }

        public override string ToString()
        {
            return "Destroy a creature.";
        }
    }
}
