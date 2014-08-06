﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TXTGameOffWeb.Objects
{
    /*
     * 
     *              TO DO 
     *              
     *              Calculations of Accuracy, Attack vs Defence, Evasion and Health taken and dealt
     *              Experience table for player in order for the player to increase level | PlayerExp.txt
     *              Drop event (Random drops & Quest drops | Dropper)
     *              Health, Attack, Defence, Accuracy and Evasion training (May add it's own class | Training.cs)              
     * 
     */


    public class Battle : Player
    {
        private static int damageTaken;
        private static int damageDealt;
        private static int missTimes;
        private static int dodgeTimes;
        private static int critTimes;
        private static string victoryString = "You succsesfully defeated the monster.";
        private static string defeatString = "You failed to defeat the monster.";
        private static string msg;
        private static int dmgTaken;
        private static int dmgDealt;
        private static int mobCurrentHP;
        private static bool battleEnd;
        private static bool battleStarted;
        Player player = new Player();
        Monster mob = new Monster();

        public void BattleResult(string mobName)
        {
            int baseHP = player.Endurance * 5;
            if (this.BattleStarted == true)
            {
                this.BattleEnd = false;
                while (baseHP >= 1)
                {
                    while (mob.MonsterHealth >= 1)
                    {
                        CalculateDamageTaken(baseHP);
                        CalculateDameDealt();
                    }
                    if (mob.MonsterHealth <= 0)
                    {
                        this.SendMessage = victoryString;
                        this.BattleStarted = false;
                        mob.MonsterDestroy();
                        player.MonstersKilled++;
                        return;
                    }
                }

                if (baseHP <= 0)
                {
                    this.SendMessage = defeatString;
                    this.BattleStarted = false;
                }
            }
        }

        public void CalculateDamageTaken(int baseHP)
        {
            int mAttack = mob.MonsterAttack;

            if (this.BattleStarted == true)
            {
                mAttack -= player.Defence;

                dmgTaken = mAttack; //

                baseHP -= mAttack;

                DamageTaken = mAttack;
            }
        }

        public void CalculateDameDealt()
        {
            int pAttack = player.Attack;
            if (this.BattleStarted == true)
            {
                pAttack -= mob.MonsterDefence;
                dmgDealt = pAttack;

                mobCurrentHP = mob.MonsterHealth;

                mobCurrentHP -= pAttack;
                mob.MonsterHealth -= pAttack;

                DamageDealt = pAttack;
            }
        }

        public string SendMessage
        {
            get { return msg; }
            set { msg = value;}
        }

        public int DamageTaken
        {
            get { return dmgTaken; }
            set { dmgTaken = value; }
        }

        public int DamageDealt
        {
            get { return dmgDealt; }
            set { dmgDealt = value; }
        }

        public bool BattleEnd
        {
            get { return battleEnd; }
            set { battleEnd = value; }
        }

        public bool BattleStarted
        {
            get { return battleStarted; }
            set { battleStarted = value; }
        }
    }
}
