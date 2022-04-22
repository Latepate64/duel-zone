using Cards.OneShotEffects;

namespace Cards.Cards.DM12
{
    class WindmillMutant : Creature
    {
        public WindmillMutant() : base("Windmill Mutant", 3, 2000, Engine.Race.Hedrian, Engine.Civilization.Darkness)
        {
            AddWheneverThisCreatureAttacksAbility(new OpponentDiscardsCardAtRandomEffect());
        }
    }
}
