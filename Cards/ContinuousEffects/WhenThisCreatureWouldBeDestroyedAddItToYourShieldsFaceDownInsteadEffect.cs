using Engine;
using Engine.GameEvents;

namespace Cards.ContinuousEffects
{
    class WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect : DestructionReplacementEffect
    {
        public WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect() : base()
        {
        }

        public WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect(WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect effect) : base(effect)
        {
        }

        public override bool Apply(IGame game, IPlayer player, Engine.ICard card)
        {
            game.Move(Common.ZoneType.BattleZone, Common.ZoneType.ShieldZone, card);
            return true;
        }

        public override IGameEvent Apply(IGameEvent gameEvent, IGame game)
        {
            throw new System.NotImplementedException();
        }

        public override ContinuousEffect Copy()
        {
            return new WhenThisCreatureWouldBeDestroyedAddItToYourShieldsFaceDownInsteadEffect(this);
        }

        public override string ToString()
        {
            return "When this creature would be destroyed, add it to your shields face down instead.";
        }

        protected override bool Applies(ICard card, IGame game)
        {
            return IsSourceOfAbility(card, game);
        }
    }
}