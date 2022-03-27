using Common;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM04
{
    class TroxGeneralOfDestruction : Creature
    {
        public TroxGeneralOfDestruction() : base("Trox, General of Destruction", 7, 6000, Subtype.DemonCommand, Civilization.Darkness)
        {
            AddAbilities(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new TroxGeneralOfDestructionEffect()), new StaticAbilities.DoubleBreakerAbility());
        }
    }

    class TroxGeneralOfDestructionEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var amount = game.BattleZone.GetCreatures(source.Owner).Where(x => x.Id != source.Source && x.Civilizations.Contains(Civilization.Darkness)).Count();
            game.GetOpponent(game.GetPlayer(source.Owner)).DiscardAtRandom(game, amount);
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new TroxGeneralOfDestructionEffect();
        }

        public override string ToString()
        {
            return "Your opponent discards a card at random from his hand for each other darkness creature you have in the battle zone.";
        }
    }
}
