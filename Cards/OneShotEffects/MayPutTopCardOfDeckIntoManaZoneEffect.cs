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

        public override void Apply(IGame game, IAbility source)
        {
            if (GetController(game).ChooseToTakeAction(ToString()))
            {
                GetController(game).PutFromTopOfDeckIntoManaZone(game, 1, source);
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
