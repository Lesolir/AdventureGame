using System;

namespace KeyQuest
{
    class Hero
    {
        private string name = "Hero";
        private int level = 1;
        private int xp = 0;
        private int health = 100;
        private int attack = 10;
        private int keys = 0;
        private int potion = 0;
        private int positionX = 1;
        private int positionY = 10;



        public Hero()
        {}



        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetName()
        {
            string name = this.name;
            return name;
        }
        public void SetLevel(int level)
        {
            this.level += level;
        }
        public int GetLevel()
        {
            int level = this.level;
            return level;
        }
        public void SetXP(int xpDrop)
        {
            this.xp += xpDrop;
        }
        public int GetXP()
        {
            int xp = this.xp;
            return xp;
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
        public void SetKeys(int keys)
        {
            this.keys += keys;
        }
        public int GetKeys()
        {
            int keys = this.keys;
            return keys;
        }
        public void SetPotion(int potion)
        {
            this.potion += potion;
        }
        public int GetPotion()
        {
            int potion = this.potion;
            return potion;
        }
        public void SetPositionX(int positionX)
        {
            if (positionX == -1)
                this.positionX--;
            else
                this.positionX++;
        }
        public int GetPositionX()
        {
            int positionX = this.positionX;
            return positionX;
        }
        public void SetPositionY(int positionY)
        {
            if(positionY == -1)
                this.positionY--;
            else
                this.positionY++;
        }
        public int GetPositionY()
        {
            int positionY = this.positionY;
            return positionY;
        }
    }
}
