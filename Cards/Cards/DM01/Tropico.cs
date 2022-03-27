using Engine;
using Engine.ContinuousEffects;
using System;
using System.Linq;

namespace Cards.Cards.DM01
{
    class Tropico : Creature
    {
        public Tropico() : base("Tropico", 5, 3000, Common.Subtype.CyberLord, Common.Civilization.Water)
        {
            AddAbilities(new TropicoAbility());
        }
    }

    class TropicoCondition : Condition
    {
        public TropicoCondition() : base(new CardFilters.OwnersOtherBattleZoneCreatureFilter())
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

    class TropicoAbility : Engine.Abilities.StaticAbility
    {
        public TropicoAbility() : base(new TropicoEffect())
        {
        }
    }

    class TropicoEffect : UnblockableEffect
    {
        public TropicoEffect() : base(new TargetFilter(), new Durations.Indefinite(), new CardFilters.BattleZoneCreatureFilter(), new TropicoCondition())
        {
        }

        public override IContinuousEffect Copy()
        {
            return new TropicoEffect();
        }

        public override string ToString()
        {
            return "This creature can't be blocked while you have at least 2 other creatures in the battle zone.";
        }
    }
}
