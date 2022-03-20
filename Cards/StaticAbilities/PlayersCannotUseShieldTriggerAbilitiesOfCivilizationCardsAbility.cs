using Common;

namespace Cards.StaticAbilities
{
    class PlayersCannotUseShieldTriggerAbilitiesOfCivilizationCardsAbility : Engine.Abilities.StaticAbility
    {
        public PlayersCannotUseShieldTriggerAbilitiesOfCivilizationCardsAbility(Civilization civilization) : base(new ContinuousEffects.PlayersCannotUseShieldTriggerAbilitiesOfCivilizationCardsEffect(civilization))
        {
        }
    }
}
