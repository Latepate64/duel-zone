using Engine.ContinuousEffects;
using System.Linq;

namespace Engine.GameEvents
{
    public class BattleEvent : GameEvent
    {
        private readonly ICard _attackingCreature;
        private readonly ICard _defendingCreature;

        public override void Happen(IGame game)
        {
            // Battle event must be processed relative to both creatures.
            //Process(new BattleEvent { Card = attackingCreature.Convert(), OtherCard = defendingCreature.Convert() });
            //Process(new BattleEvent { Card = defendingCreature.Convert(), OtherCard = attackingCreature.Convert() });

            if (_attackingCreature.Power.Value > _defendingCreature.Power.Value)
            {
                Outcome(_attackingCreature, _defendingCreature);
            }
            else if (_attackingCreature.Power.Value < _defendingCreature.Power.Value)
            {
                Outcome(_defendingCreature, _attackingCreature);
            }
            else
            {
                CheckLoseInBattle(_attackingCreature, _defendingCreature, game);
                CheckLoseInBattle(_defendingCreature, _attackingCreature, game);
            }

            //Process(new AfterBattleEvent());

            void Outcome(ICard winner, ICard loser)
            {
                //Process(new WinBattleEvent { Card = winner.Convert() });
                CheckLoseInBattle(loser, winner, game);
                if (game.GetContinuousEffects<ISlayerEffect>().Any(x => x.Applies(loser, winner, game)))
                {
                    winner.LostInBattle = true; // TODO: Not sure if proper way to do
                }
            }
        }

        public override string ToString()
        {
            return $"{_attackingCreature} battled {_defendingCreature}.";
        }

        private void CheckLoseInBattle(ICard target, ICard against, IGame game)
        {
            if (!game.GetContinuousEffects<INotDestroyedInBattleEffect>().Any(x => x.Applies(against, target, game)))
            {
                target.LostInBattle = true;
            }
        }
    }
}
