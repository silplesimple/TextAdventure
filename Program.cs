namespace TextAdventure
{
    
    internal class Program
    {
        
        
        public class Player
        {
            public virtual string Name { get; set; }//이름
            public int Level { get; set; }//레벨
            public string Chad { get; set; }//직업
            public virtual int AttackPower { get; set; }//공격력
            public virtual int Defense{  get; set; }//방어력
            public virtual int Health {  get; set; }//체력
            public virtual int Gold { get; set; }//골드
            
            public void PrintInfo()
            {
                Console.WriteLine("이름:" + Name);
                Console.WriteLine("Lv." + Level);
                Console.WriteLine("Chad(" + Chad+")");
                Console.WriteLine("공격력:" + AttackPower);
                Console.WriteLine("방어력:" + Defense);
                Console.WriteLine("체력:" + Health);
                Console.WriteLine("Gold:" + Gold+ "G");
            }
            
        }
        
       
        public class Item 
        {
            public int ItemIndex { get; set; }
            public string Name { get; set; }

            public string StatName { get; set; }
            public  int Stat {  get; set; }
            
            public string Manual {  get; set; }
            
            public int Gold { get; set; }

            public string CheckItem  {  get; set; }

            public string CheckBuyItem {  get; set; }
            public void MakeItem(int index,string name,string statName,int stat,string manual,int gold)
            {
                ItemIndex = index;
                Name = name;
                StatName = statName;
                Stat = stat;
                Manual = manual;
                Gold = gold;
            }
            public void HaveItem()
            {
                CheckItem = "[E]";
            }
            public void UnItem()
            {
                CheckItem = null;
            }
            public void Unbuy()
            {
                CheckBuyItem = $"{Gold} G";
            }
            public void Buy()
            {
                CheckBuyItem = "구매완료";
            }
            public void ItemStats()
            {
                Console.WriteLine($"-{CheckItem}{ItemIndex+1} {Name} |{StatName}+{Stat} | {Manual} ");
            }
            public void ShopItem()
            {
                Console.WriteLine($"-{Name} |{StatName}+{Stat} | {Manual} | {CheckBuyItem} ");
            }
            public void BuyItem()
            {
                Console.WriteLine($"-{ItemIndex + 1} {Name} |{StatName}+{Stat} | {Manual} | {CheckBuyItem}");
            }
            
        }         
        public static List<Item> items = new List<Item>();       
        
        static void StartText()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine("\n1.상태 보기");
            Console.WriteLine("2.인벤토리");
            Console.WriteLine("3.상점");
            
        }
        static void Exit(int outNumber)
        {
            Console.WriteLine("\n0.나가기");
            Console.WriteLine("\n원하시는 행동을 입력해주세요.\n>>");
            while (outNumber != 0)
            {
                outNumber = int.Parse(Console.ReadLine());
                if (outNumber != 0)
                {
                    Console.WriteLine("잘못된 숫자를 입력했습니다. 다시 입력해주세요");
                }

            }
        }
        static void Main(string[] args)
        {
            Player player = new Player();       //불러와서 정보를 입력한 것
            Item item1 = new Item(); 
            Item item2= new Item();
            item1.MakeItem(0,"무쇠갑옷","방어력",5,"무쇠로 만들어져 튼튼한 갑옷입니다.",1000);
            item2.MakeItem(1, "스파르타의 창", "공격력", 7, "스파르타의 전사들이 사용했다는 전설의 창입니다", 800);
            items.Add(item1);
            items.Add(item2);
            player.Level = 1;
            player.Chad = "전사";
            player.AttackPower = 10;
            player.Defense = 5;
            player.Health = 100;
            player.Gold = 2000;           
            Console.WriteLine("플레이어의 이름을 입력하세요");         
            player.Name = Console.ReadLine();
            int inputNumber; //진행 숫자            
            while (true)
            {
                StartText();
                Console.WriteLine("\n원하시는 행동을 입력해주세요.\n>>");
                inputNumber = int.Parse(Console.ReadLine());
                switch (inputNumber)
                {
                    case 1:
                        Console.WriteLine("상태보기입니다!");
                        player.PrintInfo();
                        Exit(inputNumber);
                        break;
                    case 2:                        
                        while (inputNumber != 0) {
                            Console.WriteLine("인벤토리입니다\n보유 중인 아이템을 관리할 수 있습니다.");
                            Console.WriteLine("\n[아이템 목록]");
                            foreach (Item item in items)
                            {
                                item.ItemStats();
                            }
                            Console.WriteLine("\n1.장착관리");
                            Console.WriteLine("\n0.나가기");
                            Console.WriteLine("\n원하시는 행동을 입력해주세요.\n>>");
                            inputNumber = int.Parse(Console.ReadLine());
                            if(inputNumber==1)
                            {
                                while (inputNumber != 0)
                                {
                                    Console.WriteLine("인벤토리입니다\n보유 중인 아이템을 관리할 수 있습니다.");
                                    Console.WriteLine("\n[아이템 목록]");
                                    foreach (Item item in items)
                                    {
                                        item.ItemStats();
                                    }                                    
                                    Console.WriteLine("\n0.나가기");
                                    Console.WriteLine("\n원하시는 행동을 입력해주세요.\n>>");
                                    inputNumber = int.Parse(Console.ReadLine());
                                    if (inputNumber == item1.ItemIndex+1)
                                    {
                                        if(item1.CheckItem==null)
                                        {
                                            item1.HaveItem();
                                            player.Defense += item1.Stat;
                                        }
                                        else
                                        {
                                            item1.UnItem();
                                            player.Defense -= item1.Stat;

                                        }    
                                        
                                    }
                                    else if(inputNumber==item2.ItemIndex+1)
                                    {
                                        if (item2.CheckItem == null)
                                        {
                                            item2.HaveItem();
                                            player.AttackPower += item2.Stat;
                                        }
                                        else
                                        {
                                            item2.UnItem();
                                            player.AttackPower -= item2.Stat;
                                        }
                                    }
                                    else if (inputNumber != 0)
                                    {
                                        Console.WriteLine("잘못된 숫자를 입력했습니다. 다시 입력해주세요");
                                    }
                                }
                            }
                            else if (inputNumber != 0)
                            {
                                Console.WriteLine("잘못된 숫자를 입력했습니다. 다시 입력해주세요");
                            }
                        }                
                        break;
                    case 3:
                        List<Item> itemShop = new List<Item>();
                        Item item3 = new Item(); Item item4 = new Item(); Item item5 = new Item(); Item item6 = new Item();
                        item3.MakeItem(2, "수련자 갑옷", "방어력", 3, "수련에 도음을 주는 갑옷입니다.", 500);
                        item4.MakeItem(3, "스파르타의 갑옷", "방어력", 10, "스파트라의 전사들이 사용했다는 전설의 갑옷입니다.", 3000);
                        item5.MakeItem(4, "낡은검", "공격력", 2, "쉽게 볼 수 있는 낡은 검 입니다.", 500);
                        item6.MakeItem(5, "청동 도끼", "공격력", 5, "어디선가 사용됐던거 같은도끼입니다. ", 1500);
                        item1.Buy();
                        item2.Buy();
                        item3.Unbuy();
                        item4.Unbuy();
                        item5.Unbuy();
                        item6.Unbuy();
                        itemShop.Add(item1);
                        itemShop.Add(item2);
                        itemShop.Add(item3);
                        itemShop.Add(item4);
                        itemShop.Add(item5);
                        itemShop.Add(item6);
                        while (inputNumber != 0)
                        {

                            Console.WriteLine("상점입니다! 필요한 아이템을 구매하세요\n");
                            Console.WriteLine("[보유 골드]");
                            Console.WriteLine($"{player.Gold} G");
                            Console.WriteLine("\n[아이템 목록]");
                                                       
                            foreach (Item item in itemShop)
                            {
                                item.ShopItem();
                            }
                            Console.WriteLine("\n1.아이템 구매");
                            Console.WriteLine("0.나가기");
                            inputNumber = int.Parse(Console.ReadLine());
                            if (inputNumber == 1)
                            {
                                while(inputNumber !=0)
                                {
                                   
                                    Console.WriteLine("상점입니다! 필요한 아이템을 구매하세요\n");
                                    Console.WriteLine("[보유 골드]");
                                    Console.WriteLine($"{player.Gold} G");
                                    Console.WriteLine("\n[아이템 목록]");
                                    foreach (Item item in itemShop)
                                    {
                                        item.BuyItem();
                                    }
                                    Console.WriteLine("0.나가기");
                                    inputNumber = int.Parse(Console.ReadLine());

                                    if (inputNumber == item1.ItemIndex + 1)
                                    {                                        
                                        Console.WriteLine("\n이미 구매한 물품입니다.\n");                                        
                                    }
                                    else  if (inputNumber == item2.ItemIndex + 1)
                                    {
                                        Console.WriteLine("\n이미 구매한 물품입니다.\n");
                                    }
                                    else  if (inputNumber == item3.ItemIndex +1 && player.Gold>=item3.Gold )
                                    {
                                        if (item3.CheckBuyItem != "구매완료")
                                        {
                                            item3.Buy();
                                            player.Gold -= item3.Gold;
                                            Console.WriteLine(("\n구매가 완료했습니다.\n"));
                                        }
                                        else
                                        {
                                            Console.WriteLine("\n이미 구매한 물품입니다.\n");
                                        }
                                    }
                                    else if (inputNumber == item4.ItemIndex + 1 && player.Gold >= item4.Gold)
                                    {
                                        if (item4.CheckBuyItem != "구매완료")
                                        {
                                            item4.Buy();
                                            player.Gold -= item4.Gold;
                                            Console.WriteLine(("\n구매가 완료했습니다.\n"));
                                        }
                                        else
                                        {
                                            Console.WriteLine("\n이미 구매한 물품입니다.\n");
                                        }
                                    }
                                    else if (inputNumber == item5.ItemIndex + 1 && player.Gold >= item5.Gold)
                                    {
                                        if (item5.CheckBuyItem != "구매완료")
                                        {
                                            item5.Buy();
                                            player.Gold -= item5.Gold;
                                            Console.WriteLine(("\n구매가 완료했습니다.\n"));
                                        }
                                        else
                                        {
                                            Console.WriteLine("\n이미 구매한 물품입니다.\n");
                                        }
                                    }
                                    else if (inputNumber == item6.ItemIndex + 1 && player.Gold >= item6.Gold)
                                    {

                                        if (item6.CheckBuyItem != "구매완료")
                                        {
                                            item6.Buy();
                                            player.Gold -= item6.Gold;
                                            Console.WriteLine(("\n구매가 완료했습니다.\n"));
                                        }
                                        else
                                        {
                                            Console.WriteLine("\n이미 구매한 물품입니다.\n");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nGold 가 부족합니다\n");
                                    }
                                    break;
                                }
                            }
                            else if(inputNumber !=0)
                            {
                                Console.WriteLine("잘못입력하셨습니다");
                            }
                            
                        }
                        break;

                    default:
                        Console.WriteLine("잘못입력하셨습니다");
                        break;
                }
            }
        }
    }
}
