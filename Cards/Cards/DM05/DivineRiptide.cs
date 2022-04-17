using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM05
{
    class DivineRiptide : Spell
    {
        public DivineRiptide() : base("Divine Riptide", 9, Civilization.Water)
        {
            AddSpellAbilities(new DivineRiptideEffect());
        }
    }

    class DivineRiptideEffect : OneShotEffects.ManaRecoveryAreaOfEffect
    {
        public DivineRiptideEffect() : base()
        {
        }

        public override IOneShotEffect Copy()
        {
            return new DivineRiptideEffect();
        }

        public override string ToString()
        {
            return "Each player returns all cards from his mana zone to his hand.";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return game.Players.SelectMany(x => x.ManaZone.Cards);
        }
    }
}
