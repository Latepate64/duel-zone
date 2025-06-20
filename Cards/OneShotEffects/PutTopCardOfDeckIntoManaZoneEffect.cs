using Engine.Abilities;

namespace Cards.OneShotEffects;

public class PutTopCardOfDeckIntoManaZoneEffect : PutTopCardsOfDeckIntoManaZoneEffect
{
    public PutTopCardOfDeckIntoManaZoneEffect() : base(1)
    {
    }

    public PutTopCardOfDeckIntoManaZoneEffect(PutTopCardsOfDeckIntoManaZoneEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new PutTopCardOfDeckIntoManaZoneEffect(this);
    }
}
