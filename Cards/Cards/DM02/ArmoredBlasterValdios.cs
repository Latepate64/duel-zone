using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM02
{
    class ArmoredBlasterValdios : EvolutionCreature
    {
        public ArmoredBlasterValdios() : base("Armored Blaster Valdios", 4, 6000, Subtype.Human, Civilization.Fire)
        {
            AddStaticAbilities(new ArmoredBlasterValdiosEffect());
            AddDoubleBreakerAbility();
        }
    }

    class ArmoredBlasterValdiosEffect : PowerModifyingEffect
    {
        public ArmoredBlasterValdiosEffect() : base(1000, new CardFilters.OwnersBattleZoneSubtypeCreatureExceptFilter(Subtype.Human), new Durations.Indefinite()) { }

        public override IContinuousEffect Copy()
        {
            return new ArmoredBlasterValdiosEffect();
        }

        public override string ToString()
        {
            return "Each of your other Humans in the battle zone gets +1000 power.";
        }
    }
}