using ContinuousEffects;
using Interfaces;
using Interfaces.ContinuousEffects;

namespace Cards.DM03;

public class GigamantisEffect : WhenCreatureWouldBeDestroyedPutItIntoYourManaZoneInsteadEffect
{
    public GigamantisEffect() : base()
    {
    }

    public override IContinuousEffect Copy()
    {
        return new GigamantisEffect();
    }

    public override string ToString()
    {
        return "Whenever another of your nature creatures would be put into your graveyard from the battle zone, put it into your mana zone instead.";
    }

    protected override bool Applies(ICreature card, IGame game)
    {
        return !IsSourceOfAbility(card) && card.Owner == Controller && card.HasCivilization(Civilization.Nature);
    }
}
