using System;

namespace KeyQuest
{
    public class Mob
    {
        public string name { get; set; } = "";
        public int health { get; set; } = 10;
        public int attack { get; set; } = 10;
        public int potionDrop { get; set; } = 0;
        public int xpDrop {get; set; } = 10;

        
        public Mob()
        {}


        public void SetName()
        {
            string name = "";
            Random random = new Random();
            int nameRand = random.Next(0,18);

            switch(nameRand)
            {
                case 0:
                    name = "an ugly monster";
                    break;
                case 1:
                    name = "a minion";
                    break;
                case 2:
                    name = "a goblin";
                    break;
                case 3:
                    name = "a wolf";
                    break;
                case 4:
                    name = "an old lady with a handbag";
                    break;
                case 5:
                    name = "a troll";
                    break;
                case 6:
                    name = "a grothmorg";
                    break;
                case 7:
                    name = "an orc";
                    break;
                case 8:
                    name = "a balrog";
                    break;
                case 9:
                    name = "a were-rabbit";
                    break;
                case 10:
                    name = "a giant spider";
                    break;
                case 11:
                    name = "a big green snake";
                    break;
                case 12:
                    name = "a fallen warrior";
                    break;
                case 13:
                    name = "a crazy cat-lady";
                    break;
                case 14:
                    name = "an assassin";
                    break;
                case 15:
                    name = "a dark shadow";
                    break;
                case 16:
                    name = "an evil sorcerer";
                    break;
                case 17:
                    name = "an uruk-hai";
                    break;
            }
            this.name = name;
        }
        public string GetName()
        {
            string name = this.name;
            return name;
        }
        public void SetHealth(int health)
        {
            this.health = health;
        }
        public int GetHealth()
        {
            int health = this.health;
            return health;
        }
        public void SetAttack(int attack)
        {
            this.attack = attack;
        }
        public int GetAttack()
        {
            int attack = this.attack;
            return attack;
        }
        public void SetPotionDrop()
        {
            Random random = new Random();
            int randPotionDrop = random.Next(0, 10);
            if(randPotionDrop == 5)
                this.potionDrop = 1;
        }
        public int GetPotionDrop()
        {
            int potionDrop = this.potionDrop;
            return potionDrop;
        }
        public int GetXPDrop()
        {
            int xpDrop = this.xpDrop;
            return xpDrop;
        }
    }
}
