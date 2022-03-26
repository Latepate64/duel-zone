using Cards.OneShotEffects;
using Common;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM04
{
    class HydroHurricane : Spell
    {
        public HydroHurricane() : base("Hydro Hurricane", 6, Civilization.Water)
        {
            AddSpellAbilities(new HydroHurricaneFirstEffect(), new HydroHurricaneSecondEffect());
        }
    }

    class HydroHurricaneFirstEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            return new OneShotEffects.OpponentManaRecoveryEffect(0, game.BattleZone.GetCreatures(source.Owner).Where(x => x.Civilizations.Contains(Civilization.Light)).Count(), true).Apply(game, source);
        }

        public override IOneShotEffect Copy()
        {
            return new HydroHurricaneFirstEffect();
        }

        public override string ToString()
        {
            return "For each light creature you have in the battle zone, you may choose a card in your opponent's mana zone and return it to his hand.";
        }
    }

    class HydroHurricaneSecondEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var amount = game.BattleZone.GetCreatures(source.Owner).Where(x => x.Civilizations.Contains(Civilization.Darkness)).Count();
            return new HydroHurricaneBounceEffect(amount).Apply(game, source);
        }

        public override IOneShotEffect Copy()
        {
            return new HydroHurricaneSecondEffect();
        }

        public override string ToString()
        {
            return "For each darkness creature you have in the battle zone, you may choose one of your opponent's creatures in the battle zone and return it to his hand.";
        }
    }

    class HydroHurricaneBounceEffect : BounceEffect
    {
        private readonly int _maximum;

        public HydroHurricaneBounceEffect(int maximum) : base(new CardFilters.OpponentsBattleZoneChoosableCreatureFilter(), 0, maximum)
        {
            _maximum = maximum;
        }

        public HydroHurricaneBounceEffect(HydroHurricaneBounceEffect effect) : base(effect)
        {
            _maximum = effect._maximum;
        }

        public override IOneShotEffect Copy()
        {
            return new HydroHurricaneBounceEffect(this);
        }

        public override string ToString()
        {
            return $"Choose up to {_maximum} of your opponent's creatures in the battle zone and return them to his hand.";
        }
    }
}
