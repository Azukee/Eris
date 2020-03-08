using System;

namespace ErisLib.Server.Packets.Models
{
    public class StatsType
    {
        public readonly static StatsType MaximumHP = 0;
        public readonly static StatsType HP = 1;
        public readonly static StatsType Size = 2;
        public readonly static StatsType MaximumMP = 3;
        public readonly static StatsType MP = 4;
        public readonly static StatsType NextLevelExperience = 5;
        public readonly static StatsType Experience = 6;
        public readonly static StatsType Level = 7;
        public readonly static StatsType Inventory0 = 8;
        public readonly static StatsType Inventory1 = 9;
        public readonly static StatsType Inventory2 = 10;
        public readonly static StatsType Inventory3 = 11;
        public readonly static StatsType Inventory4 = 12;
        public readonly static StatsType Inventory5 = 13;
        public readonly static StatsType Inventory6 = 14;
        public readonly static StatsType Inventory7 = 15;
        public readonly static StatsType Inventory8 = 16;
        public readonly static StatsType Inventory9 = 17;
        public readonly static StatsType Inventory10 = 18;
        public readonly static StatsType Inventory11 = 19;
        public readonly static StatsType Attack = 20;
        public readonly static StatsType Defense = 21;
        public readonly static StatsType Speed = 22;
        public readonly static StatsType Vitality = 26;
        public readonly static StatsType Wisdom = 27;
        public readonly static StatsType Dexterity = 28;
        public readonly static StatsType Effects = 29;
        public readonly static StatsType Stars = 30;
        public readonly static StatsType Name = 31; //Is UTF
        public readonly static StatsType Texture1 = 32;
        public readonly static StatsType Texture2 = 33;
        public readonly static StatsType MerchandiseType = 34;
        public readonly static StatsType Credits = 35;
        public readonly static StatsType MerchandisePrice = 36;
        public readonly static StatsType PortalUsable = 37; // "ACTIVE_STAT"
        public readonly static StatsType AccountId = 38; //Is UTF
        public readonly static StatsType AccountFame = 39;
        public readonly static StatsType MerchandiseCurrency = 40;
        public readonly static StatsType ObjectConnection = 41;
        /*
         * Mask :F0F0F0F0
         * each byte > type
         * 0:Dot
         * 1:ushortLine
         * 2:L
         * 3:Line
         * 4:T
         * 5:Cross
         * 0x21222112
        */
        public readonly static StatsType MerchandiseRemainingCount = 42;
        public readonly static StatsType MerchandiseRemainingMinutes = 43;
        public readonly static StatsType MerchandiseDiscount = 44;
        public readonly static StatsType MerchandiseRankRequirement = 45;
        public readonly static StatsType HealthBonus = 46;
        public readonly static StatsType ManaBonus = 47;
        public readonly static StatsType AttackBonus = 48;
        public readonly static StatsType DefenseBonus = 49;
        public readonly static StatsType SpeedBonus = 50;
        public readonly static StatsType VitalityBonus = 51;
        public readonly static StatsType WisdomBonus = 52;
        public readonly static StatsType DexterityBonus = 53;
        public readonly static StatsType OwnerAccountId = 54; //Is UTF
        public readonly static StatsType RankRequired = 55;
        public readonly static StatsType NameChosen = 56;
        public readonly static StatsType CharacterFame = 57;
        public readonly static StatsType CharacterFameGoal = 58;
        public readonly static StatsType Glowing = 59;
        public readonly static StatsType SinkLevel = 60;
        public readonly static StatsType AltTextureIndex = 61;
        public readonly static StatsType GuildName = 62; //Is UTF
        public readonly static StatsType GuildRank = 63;
        public readonly static StatsType OxygenBar = 64;
        public readonly static StatsType XpBoosterActive = 65;
        public readonly static StatsType XpBoostTime = 66;
        public readonly static StatsType LootDropBoostTime = 67;
        public readonly static StatsType LootTierBoostTime = 68;
        public readonly static StatsType HealthPotionCount = 69;
        public readonly static StatsType MagicPotionCount = 70;
        public readonly static StatsType Backpack0 = 71;
        public readonly static StatsType Backpack1 = 72;
        public readonly static StatsType Backpack2 = 73;
        public readonly static StatsType Backpack3 = 74;
        public readonly static StatsType Backpack4 = 75;
        public readonly static StatsType Backpack5 = 76;
        public readonly static StatsType Backpack6 = 77;
        public readonly static StatsType Backpack7 = 78;
        public readonly static StatsType HasBackpack = 79;
        public readonly static StatsType Skin = 80;
        public readonly static StatsType PetInstanceId = 81;
        public readonly static StatsType PetName = 82; //Is UTF
        public readonly static StatsType PetType = 83;
        public readonly static StatsType PetRarity = 84;
        public readonly static StatsType PetMaximumLevel = 85;
        public readonly static StatsType PetFamily = 86; //This does do nothing in the client
        public readonly static StatsType PetPoints0 = 87;
        public readonly static StatsType PetPoints1 = 88;
        public readonly static StatsType PetPoints2 = 89;
        public readonly static StatsType PetLevel0 = 90;
        public readonly static StatsType PetLevel1 = 91;
        public readonly static StatsType PetLevel2 = 92;
        public readonly static StatsType PetAbilityType0 = 93;
        public readonly static StatsType PetAbilityType1 = 94;
        public readonly static StatsType PetAbilityType2 = 95;
        public readonly static StatsType Effects2 = 96; // Used for things like Curse, Petrify etc...
        public readonly static StatsType FortuneTokens = 97;

        private byte m_type;

        private StatsType(byte type)
        {
            this.m_type = type;
        }

        public bool IsUTF()
        {
            if (this == StatsType.Name || this == StatsType.AccountId || this == StatsType.OwnerAccountId
               || this == StatsType.GuildName || this == StatsType.PetName)
                return true;
            return false;
        }

        public static implicit operator StatsType(int type)
        {
            if (type > byte.MaxValue) throw new Exception("Not a valid StatData number.");
            return new StatsType((byte)type);
        }

        public static implicit operator StatsType(byte type)
        {
            return new StatsType(type);
        }

        public static bool operator ==(StatsType type, int id)
        {
            if (id > byte.MaxValue) throw new Exception("Not a valid StatData number.");
            return type.m_type == (byte)id;
        }

        public static bool operator ==(StatsType type, byte id)
        {
            return type.m_type == id;
        }

        public static bool operator !=(StatsType type, int id)
        {
            if (id > byte.MaxValue) throw new Exception("Not a valid StatData number.");
            return type.m_type != (byte)id;
        }

        public static bool operator !=(StatsType type, byte id)
        {
            return type.m_type != id;
        }

        public static bool operator ==(StatsType type, StatsType id)
        {
            return type.m_type == id.m_type;
        }

        public static bool operator !=(StatsType type, StatsType id)
        {
            return type.m_type != id.m_type;
        }

        public static implicit operator int(StatsType type)
        {
            return type.m_type;
        }

        public static implicit operator byte(StatsType type)
        {
            return type.m_type;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is StatsType)) return false;
            return this == (StatsType)obj;
        }
        public override string ToString()
        {
            return m_type.ToString();
        }
    }
}