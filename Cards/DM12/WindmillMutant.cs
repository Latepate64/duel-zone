using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM12
{
    class WindmillMutant : Engine.Creature
    {
        public WindmillMutant() : base("Windmill Mutant", 3, 2000, Interfaces.Race.Hedrian, Interfaces.Civilization.Darkness)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OpponentDiscardsCardAtRandomEffect()));
        }
    }
}
