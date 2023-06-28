using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM12
{
    class ClonedSpiral : Spell
    {
        public ClonedSpiral() : base("Cloned Spiral", 4, Civilization.Water)
        {
            AddSpellAbilities(new ClonedSpiralEffect());
        }
    }

    class ClonedSpiralEffect : ClonedEffect
    {
        public ClonedSpiralEffect() : base("Cloned Spiral")
        {
        }

        public ClonedSpiralEffect(ClonedSpiralEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            var creatures = Applier.ChooseCards(game.BattleZone.GetChoosableCreaturesControlledByAnyone(Applier), 1, GetAmount(game), ToString());
            game.Move(Ability, ZoneType.BattleZone, ZoneType.Hand, creatures.ToArray());
        }

        public override IOneShotEffect Copy()
        {
            return new ClonedSpiralEffect(this);
        }

        public override string ToString()
        {
            return "Choose a creature in battle zone. Then, for each Cloned Spiral in each graveyard, you may choose another creature in the battle zone. Return all those creature to their owner's hands.";
        }
    }
}
