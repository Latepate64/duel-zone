using DuelMastersCards.CardFilters;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;
using System;
using System.Linq;

namespace DuelMastersCards.Resolvables
{
    class SupersonicJetPackResolvable : Resolvable
    {
        public SupersonicJetPackResolvable()
        {
        }

        public SupersonicJetPackResolvable(Resolvable resolvable) : base(resolvable)
        {
        }

        public override Resolvable Copy()
        {
            return new SupersonicJetPackResolvable(this);
        }

        public override Choice Resolve(Duel duel, Decision decision)
        {
            // One of your creatures in the battle zone gets "speed attacker" until the end of the turn.
            var controller = duel.GetPlayer(Controller);
            if (decision != null)
            {
                if (controller.BattleZone.Permanents.Count > 1)
                {
                    return new GuidSelection(Controller, controller.BattleZone.Permanents, 1, 1);
                }
                else if (controller.BattleZone.Permanents.Any())
                {
                    duel.ContinuousEffects.Add(new SpeedAttackerEffect(new TargetFilter { Owner = Controller, Target = controller.BattleZone.Permanents.Single().Id }, new Indefinite()));
                    return null;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                var target = duel.GetPermanent((decision as GuidDecision).Decision.Single()).Id;
                duel.ContinuousEffects.Add(new SpeedAttackerEffect(new TargetFilter { Owner = Controller, Target = target }, new Indefinite()));
                return null;
            }
        }
    }
}
