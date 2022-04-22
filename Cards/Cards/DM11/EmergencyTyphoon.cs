using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM11
{
    class EmergencyTyphoon : Spell
    {
        public EmergencyTyphoon() : base("Emergency Typhoon", 2, Engine.Civilization.Water)
        {
            AddShieldTrigger();
            AddSpellAbilities(new EmergencyTyphoonEffect());
        }
    }

    class EmergencyTyphoonEffect : OneShotEffect
    {

        public EmergencyTyphoonEffect(EmergencyTyphoonEffect effect) : base(effect)
        {
        }

        public EmergencyTyphoonEffect()
        {
        }

        public override void Apply(IGame game)
        {
            Controller.DrawCardsOptionally(game, Ability, 2);
            Controller.DiscardOwnCards(game, Ability, 1);
        }

        public override IOneShotEffect Copy()
        {
            return new EmergencyTyphoonEffect(this);
        }

        public override string ToString()
        {
            return "Draw up to 2 cards. Then discard a card from your hand.";
        }
    }
}
