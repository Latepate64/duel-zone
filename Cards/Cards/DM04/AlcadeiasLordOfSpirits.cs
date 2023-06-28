using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM04
{
    class AlcadeiasLordOfSpirits : EvolutionCreature
    {
        public AlcadeiasLordOfSpirits() : base("Alcadeias, Lord of Spirits", 6, 12500, Race.AngelCommand, Civilization.Light)
        {
            AddDoubleBreakerAbility();
            AddStaticAbilities(new AlcadeiasLordOfSpiritsEffect());
        }
    }

    class AlcadeiasLordOfSpiritsEffect : ContinuousEffect, ICannotUseCardEffect
    {
        public AlcadeiasLordOfSpiritsEffect(AlcadeiasLordOfSpiritsEffect effect) : base(effect)
        {
        }

        public AlcadeiasLordOfSpiritsEffect() : base()
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

        public bool Applies(ICard card)
        {
            return card.IsSpell && !card.HasCivilization(Civilization.Light);
        }
    }
}
