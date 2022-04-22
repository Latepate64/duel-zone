using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using Engine.GameEvents;
using System;

namespace Cards.Cards.DM07
{
    class ScalpelSpider : Creature
    {
        public ScalpelSpider() : base("Scalpel Spider", 3, 2000, Race.BrainJacker, Civilization.Darkness)
        {
            AddTriggeredAbility(new ScalpelSpiderAbility());
        }
    }

    class ScalpelSpiderAbility : LinkedTriggeredAbility
    {
        public ScalpelSpiderAbility() : base()
        {
        }

        public ScalpelSpiderAbility(ScalpelSpiderAbility ability) : base(ability)
        {
        }

        public override bool CanTrigger(IGameEvent gameEvent, IGame game)
        {
            return gameEvent is CreatureAttackedEvent e && e.Target == game.GetCard(Source);
        }

        public override IAbility Copy()
        {
            return new ScalpelSpiderAbility(this);
        }

        public override string ToString()
        {
            return "Whenever this creature is attacked, it gets \"slayer\" until the end of the turn.";
        }

        public override void Resolve(IGame game)
        {
            game.AddContinuousEffects(this, new CreatureGetsSlayerUntilEndOfTheTurnEffect(game.GetCard(Source)));
        }

        public override ITriggeredAbility Trigger(Guid source, Guid owner, IGameEvent gameEvent)
        {
            return new ScalpelSpiderAbility(this);
        }
    }
}
