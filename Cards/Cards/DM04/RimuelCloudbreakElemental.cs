using Engine;
using Engine.Abilities;
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
        public override void Apply(IGame game)
        {
            var controller = Controller;
            var amount = controller.ManaZone.UntappedCards.Count(x => x.HasCivilization(Civilization.Light));
            var creatures = controller.ChooseCards(game.BattleZone.GetChoosableCreaturesControlledByPlayer(game, GetOpponent(game).Id), amount, amount, ToString());
            controller.Tap(game, creatures.ToArray());
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
