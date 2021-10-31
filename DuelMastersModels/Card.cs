﻿using DuelMastersModels.Abilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DuelMastersModels
{
    public enum CardType { Creature, Spell }

    public enum Subtype
    {
        AngelCommand,
        ArmoredDragon,
        ArmoredWyvern,
        Armorloid,
        BeastFolk,
        Berserker,
        Chimera,
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
        GiantInsect,
        Gladiator,
        Guardian,
        Hedrian,
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

    public class Card : DuelObject, ICopyable<Card>
    {
        // 109.3. An object’s characteristics are name, mana cost, color, color indicator, card type, subtype, supertype, rules text, abilities, power, toughness, loyalty, hand modifier, and life modifier. Objects can have some or all of these characteristics. Any other information about an object isn’t a characteristic.

        public string Name { get; set; }

        public CardType CardType { get; set; }

        /// <summary>
        /// Also known as race for creatures.
        /// </summary>
        public IEnumerable<Subtype> Subtypes { get; set; } = new Collection<Subtype>();

        public ICollection<Ability> Abilities { get; } = new Collection<Ability>();

        public int? Power { get; set; }

#pragma warning disable CA2227 // Collection properties should be read only
        public ICollection<Civilization> Civilizations { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

        public int ManaCost { get; set; }

        public bool Tapped { get; set; }

        public bool ShieldTrigger { get; set; } = false;

        internal bool ShieldTriggerPending { get; set; } = false;

        public ICollection<Guid> RevealedTo { get; internal set; } = new List<Guid>();

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
            ShieldTriggerPending = card.ShieldTriggerPending;
            Subtypes = card.Subtypes?.ToList();
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

        public virtual void EnterManaZone()
        {
            if (Civilizations.Count > 1)
            {
                Tapped = true;
            }
        }

        /// <summary>
        /// Initializes the sources and controllers of all abilities and related abstractions of the card.
        /// </summary>
        public void InitializeAbilities()
        {
            foreach (var ability in Abilities)
            {
                ability.Controller = Owner;
                ability.Owner = Owner;
                ability.Source = Id;
                if (ability is StaticAbility staticAbility)
                {
                    foreach (var effect in staticAbility.ContinuousEffects)
                    {
                        effect.Controller = Owner;
                        foreach (var filter in effect.Filters)
                        {
                            filter.Owner = Owner;
                            filter.Target = Id;
                        }
                    }
                }
                else if (ability is ResolvableAbility resolvable)
                {
                    resolvable.Resolvable.Controller = Owner;
                    resolvable.Resolvable.Source = Id;
                }
            }
        }
    }

    public class CardComparer : IEqualityComparer<Card>
    {
        public bool Equals(Card x, Card y)
        {
            return
                //x.Abilities.SequenceEqual(y.Abilities) &&
                x.Abilities.Count == y.Abilities.Count && //TODO: Abilities should be compared precisely
                x.CardType == y.CardType &&
                x.Civilizations.SequenceEqual(y.Civilizations) &&
                x.ManaCost == y.ManaCost &&
                x.Name == y.Name &&
                x.Owner == y.Owner &&
                x.Power == y.Power &&
                x.RevealedTo.SequenceEqual(y.RevealedTo) &&
                x.ShieldTrigger == y.ShieldTrigger &&
                x.ShieldTriggerPending == y.ShieldTriggerPending &&
                ((x.Subtypes == null && y.Subtypes == null) || x.Subtypes.SequenceEqual(y.Subtypes)) &&
                x.Tapped == y.Tapped;
        }

        public int GetHashCode(Card obj)
        {
            var x = 0;//obj.Civilizations.GetHashCode();
            var y = 0;// obj.StaticAbilities.GetHashCode();
            return obj.ManaCost + obj.Tapped.GetHashCode() + obj.ShieldTrigger.GetHashCode() + obj.ShieldTriggerPending.GetHashCode() + x + y;// + obj.StaticAbilities.Sum(x => x.GetHashCode());
        }
    }

    internal class CardsComparer : IEqualityComparer<IEnumerable<Card>>
    {
        public bool Equals(IEnumerable<Card> x, IEnumerable<Card> y)
        {
            return x.SequenceEqual(y, new CardComparer());
        }

        public int GetHashCode(IEnumerable<Card> obj)
        {
            var cardComparer = new CardComparer();
            return obj.Sum(x => cardComparer.GetHashCode(x));
        }
    }
}
