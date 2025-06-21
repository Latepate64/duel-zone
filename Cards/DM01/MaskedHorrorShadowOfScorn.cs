using TriggeredAbilities;
using OneShotEffects;

namespace Cards.DM01
{
    class MaskedHorrorShadowOfScorn : Engine.Creature
    {
        public MaskedHorrorShadowOfScorn() : base("Masked Horror, Shadow of Scorn", 5, 1000, Interfaces.Race.Ghost, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OpponentDiscardsCardAtRandomEffect()));
        }
    }
}
