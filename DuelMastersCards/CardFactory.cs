using DuelMastersCards.Resolvables;
using DuelMastersCards.StaticAbilities;
using DuelMastersCards.TriggeredAbilities;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DuelMastersCards
{
    public static class CardFactory
    {
        static public Card Create(string name)
        {
            return _cards[name].Invoke();
        }

        static public IEnumerable<Card> CreateAll()
        {
            return _cards.Select(x => x.Value.Invoke());
        }

        #region Card names
        const string AquaHulcus = "Aqua Hulcus";
        const string AquaSurfer = "Aqua Surfer";

        const string BombazarDragonOfDestiny = "Bombazar, Dragon of Destiny";
        const string BronzeArmTribe = "Bronze-Arm Tribe";
        const string BurningMane = "Burning Mane";

        const string CraniumClamp = "Cranium Clamp";

        const string DeadlyFighterBraidClaw = "Deadly Fighter Braid Claw";

        const string Emeral = "Emeral";

        const string ExplosiveDudeJoe = "Explosive Dude Joe";

        const string FearFang = "Fear Fang";

        const string GhostTouch = "Ghost Touch";
        const string Gigabalza = "Gigabalza";
        const string GontaTheWarriorSavage = "Gonta, the Warrior Savage";

        const string HeartyCapnPolligon = "Hearty Cap'n Polligon";
        const string HolyAwe = "Holy Awe";
        const string HorridWorm = "Horrid Worm";

        const string ImmortalBaronVorg = "Immortal Baron, Vorg";

        const string KamikazeChainsawWarrior = "Kamikaze, Chainsaw Warrior";

        const string Locomotiver = "Locomotiver";

        const string MagrisVizierOfMagnetism = "Magris, Vizier of Magnetism";
        const string MistRiasSonicGuardian = "Mist Rias, Sonic Guardian";

        const string QuixoticHeroSwineSnout = "Quixotic Hero Swine Snout";

        const string PyrofighterMagnus = "Pyrofighter Magnus";

        const string RikabuTheDismantler = "Rikabu, the Dismantler";

        const string SniperMosquito = "Sniper Mosquito";
        const string Soulswap = "Soulswap";
        const string SupersonicJetPack = "Supersonic Jet Pack";

        const string TerrorPit = "Terror Pit";
        const string Torcon = "Torcon";
        const string TriHornShepherd = "Tri-Horn Shepherd";
        const string TwinCannonSkyterror = "Twin-Cannon Skyterror";

        const string WindAxeTheWarriorSavage = "Wind Axe, the Warrior Savage";
        const string WindmillMutant = "Windmill Mutant";
        #endregion Card names

        static readonly private Dictionary<string, Func<Card>> _cards = new()
        {
            { AquaHulcus, () => CreateAquaHulcus() },
            { AquaSurfer, () => CreateAquaSurfer() },

            { BombazarDragonOfDestiny, () => CreateBombazarDragonOfDestiny() },
            { BronzeArmTribe, () => CreateBronzeArmTribe() },
            { BurningMane, () => new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 2, Name = BurningMane, Power = 2000, Subtypes = new List<Subtype> { Subtype.BeastFolk } } },

            { CraniumClamp, () => CreateCraniumClamp() },

            { DeadlyFighterBraidClaw, () => CreateDeadlyFighterBraidClaw() },

            { Emeral, () => CreateEmeral() },
            { ExplosiveDudeJoe, () => new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 3, Name = ExplosiveDudeJoe, Power = 3000, Subtypes = new List<Subtype> { Subtype.Human } } },

            { FearFang, () => new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 3, Name = FearFang, Power = 3000, Subtypes = new List<Subtype> { Subtype.BeastFolk } } },

            { GhostTouch, () => CreateGhostTouch() },
            { Gigabalza, () => CreateGigabalza() },
            { GontaTheWarriorSavage, () => new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire, Civilization.Nature }, ManaCost = 2, Name = GontaTheWarriorSavage, Power = 4000, Subtypes = new List<Subtype> { Subtype.Human, Subtype.BeastFolk } } },
            
            { HeartyCapnPolligon, () => CreateHeartyCapnPolligon() },
            { HolyAwe, () => CreateHolyAwe() },
            { HorridWorm, () => CreateHorridWorm() },

            { ImmortalBaronVorg, () => new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 2, Name = ImmortalBaronVorg, Power = 2000, Subtypes = new List<Subtype> { Subtype.Human } } },
            
            { KamikazeChainsawWarrior, () => new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 2, Name = KamikazeChainsawWarrior, Power = 1000, ShieldTrigger = true, Subtypes = new List<Subtype> { Subtype.Armorloid } } },

            { Locomotiver, () => CreateLocomotiver() },

            { MagrisVizierOfMagnetism, () => CreateMagrisVizierOfMagnetism() },
            { MistRiasSonicGuardian, () => CreateMistRiasSonicGuardian() },

            { PyrofighterMagnus, () => CreatePyrofighterMagnus() },

            { QuixoticHeroSwineSnout, () => CreateQuixoticHeroSwineSnout() },

            { RikabuTheDismantler, () => CreateRikabuTheDismantler() },

            { SniperMosquito, () => CreateSniperMosquito() },
            { Soulswap, () => CreateSoulswap() },
            { SupersonicJetPack, () => CreateSupersonicJetPack() },

            { TerrorPit, () => CreateTerrorPit() },
            { Torcon, () => new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 2, Name = Torcon, Power = 1000, ShieldTrigger = true, Subtypes = new List<Subtype> { Subtype.BeastFolk } } },
            { TriHornShepherd, () => new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 5, Name = TriHornShepherd, Power = 5000, Subtypes = new List<Subtype> { Subtype.BeastFolk } } },
            { TwinCannonSkyterror, () => CreateTwinCannonSkyterror() },

            { WindAxeTheWarriorSavage, () => CreateWindAxeTheWarriorSavage() },
            { WindmillMutant, () => CreateWindmillMutant() },
        };

        static Card CreateAquaHulcus()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 3, Name = AquaHulcus, Power = 2000, Subtypes = new List<Subtype> { Subtype.LiquidPeople } };
            x.Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new ControllerMayDrawCardResolvable()));
            return x;
        }

        static Card CreateAquaSurfer()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 6, Name = AquaSurfer, Power = 2000, ShieldTrigger = true, Subtypes = new List<Subtype> { Subtype.LiquidPeople } };
            x.Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new AquaSurferResolvable()));
            return x;
        }

        static Card CreateBombazarDragonOfDestiny()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire, Civilization.Nature }, ManaCost = 7, Name = BombazarDragonOfDestiny, Power = 6000, Subtypes = new List<Subtype> { Subtype.ArmoredDragon, Subtype.EarthDragon } };
            x.Abilities.Add(new SpeedAttackerAbility());
            x.Abilities.Add(new DoubleBreakerAbility());
            x.Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new BombazarDragonOfDestinyResolvable()));
            return x;
        }

        static Card CreateBronzeArmTribe()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 3, Name = BronzeArmTribe, Power = 1000, Subtypes = new List<Subtype> { Subtype.BeastFolk } };
            x.Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new BronzeArmTribeResolvable()));
            return x;
        }

        static Card CreateCraniumClamp()
        {
            var x = new Card { CardType = CardType.Spell, Civilizations = new List<Civilization> { Civilization.Darkness }, ManaCost = 4, Name = CraniumClamp };
            x.Abilities.Add(new SpellAbility(new CraniumClampResolvable()));
            return x;
        }

        static Card CreateDeadlyFighterBraidClaw()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 1, Name = DeadlyFighterBraidClaw, Power = 1000, Subtypes = new List<Subtype> { Subtype.Dragonoid } };
            x.Abilities.Add(new AttacksIfAbleAbility());
            return x;
        }

        static Card CreateEmeral()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Water }, ManaCost = 2, Name = Emeral, Power = 1000, Subtypes = new List<Subtype> { Subtype.CyberLord } };
            x.Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new EmeralResolvable()));
            return x;
        }

        static Card CreateGhostTouch()
        {
            var x = new Card { CardType = CardType.Spell, Civilizations = new List<Civilization> { Civilization.Darkness }, ManaCost = 2, Name = GhostTouch, ShieldTrigger = true };
            x.Abilities.Add(new SpellAbility(new OpponentRandomDiscardResolvable()));
            return x;
        }

        static Card CreateGigabalza()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Darkness }, ManaCost = 4, Name = Gigabalza, Power = 1000, ShieldTrigger = true, Subtypes = new List<Subtype> { Subtype.Chimera } };
            x.Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OpponentRandomDiscardResolvable()));
            return x;
        }

        static Card CreateHeartyCapnPolligon()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 1, Name = HeartyCapnPolligon, Power = 2000, Subtypes = new List<Subtype> { Subtype.SnowFaerie } };
            x.Abilities.Add(new HeartyCapnPolligonAbility(new HeartyCapnPolligonResolvable()));
            return x;
        }

        static Card CreateHolyAwe()
        {
            var x = new Card { CardType = CardType.Spell, Civilizations = new List<Civilization> { Civilization.Light }, ManaCost = 6, Name = HolyAwe, ShieldTrigger = true };
            x.Abilities.Add(new SpellAbility(new HolyAweResolvable()));
            return x;
        }

        static Card CreateHorridWorm()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Darkness }, ManaCost = 3, Name = HorridWorm, Power = 2000, Subtypes = new List<Subtype> { Subtype.ParasiteWorm } };
            x.Abilities.Add(new WheneverThisCreatureAttacksAbility(new OpponentRandomDiscardResolvable()));
            return x;
        }

        static Card CreateLocomotiver()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Darkness }, ManaCost = 4, Name = Locomotiver, Power = 1000, ShieldTrigger = true, Subtypes = new List<Subtype> { Subtype.Hedrian } };
            x.Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OpponentRandomDiscardResolvable()));
            return x;
        }

        static Card CreateMagrisVizierOfMagnetism()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Light }, ManaCost = 4, Name = MagrisVizierOfMagnetism, Power = 3000, Subtypes = new List<Subtype> { Subtype.Initiate } };
            x.Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new ControllerMayDrawCardResolvable()));
            return x;
        }

        static Card CreateMistRiasSonicGuardian()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Light }, ManaCost = 5, Name = MistRiasSonicGuardian, Power = 2000, Subtypes = new List<Subtype> { Subtype.Guardian } };
            x.Abilities.Add(new AnotherCreaturePutIntoBattleZoneAbility(new ControllerMayDrawCardResolvable()));
            return x;
        }

        static Card CreateQuixoticHeroSwineSnout()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 2, Name = QuixoticHeroSwineSnout, Power = 1000, Subtypes = new List<Subtype> { Subtype.BeastFolk } };
            x.Abilities.Add(new AnotherCreaturePutIntoBattleZoneAbility(new QuixoticHeroSwineSnoutResolvable()));
            return x;
        }

        static Card CreatePyrofighterMagnus()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 3, Name = PyrofighterMagnus, Power = 3000, Subtypes = new List<Subtype> { Subtype.Dragonoid } };
            x.Abilities.Add(new SpeedAttackerAbility());
            x.Abilities.Add(new AtTheEndOfYourTurnAbility(new PyrofighterMagnusResolvable()));
            return x;
        }

        static Card CreateRikabuTheDismantler()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 3, Name = RikabuTheDismantler, Power = 1000, Subtypes = new List<Subtype> { Subtype.MachineEater } };
            x.Abilities.Add(new SpeedAttackerAbility());
            return x;
        }

        static Card CreateSniperMosquito()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 1, Name = SniperMosquito, Power = 2000, Subtypes = new List<Subtype> { Subtype.GiantInsect } };
            x.Abilities.Add(new WheneverThisCreatureAttacksAbility(new SniperMosquitoResolvable()));
            return x;
        }

        static Card CreateSoulswap()
        {
            var x = new Card { CardType = CardType.Spell, Civilizations = new List<Civilization> { Civilization.Nature }, ManaCost = 3, Name = Soulswap, ShieldTrigger = true };
            x.Abilities.Add(new SpellAbility(new SoulswapResolvable()));
            return x;
        }

        static Card CreateSupersonicJetPack()
        {
            var x = new Card { CardType = CardType.Spell, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 1, Name = SupersonicJetPack };
            x.Abilities.Add(new SpellAbility(new SupersonicJetPackResolvable()));
            return x;
        }

        static Card CreateTerrorPit()
        {
            var x = new Card { CardType = CardType.Spell, Civilizations = new List<Civilization> { Civilization.Darkness }, ManaCost = 6, Name = TerrorPit, ShieldTrigger = true };
            x.Abilities.Add(new SpellAbility(new TerrorPitResolvable()));
            return x;
        }

        static Card CreateTwinCannonSkyterror()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire }, ManaCost = 7, Name = TwinCannonSkyterror, Power = 7000, Subtypes = new List<Subtype> { Subtype.ArmoredWyvern } };
            x.Abilities.Add(new SpeedAttackerAbility());
            x.Abilities.Add(new DoubleBreakerAbility());
            return x;
        }

        static Card CreateWindAxeTheWarriorSavage()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Fire, Civilization.Nature }, ManaCost = 5, Name = WindAxeTheWarriorSavage, Power = 2000, Subtypes = new List<Subtype> { Subtype.Human, Subtype.BeastFolk } };
            x.Abilities.Add(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new WindAxeTheWarriorSavageResolvable()));
            return x;
        }

        static Card CreateWindmillMutant()
        {
            var x = new Card { CardType = CardType.Creature, Civilizations = new List<Civilization> { Civilization.Darkness }, ManaCost = 3, Name = WindmillMutant, Power = 2000, Subtypes = new List<Subtype> { Subtype.Hedrian } };
            x.Abilities.Add(new WheneverThisCreatureAttacksAbility(new OpponentRandomDiscardResolvable()));
            return x;
        }
    }
}
