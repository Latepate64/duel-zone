using OneShotEffects;
using TriggeredAbilities;

namespace Cards.DM12
{
    class WindmillMutant : Engine.Creature
    {
        public WindmillMutant() : base("Windmill Mutant", 3, 2000, Engine.Race.Hedrian, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(new OpponentDiscardsCardAtRandomEffect()));
        }
    }
}
