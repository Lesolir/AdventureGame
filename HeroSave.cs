using System;

namespace KeyQuest
{
    class HeroSave
    {
        public string name {get; set; }
        public int level { get; set; }
        public int xp { get; set; }
        public int health { get; set; }
        public int attack { get; set; }
        public int keys { get; set; }
        public int potion { get; set; }
        public int positionX { get; set; }
        public int positionY { get; set; }

        public HeroSave()
        { 
            
        }



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
            this.level = level;
        }
        public int GetLevel()
        {
            int level = this.level;
            return level;
        }
        public void SetXP(int xpDrop)
        {
            this.xp = xpDrop;
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
            this.keys = keys;
        }
        public int GetKeys()
        {
            int keys = this.keys;
            return keys;
        }
        public void SetPotion(int potion)
        {
            this.potion = potion;
        }
        public int GetPotion()
        {
            int potion = this.potion;
            return potion;
        }
        public void SetPositionX(int positionX)
        {
            this.positionX = positionX;
        }
        public int GetPositionX()
        {
            int positionX = this.positionX;
            return positionX;
        }
        public void SetPositionY(int positionY)
        {
            this.positionY = positionY;
        }
        public int GetPositionY()
        {
            int positionY = this.positionY;
            return positionY;
        }
        public string GetSaveInfo()
        {
            string saveInfo = " || " + "Level: " + level + " || " + "Health: " + health + " || " + "Keys: " + keys + " || " + "Saved: " + DateTime.Now;
            return saveInfo;
        }
    }
}
