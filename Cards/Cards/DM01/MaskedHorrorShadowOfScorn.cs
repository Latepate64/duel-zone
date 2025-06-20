using Abilities.Triggered;
using OneShotEffects;

namespace Cards.Cards.DM01
{
    class MaskedHorrorShadowOfScorn : Engine.Creature
    {
        public MaskedHorrorShadowOfScorn() : base("Masked Horror, Shadow of Scorn", 5, 1000, Engine.Race.Ghost, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OpponentDiscardsCardAtRandomEffect()));
        }
    }
}
