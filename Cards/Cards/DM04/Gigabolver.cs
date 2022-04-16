using Cards.ContinuousEffects;

namespace Cards.Cards.DM04
{
    class Gigabolver : Creature
    {
        public Gigabolver() : base("Gigabolver", 4, 3000, Engine.Race.Chimera, Engine.Civilization.Darkness)
        {
            AddStaticAbilities(new PlayersCannotUseShieldTriggerAbilitiesOfCivilizationCardsEffect(Engine.Civilization.Light));
        }
    }
}
