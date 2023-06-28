using Engine;
using Engine.ContinuousEffects;

namespace Cards.ContinuousEffects
{
    class PlayersCannotUseShieldTriggerAbilitiesOfCivilizationCardsEffect : ContinuousEffect, ICannotUseShieldTriggerEffect, ICivilizationable
    {
        public PlayersCannotUseShieldTriggerAbilitiesOfCivilizationCardsEffect(Civilization civilization) : base()
        {
            Civilization = civilization;
        }

        public PlayersCannotUseShieldTriggerAbilitiesOfCivilizationCardsEffect(PlayersCannotUseShieldTriggerAbilitiesOfCivilizationCardsEffect effect) : base(effect)
        {
            Civilization = effect.Civilization;
        }

        public Civilization Civilization { get; }

        public bool Applies(ICard card)
        {
            return card.HasCivilization(Civilization);
        }

        public override IContinuousEffect Copy()
        {
            return new PlayersCannotUseShieldTriggerAbilitiesOfCivilizationCardsEffect(this);
        }

        public override string ToString()
        {
            return $"Player's can't use the \"shield trigger\" abilities of {Civilization} cards.";
        }
    }
}