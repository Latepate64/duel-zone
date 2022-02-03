﻿using Engine.Abilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Engine
{
    public enum CardType { Creature, Spell, Any }

    public enum Subtype
    {
        AngelCommand,
        ArmoredDragon,
        ArmoredWyvern,
        Armorloid,
        BalloonMushroom,
        BeastFolk,
        Berserker,
        BrainJacker,
        Chimera,
        ColonyBeetle,
        CyberCluster,
        CyberLord,
        CyberVirus,
        DarkLord,
        DeathPuppet,
        DemonCommand,
        Dragonoid,
        EarthDragon,
        EarthEater,
        Fish,
        GelFish,
        Ghost,
        Giant,
        GiantInsect,
        Gladiator,
        Guardian,
        Hedrian,
        HornedBeast,
        Human,
        Initiate,
        Leviathan,
        LightBringer,
        LiquidPeople,
        LivingDead,
        MachineEater,
        MechaDelSol,
        MechaThunder,
        Merfolk,
        ParasiteWorm,
        RainbowPhantom,
        RockBeast,
        SeaHacker,
        SnowFaerie,
        Soltrooper,
        StarlightTree,
        TreeFolk,
        Xenoparts,
    }

    public enum Civilization { Light, Water, Darkness, Fire, Nature };

    public class Card : DuelObject, ICopyable<Card>, IAttackable
    {
        // 109.3. An object’s characteristics are name, mana cost, color, color indicator, card type, subtype, supertype, rules text, abilities, power, toughness, loyalty, hand modifier, and life modifier. Objects can have some or all of these characteristics. Any other information about an object isn’t a characteristic.

        public string Name { get; set; }

        public CardType CardType { get; set; }

        /// <summary>
        /// Also known as race for creatures.
        /// </summary>
        public IEnumerable<Subtype> Subtypes { get; set; } = new Collection<Subtype>();

        public List<Ability> Abilities { get; } = new List<Ability>();

        public int? Power { get; set; }

        public ICollection<Civilization> Civilizations { get; set; }

        public int ManaCost { get; set; }

        public bool Tapped { get; set; }

        public bool ShieldTrigger { get; set; } = false;

        public ICollection<Guid> RevealedTo { get; internal set; } = new List<Guid>();

        /// <summary>
        /// Note: use AffectedBySummoningSickness to determine if creature is able to attack
        /// </summary>
        public bool SummoningSickness { get; internal set; } = true;

        public Card()
        {
        }

        internal Card(Card card, bool copyId) : base(card, copyId)
        {
            Abilities = card.Abilities.Select(x => x.Copy()).ToList();
            CardType = card.CardType;
            Civilizations = card.Civilizations.ToList();
            ManaCost = card.ManaCost;
            Name = card.Name;
            Power = card.Power;
            RevealedTo = card.RevealedTo.ToList();
            ShieldTrigger = card.ShieldTrigger;
            Subtypes = card.Subtypes?.ToList();
            SummoningSickness = card.SummoningSickness;
            Tapped = card.Tapped;

            // If card gets new id, ability informations must be updated.
            if (!copyId)
            {
                InitializeAbilities();
            }
        }

        public virtual Card Copy()
        {
            return new Card(this, true);
        }

        public override string ToString()
        {
            return Name;
            //return Name + " " + Id.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Civilizations.Clear();
                RevealedTo = null;
            }
        }

        /// <summary>
        /// Initializes the sources and controllers of all abilities and related abstractions of the card.
        /// </summary>
        public void InitializeAbilities()
        {
            foreach (var ability in Abilities)
            {
                ability.Owner = Owner;
                ability.Source = Id;
                if (ability is StaticAbility staticAbility)
                {
                    foreach (var effect in staticAbility.ContinuousEffects)
                    {
                        effect.Filter.Target = Id;
                    }
                }
            }
        }
    }
}