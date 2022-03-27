using Common;

namespace Cards.Cards.DM02
{
    class Bombersaur : Creature
    {
        public Bombersaur() : base("Bombersaur", 5, 5000, Subtype.RockBeast, Civilization.Fire)
        {
            AddAbilities(new TriggeredAbilities.WhenThisCreatureIsDestroyedAbility(new OneShotEffects.MutualManaSacrificeEffect(2)));
        }
    }
}
