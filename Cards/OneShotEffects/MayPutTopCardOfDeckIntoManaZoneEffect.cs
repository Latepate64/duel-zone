using Engine;
using Engine.Abilities;

namespace Cards.OneShotEffects
{
    class MayPutTopCardOfDeckIntoManaZoneEffect : OneShotEffect
    {
        public override void Apply(IGame game, IAbility source)
        {
            if (source.GetController(game).ChooseToTakeAction(ToString()))
            {
                source.GetController(game).PutFromTopOfDeckIntoManaZone(game, 1, source);
            }
        }

        public override IOneShotEffect Copy()
        {
            return new MayPutTopCardOfDeckIntoManaZoneEffect();
        }

        public override string ToString()
        {
            return "You may put the top card of your deck into your mana zone.";
        }
    }
}
