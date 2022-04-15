using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM04
{
    class Gigabolver : Creature
    {
        public Gigabolver() : base("Gigabolver", 4, 3000, Engine.Subtype.Chimera, Civilization.Darkness)
        {
            AddStaticAbilities(new PlayersCannotUseShieldTriggerAbilitiesOfCivilizationCardsEffect(Civilization.Light));
        }
    }
}
