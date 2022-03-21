using Common;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM04
{
    class RimuelCloudbreakElemental : Creature
    {
        public RimuelCloudbreakElemental() : base("Rimuel, Cloudbreak Elemental", 8, 6000, Subtype.AngelCommand, Civilization.Light)
        {
            AddAbilities(new TriggeredAbilities.PutIntoPlayAbility(new RimuelCloudbreakElementalEffect()), new StaticAbilities.DoubleBreakerAbility());
        }
    }

    class RimuelCloudbreakElementalEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var amount = game.GetPlayer(source.Owner).ManaZone.UntappedCards.Where(x => x.Civilizations.Contains(Civilization.Light)).Count();
            return new OneShotEffects.TapChoiceEffect(amount, amount, true).Apply(game, source);
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
}
