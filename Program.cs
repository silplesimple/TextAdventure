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

            public string CheckItem {  get; set; }
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
                CheckItem = " ";
            }

            public void ItemStats()
            {
                Console.WriteLine($"-{CheckItem}{ItemIndex+1} {Name} |{StatName}+{Stat} | {Manual} ");
            }
            public void BuyItem()
            {
                Console.WriteLine($"-{Name} |{StatName}+{Stat} | {Manual} | {Gold} G ");
            }
            public void SellItem()
            {
                Console.WriteLine($"-{Name} |{StatName}+{Stat} | {Manual} | 구매완료 ");
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
            player.Gold = 1500;           
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
                                        item1.HaveItem();
                                    }
                                    else if(inputNumber==item2.ItemIndex+1)
                                    {
                                        item2.HaveItem();
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
                        Console.WriteLine("상점입니다");
                        break;
                    default:
                        Console.WriteLine("잘못입력하셨습니다");
                        break;
                }
            }
        }
    }
}
