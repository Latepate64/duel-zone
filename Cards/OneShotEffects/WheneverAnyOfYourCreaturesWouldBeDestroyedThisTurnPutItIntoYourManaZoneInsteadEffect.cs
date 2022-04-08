using Cards.ContinuousEffects;
using Common.GameEvents;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.OneShotEffects
{
    class WheneverAnyOfYourCreaturesWouldBeDestroyedThisTurnPutItIntoYourManaZoneInsteadEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            game.AddContinuousEffects(source, new WheneverAnyOfYourCreaturesWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect());
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new WheneverAnyOfYourCreaturesWouldBeDestroyedThisTurnPutItIntoYourManaZoneInsteadEffect();
        }

        public override string ToString()
        {
            return "Whenever any of your creatures would be destroyed this turn, put it into your mana zone instead.";
        }
    }


    class WheneverAnyOfYourCreaturesWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect : DestructionReplacementEffect, IDuration
    {
        public WheneverAnyOfYourCreaturesWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect() : base(new CardFilters.OwnersBattleZoneCreatureFilter())
        {
        }

        public override bool Apply(IGame game, IPlayer player)
        {
            //game.Move(Common.ZoneType.BattleZone, Common.ZoneType.ManaZone, GetAffectedCards(game).ToArray());
            return true;
        }

        public override IContinuousEffect Copy()
        {
            return new WheneverAnyOfYourCreaturesWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect();
        }

        public bool ShouldExpire(IGameEvent gameEvent)
        {
            return gameEvent is PhaseBegunEvent phase && phase.PhaseOrStep == PhaseOrStep.EndOfTurn;
        }

        public override string ToString()
        {
            return "Whenever any of your creatures would be destroyed, put it into your mana zone instead.";
        }
    }
}