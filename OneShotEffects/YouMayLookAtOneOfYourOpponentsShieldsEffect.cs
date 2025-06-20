using Engine;
using Engine.Abilities;

namespace OneShotEffects;

public class YouMayLookAtOneOfYourOpponentsShieldsEffect : LookEffect
{
    public YouMayLookAtOneOfYourOpponentsShieldsEffect() : base(0, 1)
    {
    }

    public YouMayLookAtOneOfYourOpponentsShieldsEffect(LookEffect effect) : base(effect)
    {
    }

    public override IOneShotEffect Copy()
    {
        return new YouMayLookAtOneOfYourOpponentsShieldsEffect(this);
    }

    public override string ToString()
    {
        return "You may look at one of your opponent's shields. Then put it back where it was.";
    }

    protected override IEnumerable<Card> GetSelectableCards(IGame game, IAbility source)
    {
        return GetOpponent(game).ShieldZone.Cards;
    }
}
