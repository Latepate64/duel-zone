using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    class WhileYouControlRaceThisCreatureGetsPowerDuringItsAttacksEffect : ContinuousEffect, IPowerModifyingEffect, IPowerable, IRaceable
    {
        public int Power { get; }
        public Race Race { get; }

        public WhileYouControlRaceThisCreatureGetsPowerDuringItsAttacksEffect(int power, Race race) : base()
        {
            Race = race;
            Power = power;
        }

        public WhileYouControlRaceThisCreatureGetsPowerDuringItsAttacksEffect(WhileYouControlRaceThisCreatureGetsPowerDuringItsAttacksEffect effect) : base(effect)
        {
            Race = effect.Race;
            Power = effect.Power;
        }

        public override string ToString()
        {
            return $"While you have at least one {Race} in the battle zone, this creature gets +{Power} power during its attacks.";
        }

        public override ContinuousEffect Copy()
        {
            return new WhileYouControlRaceThisCreatureGetsPowerDuringItsAttacksEffect(this);
        }

        public void ModifyPower(IGame game)
        {
            if (game.CurrentTurn.CurrentPhase is Engine.Steps.AttackPhase phase && game.BattleZone.GetCreatures(Applier).Any(x => x.HasRace(Race)))
            {
                Source.Power += Power;
            }
        }
    }
}