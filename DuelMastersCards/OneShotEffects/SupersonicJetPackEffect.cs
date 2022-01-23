using DuelMastersCards.CardFilters;
using DuelMastersCards.StaticAbilities;
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

        public SupersonicJetPackEffect(OneShotEffect effect)
        {
        }

        public override OneShotEffect Copy()
        {
            return new SupersonicJetPackEffect(this);
        }

        public override void Apply(Game game, Ability source)
        {
            // One of your creatures in the battle zone gets "speed attacker" until the end of the turn.
            var player = game.GetPlayer(source.Owner);
            var creatures = game.BattleZone.GetCreatures(source.Owner);
            if (creatures.Any())
            {
                var decision = player.Choose(new GuidSelection(source.Owner, creatures, 1, 1));
                var target = game.GetCard(decision.Decision.Single()).Id;
                game.ContinuousEffects.Add(new AbilityGrantingEffect(new TargetFilter { Target = target }, new Indefinite(), new SpeedAttackerAbility()));
            }
        }
    }
}
