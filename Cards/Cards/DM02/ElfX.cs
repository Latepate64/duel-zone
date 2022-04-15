using Cards.ContinuousEffects;
using Common;
using Engine.ContinuousEffects;

namespace Cards.Cards.DM02
{
    class ElfX : Creature
    {
        public ElfX() : base("Elf-X", 4, 2000, Engine.Subtype.TreeFolk, Civilization.Nature)
        {
            AddStaticAbilities(new ElfXEffect());
        }
    }

    class ElfXEffect : ContinuousEffect, ICostModifyingEffect
    {
        public ElfXEffect() : base() { }

        public override IContinuousEffect Copy()
        {
            return new ElfXEffect();
        }

        public int GetChange(Engine.ICard card, Engine.IGame game)
        {
            return card.Owner == GetController(game).Id && card.CardType == CardType.Creature ? -1 : 0;
        }

        public override string ToString()
        {
            return "Your creatures each cost 1 less to summon. They can't cost less than 1.";
        }
    }
}
