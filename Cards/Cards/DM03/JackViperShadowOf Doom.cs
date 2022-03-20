using Cards.ContinuousEffects;
using Common;

namespace Cards.Cards.DM03
{
    class JackViperShadowOfDoom : EvolutionCreature
    {
        public JackViperShadowOfDoom() : base("Jack Viper, Shadow of Doom", 3, 4000, Subtype.Ghost, Civilization.Darkness)
        {
            AddAbilities(new JackViperShadowOfDoomAbility());
        }
    }

    class JackViperShadowOfDoomAbility : Engine.Abilities.StaticAbility
    {
        public JackViperShadowOfDoomAbility() : base(new DestructionReplacementOptionallyToHandEffect(new CardFilters.OwnersBattleZoneAnotherCivilizationCreatureFilter(Civilization.Darkness)))
        {
        }

        public override string ToString()
        {
            return "Whenever another of your darkness creatures would be put into your graveyard from the battle zone, you may return it to your hand instead.";
        }
    }
}
