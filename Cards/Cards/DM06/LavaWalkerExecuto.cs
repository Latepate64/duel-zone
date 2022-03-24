using Common;

namespace Cards.Cards.DM06
{
    class LavaWalkerExecuto : EvolutionCreature
    {
        public LavaWalkerExecuto() : base("Lava Walker Executo", 4, 5000, Subtype.Dragonoid, Civilization.Fire)
        {
            AddAbilities(new StaticAbilities.TapAbilityAddingAbility(Civilization.Fire, new OneShotEffects.GrantPowerChoiceEffect(3000, new CardFilters.OwnersBattleZoneCivilizationCreatureFilter(Civilization.Fire))));
        }
    }
}
