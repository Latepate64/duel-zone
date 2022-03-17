using Engine;
using System;
using System.Linq;

namespace Cards.Cards.DM01
{
    class Tropico : Creature
    {
        public Tropico() : base("Tropico", 5, 3000, Common.Subtype.CyberLord, Common.Civilization.Water)
        {
            // This creature can't be blocked while you have at least 2 other creatures in the battle zone.
            AddAbilities(new StaticAbilities.UnblockableAbility(new TropicoCondition()));
        }
    }

    class TropicoCondition : Condition
    {
        public TropicoCondition() : base(new CardFilters.OwnersBattleZoneCreatureExceptFilter())
        {
        }

        public TropicoCondition(TropicoCondition condition) : base(condition)
        {
        }

        public override bool Applies(Game game, Guid player)
        {
            return game.GetAllCards().Count(card => Filter.Applies(card, game, game.GetPlayer(player))) >= 2;
        }

        public override Condition Copy()
        {
            return new TropicoCondition(this);
        }

        public override string ToString()
        {
            return "While you have at least 2 other creatures in the battle zone";
        }
    }
}
