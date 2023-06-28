using Cards.TriggeredAbilities;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.Promo
{
    class SuperDragonMachineDolzark : Creature
    {
        public SuperDragonMachineDolzark() : base("Super Dragon Machine Dolzark", 6, 7000, Race.ArmoredDragon, Race.EarthDragon, Civilization.Fire, Civilization.Nature)
        {
            AddTriggeredAbility(new DolzarkAbility());
            AddDoubleBreakerAbility();
        }
    }

    class DolzarkAbility : WheneverCreatureAttacksAbility
    {
        public DolzarkAbility() : base(new DolzarkEffect())
        {
        }

        public DolzarkAbility(DolzarkAbility ability) : base(ability)
        {
        }

        public override IAbility Copy()
        {
            return new DolzarkAbility(this);
        }

        public override string ToString()
        {
            return $"Whenever one of your other creatures that has Dragon in its race attacks, {GetEffectText()}";
        }

        protected override bool TriggersFrom(ICard card, IGame game)
        {
            return card.Owner == Controller && card != Source && card.IsDragon;
        }
    }

    class DolzarkEffect : OneShotEffects.CardMovingChoiceEffect
    {
        public DolzarkEffect() : base(0, 1, true, ZoneType.BattleZone, ZoneType.ManaZone)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new DolzarkEffect();
        }

        public override string ToString()
        {
            return "You may choose one of your opponent's creatures in the battle zone that has power 5000 or less and put it into his mana zone.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableCreaturesControlledByChoosersOpponent(game, Applier).Where(x => x.Power <= 5000);
        }
    }
}
