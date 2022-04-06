using Common;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class WhileYouControlSubtypeThisCreatureGetsPowerDuringItsAttacksEffect : ContinuousEffect, IPowerModifyingEffect
    {
        private readonly Subtype _subtype;
        private readonly int _power;

        public WhileYouControlSubtypeThisCreatureGetsPowerDuringItsAttacksEffect(Subtype subtype, int power) : base(new TargetFilter())
        {
            _subtype = subtype;
            _power = power;
        }

        public WhileYouControlSubtypeThisCreatureGetsPowerDuringItsAttacksEffect(WhileYouControlSubtypeThisCreatureGetsPowerDuringItsAttacksEffect effect) : base(effect)
        {
            _subtype = effect._subtype;
            _power = effect._power;
        }

        public override string ToString()
        {
            return $"While you have at least one {_subtype} in the battle zone, this creature gets +{_power} power during its attacks.";
        }

        public override ContinuousEffect Copy()
        {
            return new WhileYouControlSubtypeThisCreatureGetsPowerDuringItsAttacksEffect(this);
        }

        public void ModifyPower(IGame game)
        {
            if (game.CurrentTurn.CurrentPhase is Engine.Steps.AttackPhase phase && game.BattleZone.GetCreatures(GetSourceAbility(game).Id).Any(x => x.HasSubtype(_subtype)))
            {
                GetAffectedCards(game).Where(x => x.Id == phase.AttackingCreature).ToList().ForEach(x => x.Power += _power);
            }
        }
    }
}