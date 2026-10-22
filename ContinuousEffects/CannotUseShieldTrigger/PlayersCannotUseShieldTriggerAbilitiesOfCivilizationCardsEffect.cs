using Interfaces;
using Interfaces.ContinuousEffects;

namespace ContinuousEffects.CannotUseShieldTrigger;

public sealed class PlayersCannotUseShieldTriggerAbilitiesOfCivilizationCardsEffect
    : ContinuousEffect, ICannotUseShieldTriggerEffect, ICivilizationable
{
    public PlayersCannotUseShieldTriggerAbilitiesOfCivilizationCardsEffect(
        Civilization civilization) : base()
    {
        Civilization = civilization;
    }

    private PlayersCannotUseShieldTriggerAbilitiesOfCivilizationCardsEffect(
        PlayersCannotUseShieldTriggerAbilitiesOfCivilizationCardsEffect effect) : base(effect)
    {
        Civilization = effect.Civilization;
    }

    public Civilization Civilization { get; }

    public bool CannotUseShieldTrigger(ICard card, IGame game)
    {
        return card.HasCivilization(Civilization);
    }

    public override IContinuousEffect Copy()
    {
        return new PlayersCannotUseShieldTriggerAbilitiesOfCivilizationCardsEffect(this);
    }
}