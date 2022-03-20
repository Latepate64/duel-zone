using Common;
using Engine.Abilities;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM02
{
    class ArmoredBlasterValdios : EvolutionCreature
    {
        public ArmoredBlasterValdios() : base("Armored Blaster Valdios", 4, 6000, Subtype.Human, Civilization.Fire)
        {
            AddAbilities(new ArmoredBlasterValdiosAbility(), new StaticAbilities.DoubleBreakerAbility());
        }
    }

    class ArmoredBlasterValdiosAbility : StaticAbility
    {
        public ArmoredBlasterValdiosAbility() : base(new PowerModifyingEffect(1000, new CardFilters.OwnersBattleZoneSubtypeCreatureExceptFilter(Subtype.Human), new Engine.Durations.Indefinite()))
        {
        }

        public override string ToString()
        {
            return "Each of your other Humans in the battle zone gets +1000 power.";
        }
    }
}