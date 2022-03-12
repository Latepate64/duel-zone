using Common;
using Engine.Abilities;

namespace Cards.Cards.DM02
{
    class ArmoredBlasterValdios : EvolutionCreature
    {
        public ArmoredBlasterValdios() : base("Armored Blaster Valdios", 4, 6000, Subtype.Human, Civilization.Fire)
        {
            AddAbilities(new StaticAbility(new Engine.ContinuousEffects.PowerModifyingEffect(1000, new CardFilters.OwnersBattleZoneCreatureExceptFilter(Subtype.Human), new Engine.Durations.Indefinite())), new StaticAbilities.DoubleBreakerAbility());
        }
    }
}