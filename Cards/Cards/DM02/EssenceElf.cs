using Cards.ContinuousEffects;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM02
{
    class EssenceElf : Creature
    {
        public EssenceElf() : base("Essence Elf", 2, 1000, Engine.Subtype.TreeFolk, Engine.Civilization.Nature)
        {
            AddStaticAbilities(new EssenceElfEffect());
        }
    }

    class EssenceElfEffect : ContinuousEffect, ICostModifyingEffect
    {
        public EssenceElfEffect() : base()
        {
        }

        public override IContinuousEffect Copy()
        {
            return new EssenceElfEffect();
        }

        public int GetChange(Engine.ICard card, Engine.IGame game)
        {
            return card.Owner == GetController(game).Id && card.CardType == Engine.CardType.Spell ? -1 : 0;
        }

        public override string ToString()
        {
            return "Your spells each cost 1 less to cast. They can't cost less than 1.";
        }
    }
}
