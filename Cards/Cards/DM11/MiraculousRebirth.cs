using Cards.CardFilters;
using Cards.OneShotEffects;
using Common;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM11
{
    class MiraculousRebirth : Spell
    {
        public MiraculousRebirth() : base("Miraculous Rebirth", 6, Civilization.Fire, Civilization.Nature)
        {
            AddSpellAbilities(new MiraculousRebirthEffect());
        }
    }

    class MiraculousRebirthEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var destroyed = new DestroyOnefYourOpponentsCreaturesThatHasMaxPowerEffect(5000).Apply(game, source);
            if (destroyed.Count() == 1)
            {
                new MiraculousRebirthSearchEffect(destroyed.Single().ManaCost).Apply(game, source);
            }
            return destroyed;
        }

        public override IOneShotEffect Copy()
        {
            return new MiraculousRebirthEffect();
        }

        public override string ToString()
        {
            return "Destroy one of your opponent's creatures that has power 5000 or less. When your opponent puts that creature into his graveyard, search your deck. You may take a creature from your deck that has the same cost as that creature and put it into the battle zone. Then shuffle your deck.";
        }
    }

    class MiraculousRebirthSearchEffect : SearchEffect
    {
        private readonly int _cost;

        public MiraculousRebirthSearchEffect(MiraculousRebirthSearchEffect effect) : base(effect)
        {
            _cost = effect._cost;
        }

        public MiraculousRebirthSearchEffect(int cost) : base(new OwnersDeckCreatureThatCostsFilter(cost), false)
        {
            _cost = cost;
        }

        public override IOneShotEffect Copy()
        {
            return new MiraculousRebirthSearchEffect(this);
        }

        public override string ToString()
        {
            return $"Search your deck. You may take a creature from your deck that costs {_cost} and put it into the battle zone. Then shuffle your deck.";
        }

        protected override void Apply(IGame game, IAbility source, params Engine.ICard[] cards)
        {
            game.Move(ZoneType.Deck, ZoneType.BattleZone, cards);
        }
    }

    class OwnersDeckCreatureThatCostsFilter : OwnersDeckCreatureFilter
    {
        private readonly int _cost;

        public OwnersDeckCreatureThatCostsFilter(int cost)
        {
            _cost = cost;
        }

        public OwnersDeckCreatureThatCostsFilter(OwnersDeckCreatureThatCostsFilter filter) : base(filter)
        {
            _cost = filter._cost;
        }

        public override bool Applies(Engine.ICard card, IGame game, Engine.IPlayer player)
        {
            return base.Applies(card, game, player) && card.ManaCost == _cost;
        }

        public override CardFilter Copy()
        {
            return new OwnersDeckCreatureThatCostsFilter(this);
        }
    }
}
