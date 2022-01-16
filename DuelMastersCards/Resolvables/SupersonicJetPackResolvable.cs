using DuelMastersCards.CardFilters;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.Choices;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;
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

        public override void Resolve(Duel duel, Decision decision)
        {
            // One of your creatures in the battle zone gets "speed attacker" until the end of the turn.
            if (decision == null)
            {
                OneOfYourCreaturesGetsSpeedAttacker(duel);
            }
            else
            {
                var target = duel.GetPermanent((decision as GuidDecision).Decision.Single()).Id;
                //TODO: SpeedAttackerEffect should not be directly added to continuous effects but rather a kind of continuous effect that grants Speed Attacker ability to the target creature.
                duel.ContinuousEffects.Add(new SpeedAttackerEffect(new TargetFilter { Owner = Controller, Target = target }, new Indefinite()));
            }
        }

        private void OneOfYourCreaturesGetsSpeedAttacker(Duel duel)
        {
            var creatures = duel.GetPlayer(Controller).BattleZone.Creatures;
            if (creatures.Count() > 1)
            {
                duel.SetAwaitingChoice(new GuidSelection(Controller, creatures, 1, 1));
            }
            else if (creatures.Any())
            {
                //TODO: SpeedAttackerEffect should not be directly added to continuous effects but rather a kind of continuous effect that grants Speed Attacker ability to the target creature.
                duel.ContinuousEffects.Add(new SpeedAttackerEffect(new TargetFilter { Owner = Controller, Target = creatures.Single().Id }, new Indefinite()));
            }
        }
    }
}
