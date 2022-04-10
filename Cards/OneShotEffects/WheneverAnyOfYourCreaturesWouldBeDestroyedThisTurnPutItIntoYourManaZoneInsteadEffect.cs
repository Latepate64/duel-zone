using Cards.ContinuousEffects;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.GameEvents;

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
        public WheneverAnyOfYourCreaturesWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect() : base()
        {
        }

        public override bool Apply(IGame game, IPlayer player, Engine.ICard card)
        {
            game.Move(Common.ZoneType.BattleZone, Common.ZoneType.ManaZone, card);
            return true;
        }

        public override IContinuousEffect Copy()
        {
            return new WheneverAnyOfYourCreaturesWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect();
        }

        public bool ShouldExpire(IGameEvent gameEvent)
        {
            throw new System.NotImplementedException();
            //return gameEvent is PhaseBegunEvent phase && phase.PhaseOrStep == PhaseOrStep.EndOfTurn;
        }

        public override string ToString()
        {
            return "Whenever any of your creatures would be destroyed, put it into your mana zone instead.";
        }

        protected override bool Applies(ICard card, IGame game)
        {
            return card.Owner == Controller;
        }
    }
}