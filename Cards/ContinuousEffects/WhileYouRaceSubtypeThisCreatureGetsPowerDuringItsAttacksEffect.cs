using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class WhileYouControlRaceThisCreatureGetsPowerDuringItsAttacksEffect : ContinuousEffect, IPowerModifyingEffect
    {
        private readonly Race _race;
        private readonly int _power;

        public WhileYouControlRaceThisCreatureGetsPowerDuringItsAttacksEffect(Race race, int power) : base()
        {
            _race = race;
            _power = power;
        }

        public WhileYouControlRaceThisCreatureGetsPowerDuringItsAttacksEffect(WhileYouControlRaceThisCreatureGetsPowerDuringItsAttacksEffect effect) : base(effect)
        {
            _race = effect._race;
            _power = effect._power;
        }

        public override string ToString()
        {
            return $"While you have at least one {_race} in the battle zone, this creature gets +{_power} power during its attacks.";
        }

        public override ContinuousEffect Copy()
        {
            return new WhileYouControlRaceThisCreatureGetsPowerDuringItsAttacksEffect(this);
        }

        public void ModifyPower(IGame game)
        {
            if (game.CurrentTurn.CurrentPhase is Engine.Steps.AttackPhase phase && game.BattleZone.GetCreatures(GetSourceAbility(game).Id).Any(x => x.HasRace(_race)))
            {
                GetSourceCard(game).Power += _power;
            }
        }
    }
}