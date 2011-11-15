﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Digital_World.Helpers;

namespace Digital_World.Entities
{
    public enum CharacterModel : int
    {
        NULL = -1,
        Masaru  = 80001,
        Tohma,
        Yoshino,
        Ikuto
    }

    /// <summary>
    /// Character Class
    /// </summary>
    public class Character
    {
        public uint AccountId = 0;
        public uint CharacterId = 0;
        public uint intHandle = 0;
        public ItemList Equipment = new ItemList(27);
        public int Level = 1;
        public CharacterModel Model = CharacterModel.NULL;
        public string Name = string.Empty;
        public int lastChar = 0;

        public int MaxHP = 0;
        public int MaxDS = 0;
        public int HP = 0;
        public int DS = 0;
        public int AT = 0;
        public int DE = 0;
        public int EXP = 0;
        public int MS = 0;
        public int Fatigue = 0;

        public int InventorySize = 21;
        public int StorageSize = 21;
        public int ArchiveSize = 1;
        public ItemList Inventory = new ItemList(63);
        public ItemList Storage = new ItemList(70);
        public Position Location = new Position();

        public List<Digimon> DigimonList = new List<Digimon>();
        public QuestList Quests;

        /// <summary>
        /// The current active Digimon
        /// </summary>
        public Digimon Partner = null;

        public Character() {
            Equipment = new ItemList(27);
            Inventory = new ItemList(63);
            Storage = new ItemList(70);
            Quests = new QuestList();
        }

        public Character(uint AcctId, string charName, int charModel)
        {
            AccountId = AcctId;
            Name = charName;
            Model = (CharacterModel)charModel;
            Equipment = new ItemList(27);
            Inventory = new ItemList(63);
            Storage = new ItemList(70);
            Quests = new QuestList();
        }

        public override string ToString()
        {
            return string.Format("Tamer: Lv {1} {0}", Name, Level);
        }

        public uint ProperModel
        {
            get
            {
                uint iModel = 0x9C40A0;
                iModel += (((uint)Model - 80001) * 128);
                /*switch (Model)
                {
                    case CharacterModel.Masaru: //?? A0
                        {
                            iModel = -25536; //A0 40 9C
                            break;
                        }
                    case CharacterModel.Yoshino: //?? A0
                    case CharacterModel.Tohma: //?? 20
                        {
                            iModel = -25535; //20 41 9C
                            break;
                        }
                    case CharacterModel.Ikuto:
                        {
                            iModel = -25534;
                            break;
                        }
                }*/
                return (iModel << 8);
            }
        }

        public short MapHandle
        {
            get
            {
                byte[] b = new byte[] { (byte)((intHandle >> 24) & 0xFF), 0x20 };
                return BitConverter.ToInt16(b, 0);
            }
        }

        //public short hMap = 0;
    }
}