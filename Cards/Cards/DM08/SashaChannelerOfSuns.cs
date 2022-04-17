using Cards.ContinuousEffects;
using Engine;
using Engine.ContinuousEffects;
using Engine.Steps;

namespace Cards.Cards.DM08
{
    class SashaChannelerOfSuns : Creature
    {
        public SashaChannelerOfSuns() : base("Sasha, Channeler of Suns", 8, 9500, Race.MechaDelSol, Civilization.Light)
        {
            AddStaticAbilities(new SashaBlockerEffect(), new SashaPowerEffect());
            AddDoubleBreakerAbility();
        }
    }

    class SashaBlockerEffect : ContinuousEffect, IBlockerEffect
    {
        public bool CanBlock(ICard blocker, ICard attacker, IGame game)
        {
            return attacker.IsDragon;
        }

        public override IContinuousEffect Copy()
        {
            return new SashaBlockerEffect();
        }

        public override string ToString()
        {
            return "Dragon blocker";
        }
    }

    class SashaPowerEffect : ContinuousEffect, IPowerModifyingEffect
    {
        public SashaPowerEffect()
        {
        }

        public SashaPowerEffect(SashaPowerEffect effect) : base(effect)
        {
        }

        public override IContinuousEffect Copy()
        {
            return new SashaPowerEffect(this);
        }

        public void ModifyPower(IGame game)
        {
            if (game.CurrentTurn.CurrentPhase is AttackPhase a)
            {
                var against = a.GetCreatureBattlingAgainst(GetSourceCard(game));
                if (against != null && against.IsDragon)
                {
                    GetSourceCard(game).Power += 6000;
                }
            }
        }

        public override string ToString()
        {
            return "While battling a creature that has Dragon in its race, this creature gets +6000 power.";
        }
    }
}
