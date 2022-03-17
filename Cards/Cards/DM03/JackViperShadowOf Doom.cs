using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM03
{
    class JackViperShadowOfDoom : EvolutionCreature
    {
        public JackViperShadowOfDoom() : base("Jack Viper, Shadow of Doom", 3, 4000, Subtype.Ghost, Civilization.Darkness)
        {
            AddAbilities(new Engine.Abilities.StaticAbility(new DestructionReplacementOptionallyToHandEffect(new CardFilters.OwnersBattleZoneAnotherCivilizationCreatureFilter(Civilization.Darkness))));
        }
    }
}
