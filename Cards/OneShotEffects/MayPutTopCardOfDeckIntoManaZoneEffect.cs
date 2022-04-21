using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class MayPutTopCardOfDeckIntoManaZoneEffect : OneShotEffect
    {
        public MayPutTopCardOfDeckIntoManaZoneEffect()
        {
        }

        public MayPutTopCardOfDeckIntoManaZoneEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            if (Controller.ChooseToTakeAction(ToString()))
            {
                Controller.PutFromTopOfDeckIntoManaZone(game, 1, Source);
            }
        }

        public override IOneShotEffect Copy()
        {
            return new MayPutTopCardOfDeckIntoManaZoneEffect(this);
        }

        public override string ToString()
        {
            return "You may put the top card of your deck into your mana zone.";
        }
    }
}
