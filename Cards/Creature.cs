﻿using Cards.ContinuousEffects;
using Cards.TriggeredAbilities;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards
{
    class Creature : Card
    {
        /// <summary>
        /// This constructor should be used for cards with one race.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="manaCost"></param>
        /// <param name="power"></param>
        /// <param name="race"></param>
        /// <param name="civilizations"></param>
        protected Creature(string name, int manaCost, int power, Race race, params Civilization[] civilizations) : this(name, manaCost, power, civilizations)
        {
            SetPrintedRaces(race);
        }

        protected Creature(string name, int manaCost, int power, Race race, Civilization civilization) : this(name, manaCost, power, race, new Civilization[] { civilization })
        {
        }

        protected Creature(string name, int manaCost, int power, Race race1, Race race2, Civilization civilization1, Civilization civilization2) : base(CardType.Creature, name, manaCost, power, new Civilization[] { civilization1, civilization2 })
        {
            SetPrintedRaces(race1, race2);
        }

        /// <summary>
        /// This constructor should be used for multicolored cards. Add races for the card in the constructor of the inheritor.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="manaCost"></param>
        /// <param name="power"></param>
        protected Creature(string name, int manaCost, int power, params Civilization[] civilizations) : base(CardType.Creature, name, manaCost, power, civilizations)
        {
            Power = power;
        }

        protected Creature(string name, int manaCost, int power, Race race1, Race race2, Civilization civilization) : base(CardType.Creature, name, manaCost, power, new Civilization[] { civilization })
        {
            SetPrintedRaces(race1, race2);
        }

        public Creature(ICard card) : base(card)
        {
        }

        #region Static abilities
        protected void AddBlockerAbility()
        {
            AddStaticAbilities(new ThisCreatureHasBlockerEffect());
        }

        protected void AddThisCreatureCannotAttackAbility()
        {
            AddStaticAbilities(new ThisCreatureCannotAttackEffect());
        }

        protected void AddSlayerAbility()
        {
            AddStaticAbilities(new ThisCreatureHasSlayerEffect());
        }

        protected void AddPowerAttackerAbility(int power)
        {
            AddStaticAbilities(new PowerAttackerEffect(power));
        }

        protected void AddThisCreatureCannotBeBlockedAbility()
        {
            AddStaticAbilities(new ThisCreatureCannotBeBlockedEffect());
        }

        protected void AddDoubleBreakerAbility()
        {
            AddStaticAbilities(new DoubleBreakerEffect());
        }

        protected void AddTripleBreakerAbility()
        {
            AddStaticAbilities(new TripleBreakerEffect());
        }

        protected void AddThisCreatureCannotAttackPlayersAbility()
        {
            AddStaticAbilities(new ThisCreatureCannotAttackPlayersEffect());
        }

        protected void AddThisCreatureCanAttackUntappedCreaturesAbility()
        {
            AddStaticAbilities(new ThisCreatureCanAttackUntappedCreaturesEffect());
        }

        protected void AddSpeedAttackerAbility()
        {
            AddStaticAbilities(new ThisCreatureHasSpeedAttackerEffect());
        }

        protected void AddThisCreatureCannotBeAttackedAbility()
        {
            AddStaticAbilities(new ThisCreatureCannotBeAttackedEffect());
        }

        protected void AddThisCreatureBlocksIfAble()
        {
            AddStaticAbilities(new ThisCreatureBlocksIfAble());
        }
        #endregion Static abilities

        #region Triggered abilities
        protected void AddTriggeredAbility(ITriggeredAbility ability)
        {
            AddAbilities(ability);
        }

        protected void AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(IOneShotEffect effect)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(effect));
        }

        protected void AddAtTheEndOfYourTurnAbility(IOneShotEffect effect)
        {
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(effect));
        }

        protected void AddWheneverThisCreatureAttacksAbility(IOneShotEffect effect)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(effect));
        }

        protected void AddWhenThisCreatureIsDestroyedAbility(IOneShotEffect effect)
        {
            AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(effect));
        }
        #endregion Triggered abilities

        protected void AddTapAbility(IOneShotEffect effect)
        {
            AddAbilities(new TapAbility(effect));
        }

        protected void AddSurvivorAbility(Engine.ContinuousEffects.IContinuousEffect effect)
        {
            AddStaticAbilities(new SurvivorEffect(new StaticAbility(effect)));
        }

        protected void AddSurvivorAbility(ITriggeredAbility ability)
        {
            AddStaticAbilities(new SurvivorEffect(ability));
        }

        public override ICard Copy()
        {
            return new Creature(this);
        }
    }

    class TurboRushCreature : Creature
    {
        public TurboRushCreature(string name, int manaCost, int power, Race race, params Civilization[] civilizations) : base(name, manaCost, power, race, civilizations)
        {
        }

        protected void AddTurboRushAbility(ITriggeredAbility ability)
        {
            AddStaticAbilities(new TurboRushEffect(ability));
        }

        protected void AddTurboRushAbility(Engine.ContinuousEffects.IContinuousEffect effect)
        {
            AddStaticAbilities(new TurboRushEffect(new StaticAbility(effect)));
        }
    }

    class SilentSkillCreature : Creature
    {
        public SilentSkillCreature(string name, int manaCost, int power, Race race, Civilization civilization) : base(name, manaCost, power, race, civilization)
        {
        }

        public SilentSkillCreature(string name, int manaCost, int power, Race race, Civilization civilization1, Civilization civilization2) : base(name, manaCost, power, race, civilization1, civilization2)
        {
        }

        protected void AddSilentSkillAbility(IOneShotEffect effect)
        {
            AddAbilities(new SilentSkillAbility(effect));
        }
    }

    class WaveStrikerCreature : Creature
    {
        public WaveStrikerCreature(string name, int manaCost, int power, Race race, Civilization civilization) : base(name, manaCost, power, race, civilization)
        {
        }

        protected void AddWaveStrikerAbility(params Engine.ContinuousEffects.IContinuousEffect[] effects)
        {
            AddAbilities(new StaticAbilities.WaveStrikerAbility(effects.Select(x => new StaticAbility(x)).ToArray()));
        }

        protected void AddWaveStrikerAbility(ITriggeredAbility ability)
        {
            AddAbilities(new StaticAbilities.WaveStrikerAbility(ability));
        }
    }
}
