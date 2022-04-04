using Common;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class PlayersCannotUseShieldTriggerAbilitiesOfCivilizationCardsEffect : ContinuousEffect, ICannotUseShieldTriggerEffect
    {
        private readonly Civilization _civilization;

        public PlayersCannotUseShieldTriggerAbilitiesOfCivilizationCardsEffect(Civilization civilization) : base(new CardFilters.CivilizationFilter(civilization), new Durations.Indefinite())
        {
            _civilization = civilization;
        }

        public PlayersCannotUseShieldTriggerAbilitiesOfCivilizationCardsEffect(PlayersCannotUseShieldTriggerAbilitiesOfCivilizationCardsEffect effect) : base(effect)
        {
            _civilization = effect._civilization;
        }

        public override IContinuousEffect Copy()
        {
            return new PlayersCannotUseShieldTriggerAbilitiesOfCivilizationCardsEffect(this);
        }

        public override string ToString()
        {
            return $"Player's can't use the \"shield trigger\" abilities of {_civilization} cards.";
        }
    }
}