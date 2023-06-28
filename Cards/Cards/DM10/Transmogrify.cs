using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM10
{
    class Transmogrify : Spell
    {
        public Transmogrify() : base("Transmogrify", 3, Civilization.Water)
        {
            AddShieldTrigger();
            AddSpellAbilities(new TransmogrifyEffect());
        }
    }

    public class TransmogrifyEffect : OneShotEffect
    {
        public TransmogrifyEffect()
        {
        }

        public TransmogrifyEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply()
        {
            var destroyedCreature = Applier.DestroyCreatureOptionally(Ability);
            if (destroyedCreature != null)
            {
                destroyedCreature.Owner.RevealFromTopDeckUntilNonEvolutionCreaturePutIntoBattleZoneRestIntoGraveyard(Ability);
            }
        }

        public override IOneShotEffect Copy()
        {
            return new TransmogrifyEffect(this);
        }

        public override string ToString()
        {
            return "You may destroy a creature. If you do, its owner reveals cards from the top of his deck until he reveals a non-evolution creature. He puts that creature into the battle zone and puts the rest of those cards into his graveyard.";
        }
    }
}
