using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM12
{
    class ClonedDeflector : Spell
    {
        public ClonedDeflector() : base("Cloned Deflector", 3, Civilization.Light)
        {
            AddShieldTrigger();
            AddSpellAbilities(new ClonedDeflectorEffect());
        }
    }

    class ClonedDeflectorEffect : ClonedEffect
    {
        public ClonedDeflectorEffect() : base("Cloned Deflector")
        {
        }

        public ClonedDeflectorEffect(ClonedDeflectorEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var player = Applier;
            var creatures = player.ChooseCards(game.BattleZone.GetChoosableCreaturesControlledByChoosersOpponent(game, Applier), 1, GetAmount(game), ToString());
            player.Tap(game, creatures.ToArray());
        }

        public override IOneShotEffect Copy()
        {
            return new ClonedDeflectorEffect(this);
        }

        public override string ToString()
        {
            return "Choose one of your opponent's creatures in the battle zone. Then, for each Cloned Deflector in each graveyard, you may choose another of your opponent's creatures in the battle zone. Tap all those creatures.";
        }
    }
}
