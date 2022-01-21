using DuelMastersCards.CardFilters;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;
using System.Linq;

namespace DuelMastersCards.OneShotEffects
{
    class SupersonicJetPackEffect : OneShotEffect
    {
        public SupersonicJetPackEffect()
        {
        }

        public SupersonicJetPackEffect(OneShotEffect effect) : base(effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new SupersonicJetPackEffect(this);
        }

        public override void Apply(Game game)
        {
            // One of your creatures in the battle zone gets "speed attacker" until the end of the turn.
            var player = game.GetPlayer(Controller);
            var creatures = game.BattleZone.GetCreatures(Controller);
            if (creatures.Any())
            {
                var decision = player.Choose(new GuidSelection(Controller, creatures, 1, 1));
                var target = game.GetCard(decision.Decision.Single()).Id;
                //TODO: SpeedAttackerEffect should not be directly added to continuous effects but rather a kind of continuous effect that grants Speed Attacker ability to the target creature.
                game.ContinuousEffects.Add(new SpeedAttackerEffect(new TargetFilter { Owner = Controller, Target = target }, new Indefinite()));
            }
        }
    }
}
