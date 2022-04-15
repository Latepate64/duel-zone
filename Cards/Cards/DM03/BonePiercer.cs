using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM03
{
    class BonePiercer : Creature
    {
        public BonePiercer() : base("Bone Piercer", 2, 1000, Subtype.BrainJacker, Civilization.Darkness)
        {
            AddWhenThisCreatureIsDestroyedAbility(new BonePiercerEffect());
        }
    }

    class BonePiercerEffect : OneShotEffects.SelfManaRecoveryEffect
    {
        public BonePiercerEffect() : base(0, 1, true)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new BonePiercerEffect();
        }

        public override string ToString()
        {
            return "You may return a creature from your mana zone to your hand.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.GetPlayer(source.Controller).ManaZone.Creatures;
        }
    }
}
