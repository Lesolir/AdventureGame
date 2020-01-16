using System;

namespace KeyQuest
{
    public class CellSave
    {
        public string landType { get; set; }
        public int mobs { get; set; }
        public Mob[] mob { get; set; } = new Mob[3];
        public int key { get; set; }
        public int potion { get; set; }
        public int visited { get; set; }


        public CellSave()
        { }


        public void SetLandType()
        {
            string landType = "";
            Random random = new Random();
            int land = random.Next(0, 26);
            switch (land)
            {
                case 0:
                    landType = "a forrest";
                    break;
                case 1:
                    landType = "a cave";
                    break;
                case 2:
                    landType = "the marshes";
                    break;
                case 3:
                    landType = "the tundra";
                    break;
                case 4:
                    landType = "the mountains";
                    break;
                case 5:
                    landType = "the dessert";
                    break;
                case 6:
                    landType = "a dark wood";
                    break;
                case 7:
                    landType = "a ravine";
                    break;
                case 8:
                    landType = "the snowy mountains";
                    break;
                case 9:
                    landType = "the steppes";
                    break;
                case 10:
                    landType = "an abandoned mine";
                    break;
                case 11:
                    landType = "an old fortress";
                    break;
                case 12:
                    landType = "a swamp";
                    break;
                case 13:
                    landType = "a haunted village";
                    break;
                case 14:
                    landType = "a friendy village";
                    break;
                case 15:
                    landType = "a town";
                    break;
                case 16:
                    landType = "a city";
                    break;
                case 17:
                    landType = "a great capital";
                    break;
                case 18:
                    landType = "a silent castle";
                    break;
                case 19:
                    landType = "a farm";
                    break;
                case 20:
                    landType = "the green hills";
                    break;
                case 21:
                    landType = "a graveyard";
                    break;
                case 22:
                    landType = "an evil ruin";
                    break;
                case 23:
                    landType = "a ruin";
                    break;
                case 24:
                    landType = "the cliffs by the ocean";
                    break;
                case 25:
                    landType = "a lake";
                    break;
            }
            this.landType = landType;
        }
        public string GetLandType()
        {
            string landType = this.landType;
            return landType;
        }
        public void SetMob()
        {
            Mob[] mobs = new Mob[this.mobs];
            
            for (int i = 0; i < this.mobs; i++)
            {
                mobs[i] = new Mob();
                mobs[i].SetName();
                mobs[i].SetPotionDrop();
                this.mob[i] = mobs[i];
            }

        }
        public void SetMobs(int mobs)
        {
            this.mobs = mobs;
        }
        public int GetMobs()
        {
            int mobs = this.mobs;
            return mobs;
        }
        public Mob GetMob(int i)
        {
            mob[i] = this.mob[i];
            return mob[i];
        }
        public string GetMobName(int i)
        {
            string mobName = mob[i].GetName();
            return mobName;
        }
        public void SetMobHealth(int mobHealth, ref int i)
        {
            mob[i].SetHealth(mobHealth);
        }
        public int GetMobHealth(int i)
        {
            int mobHealth = mob[i].GetHealth();
            return mobHealth;
        }
        public int GetMobPotionDrop(int i)
        {
            int mobPotionDrop = mob[i].GetPotionDrop();
            return mobPotionDrop;
        }
        public int GetXPDrop(int i)
        {
            int mobXPDrop = mob[i].GetXPDrop();
            return mobXPDrop;
        }
        public void SetKey(int key)
        {
            this.key = key;
        }
        public int GetKey()
        {
            int key = this.key;
            return key;
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
        public void SetVisited(int visited)
        {
            this.visited = visited;
        }
        public int GetVisited()
        {
            int visited = this.visited;
            return visited;
        }
    }
}