using Engine.Abilities;

namespace Cards.OneShotEffects;

public class PutTopTwoCardOfDeckIntoManaZoneEffect : PutTopCardsOfDeckIntoManaZoneEffect
{
    public PutTopTwoCardOfDeckIntoManaZoneEffect() : base(2)
    {
    }

    public PutTopTwoCardOfDeckIntoManaZoneEffect(PutTopTwoCardOfDeckIntoManaZoneEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new PutTopTwoCardOfDeckIntoManaZoneEffect(this);
    }
}
