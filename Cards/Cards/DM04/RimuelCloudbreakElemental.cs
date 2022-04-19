using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM04
{
    class RimuelCloudbreakElemental : Creature
    {
        public RimuelCloudbreakElemental() : base("Rimuel, Cloudbreak Elemental", 8, 6000, Race.AngelCommand, Civilization.Light)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new RimuelCloudbreakElementalEffect());
            AddDoubleBreakerAbility();
        }
    }

    class RimuelCloudbreakElementalEffect : OneShotEffect
    {
        public override void Apply(IGame game, IAbility source)
        {
            var amount = source.GetController(game).ManaZone.UntappedCards.Count(x => x.HasCivilization(Civilization.Light));
            new RimuelCloudbreakElementalTapEffect(amount).Apply(game, source);
        }

        public override IOneShotEffect Copy()
        {
            return new RimuelCloudbreakElementalEffect();
        }

        public override string ToString()
        {
            return "Tap one of your opponent's creatures in the battle zone for each untapped light card in your mana zone.";
        }
    }

    class RimuelCloudbreakElementalTapEffect : TapChoiceEffect
    {
        private readonly int _amount;

        public RimuelCloudbreakElementalTapEffect(int amount) : base(amount, amount, true)
        {
            _amount = amount;
        }

        public RimuelCloudbreakElementalTapEffect(RimuelCloudbreakElementalTapEffect effect) : base(effect)
        {
            _amount = effect._amount;
        }

        public override IOneShotEffect Copy()
        {
            return new RimuelCloudbreakElementalTapEffect(this);
        }

        public override string ToString()
        {
            return $"Tap {_amount} of your opponent's creatures.";
        }

        protected override IEnumerable<ICard> GetSelectableCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, source.GetOpponent(game).Id);
        }
    }
}
