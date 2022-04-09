using Common;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards.Cards.DM06
{
    class InvincibleAbyss : Spell
    {
        public InvincibleAbyss() : base("Invincible Abyss", 13, Civilization.Darkness)
        {
            AddSpellAbilities(new InvincibleAbyssEffect());
        }
    }

    class InvincibleAbyssEffect : OneShotEffects.DestroyAreaOfEffect
    {
        public InvincibleAbyssEffect() : base(new CardFilters.OpponentsBattleZoneCreatureFilter())
        {
        }

        public override IOneShotEffect Copy()
        {
            return new InvincibleAbyssEffect();
        }

        public override string ToString()
        {
            return "Destroy all your opponent's creatures.";
        }

        protected override IEnumerable<Engine.ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(source.GetOpponent(game).Id);
        }
    }
}
