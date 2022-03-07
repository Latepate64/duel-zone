using Common;

namespace Cards.Cards.DM10
{
    class DolmarksTheShadowWarrior : Creature
    {
        public DolmarksTheShadowWarrior() : base("Dolmarks, the Shadow Warrior", 4, 4000, Civilization.Darkness, Civilization.Fire)
        {
            AddAbilities(new TriggeredAbilities.PutIntoPlayAbility(new OneShotEffects.DolmarksTheShadowWarriorEffect()));
        }
    }
}
