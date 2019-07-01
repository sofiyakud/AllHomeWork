using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DOTA2project
{
    class Item
    {
        public string name;
        public int health;
        public int strikePower;
        public int strength;
        public int agility;
        public int intelligence;

        public Item(string p_name, int p_health, int p_strikePower, int p_strength, int p_agility, int p_intelligence)//конструктор итемов
        {
            name = p_name;
            health = p_health;
            strikePower = p_strikePower;
            strength = p_strength;
            agility = p_agility;
            intelligence = p_intelligence;
        }
    }

    class Hero
    {
        private string name;
        private int health;
        protected int strikePower;
        protected int strength;
        protected int agility;
        protected int intelligence;
        protected Hero target; //цель - другой игрок
        private bool isDead;
        private string deadPhrase;


        private List<Item> listItems;

        public Hero(string p_name, int p_health, int p_strikePower, int p_strength, int p_agility, int p_intelligence, string p_deadPhrase, Item weaponItem, Item armorItem)
        {
            name = p_name;
            health = p_health;
            strikePower = p_strikePower;
            strength = p_strength;
            agility = p_agility;
            intelligence = p_intelligence;
            deadPhrase = p_deadPhrase;
            target = null;
            isDead = false;

            listItems = new List<Item>();
            this.AddItem(weaponItem);
            this.AddItem(armorItem);
        }

        public virtual void Attack()
        {
            Console.WriteLine("Player " + name + " attack to " + target.name + " strength=" + strength);
        }

        public void TakeDamage(int p_strength)
        {
            Console.WriteLine("Player " + name + " TakeDamage:" + p_strength);
            health -= p_strength;
            health = health > 0 ? health : 0;
            isDead = health == 0;

            Console.WriteLine("Player " + name + " HP:" + health);
            if (isDead)
            {
                Console.ForegroundColor = ConsoleColor.Red;//устанавливаю цвет    
                Console.WriteLine("Player " + name + " is DEAD..... " + deadPhrase);
            }
        }

        public void getHeroInfo()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;//устанавливаю цвет
            Console.WriteLine("Hero is : " + name + " HP : " + health + " Strike power hero: " + strikePower + " Agility : " + agility + " Strenght : " + strength + " Intelligence : " + intelligence);
            foreach (Item item in listItems)
                Console.WriteLine("   item : " + item.name + " HP : " + item.health + " Strike power hero: " + item.strikePower + " Agility : " + item.agility + " Strenght : " + item.strength + " Intelligence : " + item.intelligence);
            Console.WriteLine("");
            Console.ResetColor();//сбрасываю цвет в стандартный
        }

        public void AddItem(Item item)
        {
            listItems.Add(item);

            health += item.health;
            strikePower += item.strikePower;
            strength += item.strength;
            agility += item.agility;
            intelligence += item.intelligence;
        }

        public string GetName()
        {
            return name;
        }

        public bool GetIsDead()
        {
            return isDead;
        }

        public Hero GetTarget()
        {
            return target;
        }

        public void SetTarget(Hero hero)
        {
            target = hero;
        }
    }

    //рыцарь
    class Swordman : Hero
    {
        public Swordman(string p_name, int p_health, int p_strikePower, int p_strength, string p_deadPhrase, Item weaponItem, Item armorItem) : base(p_name, p_health, p_strikePower, p_strength, 0, 0, p_deadPhrase, weaponItem, armorItem)
        {
        }

        public override void Attack()
        {
            base.Attack();
            target?.TakeDamage(strikePower * strength);
        }
    }

    //лучник
    class Archer : Hero
    {
        public Archer(string p_name, int p_health, int p_strikePower, int p_agility, string p_deadPhrase, Item weaponItem, Item armorItem) : base(p_name, p_health, p_strikePower, 0, p_agility, 0, p_deadPhrase, weaponItem, armorItem)
        {
        }

        public override void Attack()
        {
            base.Attack();
            target?.TakeDamage(strikePower * agility);
        }
    }

    // маг
    class Wizard : Hero
    {
        public Wizard(string p_name, int p_health, int p_strikePower, int p_intelligence, string p_deadPhrase, Item weaponItem, Item armorItem) : base(p_name, p_health, p_strikePower, 0, 0, p_intelligence, p_deadPhrase, weaponItem, armorItem)
        {
        }

        public override void Attack()
        {
            base.Attack();
            target?.TakeDamage(strikePower * intelligence);
        }
    }

    class Manager//ядро
    {
        public List<Hero> listHiro;
        public List<Hero> listPlayers;

        public List<Item> listWeaponItem;
        public List<Item> listArmorItem;

        private Random rand;

        public void Init()
        {
            rand = new Random();

            listWeaponItem = new List<Item>();
            listWeaponItem.Add(new Item("Battle Fury", 5, 3, 5, 5, 0));
            listWeaponItem.Add(new Item("Radiance", 5, 0, 5, 3, 5));
            listWeaponItem.Add(new Item("Monkey King Bar", 5, 5, 1, 5, 5));
            listWeaponItem.Add(new Item("Desolator", 5, 0, 5, 5, 5));
            listWeaponItem.Add(new Item("Daedalus", 2, 5, 5, 5, 5));

            listArmorItem = new List<Item>();
            listArmorItem.Add(new Item("Lotus Orb", 5, 5, 3, 5, 0));
            listArmorItem.Add(new Item("Vanguard", 5, 0, 5, 1, 5));
            listArmorItem.Add(new Item("Bloodstone", 5, 6, 3, 2, 1));

            listHiro = new List<Hero>();
            listHiro.Add(new Swordman("WEAWER", 2500, 50, 5, "The pattern unravels, eh heh.", GetRandomItem(listWeaponItem), GetRandomItem(listArmorItem)));
            listHiro.Add(new Wizard("TREANTPROTECTOR", 3000, 50, 5, "Now come the axes and the fire....", GetRandomItem(listWeaponItem), GetRandomItem(listArmorItem)));
            listHiro.Add(new Swordman("PUCK", 3000, 50, 5, "The greatest tragedy of our eon.", GetRandomItem(listWeaponItem), GetRandomItem(listArmorItem)));
            listHiro.Add(new Wizard("WINDRANGER", 4000, 50, 5, "An ill wind blows...", GetRandomItem(listWeaponItem), GetRandomItem(listArmorItem)));
            listHiro.Add(new Archer("BRISTLEBACK", 3500, 50, 5, "Send my needles to mom ...", GetRandomItem(listWeaponItem), GetRandomItem(listArmorItem)));
            listHiro.Add(new Archer("Enigma", 1000, 50, 5, "Disharmony reigns", GetRandomItem(listWeaponItem), GetRandomItem(listArmorItem)));

            listPlayers = new List<Hero>();
            listPlayers.Add(this.GetRandomPlayer());
            listPlayers.Add(this.GetRandomPlayer());

            foreach (Hero player in listPlayers)
                player.getHeroInfo();

            this.SetTargets();
        }

        public void Run()//игровой процесс файтинг
        {
            Console.ForegroundColor = ConsoleColor.Yellow;//устанавливаю цвет
            Console.Write("Loading");//типа загрузка игры
            for (int i = 0; i < 10; i++)
            {
                Console.Write(".");
                Thread.Sleep(500);
            }
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;//устанавливаю цвет
            Console.WriteLine("\nBATTLE START");//начало файтинга

            while (listPlayers.Count > 1)
            {
                foreach (Hero player in listPlayers)
                    if (!player.GetIsDead())
                    {
                        player.Attack();
                        Thread.Sleep(2000);
                    }

                for (int index = listPlayers.Count - 1; index >= 0; index--)
                    if (listPlayers[index].GetIsDead())
                        listPlayers.RemoveAt(index);
            }
            Console.ForegroundColor = ConsoleColor.Green;//устанавливаю цвет
            Console.WriteLine("Winner is " + listPlayers[0].GetName());
            Console.ReadLine();
        }

        private Hero GetRandomPlayer()
        {
            int randIndex = rand.Next(listHiro.Count);

            Hero randHiro = listHiro[randIndex];
            listHiro.RemoveAt(randIndex);

            return randHiro;
        }

        private Item GetRandomItem(List<Item> listItem)
        {
            int randIndex = rand.Next(listItem.Count);
            return listItem[randIndex];
        }

        private void SetTargets()
        {
            foreach (Hero player in listPlayers)
                foreach (Hero targetPlayer in listPlayers)
                    if (player.GetName() != targetPlayer.GetName())
                        player.SetTarget(targetPlayer);

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("DOTA 2");
            Manager manager = new Manager();
            manager.Init();
            manager.Run();
        }
    }

}
