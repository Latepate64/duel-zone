using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM04
{
    class TroxGeneralOfDestruction : Creature
    {
        public TroxGeneralOfDestruction() : base("Trox, General of Destruction", 7, 6000, Race.DemonCommand, Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new TroxGeneralOfDestructionEffect());
            AddDoubleBreakerAbility();
        }
    }

    class TroxGeneralOfDestructionEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            var amount = game.BattleZone.GetCreatures(GetSourceAbility(game).Controller).Count(x => x.Id != GetSourceAbility(game).Source && x.HasCivilization(Civilization.Darkness));
            GetOpponent(game).DiscardAtRandom(game, amount, GetSourceAbility(game));
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
