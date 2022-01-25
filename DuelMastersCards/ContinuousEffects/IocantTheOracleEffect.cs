using DuelMastersCards.CardFilters;
using DuelMastersModels;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;
using DuelMastersModels.GameEvents;
using System.Linq;

namespace DuelMastersCards.ContinuousEffects
{
    /// <summary>
    /// While you have at least 1 Angel Command in the battle zone, this creature gets +2000 power.
    /// </summary>
    class IocantTheOracleEffect : CharacteristicModifyingEffect
    {
        public IocantTheOracleEffect(IocantTheOracleEffect effect) : base(effect)
        {
        }

        public IocantTheOracleEffect() : base(new TargetFilter(), new Indefinite())
        {
        }

        public override ContinuousEffect Copy()
        {
            return new IocantTheOracleEffect(this);
        }

        public override void Start(Game game)
        {
            var card = game.GetAllCards().Where(card => Filter.Applies(card, game, game.GetPlayer(card.Owner))).Single();
            if (game.BattleZone.GetCreatures(card.Owner).Any(x => x.Subtypes.Contains(Subtype.AngelCommand)))
            {
                _buffActive = true;
                card.Power += Buff;
            }
        }

        public override void End(Game game)
        {
            var card = game.GetAllCards().Where(card => Filter.Applies(card, game, game.GetPlayer(card.Owner))).Single();
            if (_buffActive)
            {
                _buffActive = false;
                card.Power -= Buff;
            }
        }

        public override void Update(Game game, GameEvent e)
        {
            if (e is CardMovedEvent cardMoved && (cardMoved.Source == DuelMastersModels.Zones.ZoneType.BattleZone || cardMoved.Destination == DuelMastersModels.Zones.ZoneType.BattleZone))
            {
                var card = game.GetAllCards().Where(card => Filter.Applies(card, game, game.GetPlayer(card.Owner))).Single();
                var buffShouldBeApplied = game.BattleZone.GetCreatures(card.Owner).Any(x => x.Subtypes.Contains(Subtype.AngelCommand));
                if (buffShouldBeApplied && !_buffActive)
                {
                    _buffActive = true;
                    card.Power += Buff;
                }
                else if (!buffShouldBeApplied && _buffActive)
                {
                    _buffActive = false;
                    card.Power -= Buff;
                }
            }
        }

        bool _buffActive;
        const int Buff = 2000;
    }
}
