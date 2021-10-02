using DuelMastersModels.Abilities.Static;
using DuelMastersModels.Abilities.Triggered;
using DuelMastersModels.Cards;
using DuelMastersModels.Cards.Creatures;
using DuelMastersModels.Cards.Spells;
using System;
using System.Collections.Generic;

namespace Simulator
{
    internal static class CardFactory
    {
        static internal Dictionary<string, Func<Card>> Cards = new()
        {
            { AquaHulcus, () => CreateAquaHulcus() },
            { AquaSurfer, () => CreateAquaSurfer() },

            { BombazarDragonOfDestiny, () => CreateBombazarDragonOfDestiny() },
            { BronzeArmTribe, () => CreateBronzeArmTribe() },
            { BurningMane, () => new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 2, Name = BurningMane, Power = 2000, Subtypes = new List<Subtype> { Subtype.BeastFolk } } },

            { DeadlyFighterBraidClaw, () => CreateDeadlyFighterBraidClaw() },

            { Emeral, () => CreateEmeral() },
            { ExplosiveDudeJoe, () => new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 3, Name = ExplosiveDudeJoe, Power = 3000, Subtypes = new List<Subtype> { Subtype.Human } } },

            { FearFang, () => new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 3, Name = FearFang, Power = 3000, Subtypes = new List<Subtype> { Subtype.BeastFolk } } },
            
            { GontaTheWarriorSavage, () => new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire, Civilization.Nature }, ManaCost = 2, Name = GontaTheWarriorSavage, Power = 4000, Subtypes = new List<Subtype> { Subtype.Human, Subtype.BeastFolk } } },
            
            { HeartyCapnPolligon, () => CreateHeartyCapnPolligon() },

            { ImmortalBaronVorg, () => new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 2, Name = ImmortalBaronVorg, Power = 2000, Subtypes = new List<Subtype> { Subtype.Human } } },
            
            { KamikazeChainsawWarrior, () => new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 2, Name = KamikazeChainsawWarrior, Power = 1000, ShieldTrigger = true, Subtypes = new List<Subtype> { Subtype.Armorloid } } },
            
            { PyrofighterMagnus, () => CreatePyrofighterMagnus() },

            { QuixoticHeroSwineSnout, () => CreateQuixoticHeroSwineSnout() },

            { RikabuTheDismantler, () => CreateRikabuTheDismantler() },

            { SniperMosquito, () => CreateSniperMosquito() },
            { Soulswap, () => CreateSoulswap() },

            { Torcon, () => new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 2, Name = Torcon, Power = 1000, ShieldTrigger = true, Subtypes = new List<Subtype> { Subtype.BeastFolk } } },
            { TriHornShepherd, () => new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 5, Name = TriHornShepherd, Power = 5000, Subtypes = new List<Subtype> { Subtype.BeastFolk } } },
            { TwinCannonSkyterror, () => CreateTwinCannonSkyterror() },

            { WindAxeTheWarriorSavage, () => CreateWindAxeTheWarriorSavage() },
        };

        internal const string AquaHulcus = "Aqua Hulcus";
        internal const string AquaSurfer = "Aqua Surfer";
        internal const string BombazarDragonOfDestiny = "Bombazar, Dragon of Destiny";
        internal const string BronzeArmTribe = "Bronze-Arm Tribe";
        internal const string BurningMane = "Burning Mane";
        internal const string DeadlyFighterBraidClaw = "Deadly Fighter Braid Claw";
        internal const string Emeral = "Emeral";
        internal const string ExplosiveDudeJoe = "Explosive Dude Joe";
        internal const string FearFang = "Fear Fang";
        internal const string GontaTheWarriorSavage = "Gonta, the Warrior Savage";
        internal const string HeartyCapnPolligon = "Hearty Cap'n Polligon";
        internal const string ImmortalBaronVorg = "Immortal Baron, Vorg";
        internal const string KamikazeChainsawWarrior = "Kamikaze, Chainsaw Warrior";
        internal const string QuixoticHeroSwineSnout = "Quixotic Hero Swine Snout";
        internal const string PyrofighterMagnus = "Pyrofighter Magnus";
        internal const string RikabuTheDismantler = "Rikabu, the Dismantler";
        internal const string SniperMosquito = "Sniper Mosquito";
        internal const string Soulswap = "Soulswap";
        internal const string Torcon = "Torcon";
        internal const string TriHornShepherd = "Tri-Horn Shepherd";
        internal const string TwinCannonSkyterror = "Twin-Cannon Skyterror";
        internal const string WindAxeTheWarriorSavage = "Wind Axe, the Warrior Savage";

        static Card CreateAquaHulcus()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 3, Name = AquaHulcus, Power = 2000, Subtypes = new List<Subtype> { Subtype.LiquidPeople } };
            x.Abilities.Add(new AquaHulcusAbility());
            return x;
        }

        static Card CreateAquaSurfer()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 6, Name = AquaSurfer, Power = 2000, ShieldTrigger = true, Subtypes = new List<Subtype> { Subtype.LiquidPeople } };
            x.Abilities.Add(new AquaSurferAbility());
            return x;
        }

        static Card CreateBombazarDragonOfDestiny()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire, Civilization.Nature }, ManaCost = 7, Name = BombazarDragonOfDestiny, Power = 6000, Subtypes = new List<Subtype> { Subtype.ArmoredDragon, Subtype.EarthDragon } };
            x.Abilities.Add(new SpeedAttacker(x.Id));
            x.Abilities.Add(new DoubleBreaker(x.Id));
            x.Abilities.Add(new BombazarDragonOfDestinyAbility());
            return x;
        }

        static Card CreateBronzeArmTribe()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 3, Name = BronzeArmTribe, Power = 1000, Subtypes = new List<Subtype> { Subtype.BeastFolk } };
            x.Abilities.Add(new BronzeArmTribeAbility());
            return x;
        }

        static Card CreateDeadlyFighterBraidClaw()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 1, Name = DeadlyFighterBraidClaw, Power = 1000, Subtypes = new List<Subtype> { Subtype.Dragonoid } };
            x.Abilities.Add(new AttacksIfAbleAbility(x.Id));
            return x;
        }

        static Card CreateEmeral()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 2, Name = Emeral, Power = 1000, Subtypes = new List<Subtype> { Subtype.CyberLord } };
            x.Abilities.Add(new EmeralAbility());
            return x;
        }

        static Card CreateHeartyCapnPolligon()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 1, Name = HeartyCapnPolligon, Power = 2000, Subtypes = new List<Subtype> { Subtype.SnowFaerie } };
            x.Abilities.Add(new HeartyCapnPolligonAbility());
            return x;
        }

        static Card CreateQuixoticHeroSwineSnout()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 2, Name = QuixoticHeroSwineSnout, Power = 1000, Subtypes = new List<Subtype> { Subtype.BeastFolk } };
            x.Abilities.Add(new QuixoticHeroSwineSnoutAbility());
            //TODO: ability
            return x;
        }

        static Card CreatePyrofighterMagnus()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 3, Name = PyrofighterMagnus, Power = 3000, Subtypes = new List<Subtype> { Subtype.Dragonoid } };
            x.Abilities.Add(new SpeedAttacker(x.Id));
            x.Abilities.Add(new PyrofighterMagnusAbility());
            return x;
        }

        static Card CreateRikabuTheDismantler()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 3, Name = RikabuTheDismantler, Power = 1000, Subtypes = new List<Subtype> { Subtype.MachineEater } };
            x.Abilities.Add(new SpeedAttacker(x.Id));
            return x;
        }

        static Card CreateSniperMosquito()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 1, Name = SniperMosquito, Power = 2000, Subtypes = new List<Subtype> { Subtype.GiantInsect } };
            x.Abilities.Add(new SniperMosquitoAbility());
            return x;
        }

        static Card CreateSoulswap()
        {
            var x = new Card { CardType = CardType.Spell, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 3, Name = Soulswap };
            x.Abilities.Add(new SoulswapAbility());
            return x;
        }

        static Card CreateTwinCannonSkyterror()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 7, Name = TwinCannonSkyterror, Power = 7000, Subtypes = new List<Subtype> { Subtype.ArmoredWyvern } };
            x.Abilities.Add(new SpeedAttacker(x.Id));
            x.Abilities.Add(new DoubleBreaker(x.Id));
            return x;
        }

        static Card CreateWindAxeTheWarriorSavage()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire, Civilization.Nature }, ManaCost = 5, Name = WindAxeTheWarriorSavage, Power = 2000, Subtypes = new List<Subtype> { Subtype.Human, Subtype.BeastFolk } };
            x.Abilities.Add(new WindAxeTheWarriorSavageAbility());
            return x;
        }
    }
}
