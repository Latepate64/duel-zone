using Cards.CardFilters;
using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM04
{
    class AlcadeiasLordOfSpirits : EvolutionCreature
    {
        public AlcadeiasLordOfSpirits() : base("Alcadeias, Lord of Spirits", 6, 12500, Subtype.AngelCommand, Civilization.Light)
        {
            AddAbilities(new StaticAbilities.DoubleBreakerAbility(), new AlcadeiasLordOfSpiritsAbility());
        }
    }

    class AlcadeiasLordOfSpiritsAbility : Engine.Abilities.StaticAbility
    {
        public AlcadeiasLordOfSpiritsAbility() : base(new AlcadeiasLordOfSpiritsEffect())
        {
        }
    }

    class AlcadeiasLordOfSpiritsEffect : CannotUseCardEffect
    {
        public AlcadeiasLordOfSpiritsEffect(AlcadeiasLordOfSpiritsEffect effect) : base(effect)
        {
        }

        public AlcadeiasLordOfSpiritsEffect() : base(new NonCivilizationSpellFilter(Civilization.Light))
        {
        }

        public override IContinuousEffect Copy()
        {
            return new AlcadeiasLordOfSpiritsEffect(this);
        }

        public override string ToString()
        {
            return "Players can't cast spells other than light spells.";
        }
    }
}
