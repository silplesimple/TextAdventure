namespace TextAdventure
{
    internal class Program
    {
      
        class Player
        {
            public string Name { get; set; }//이름
            public int Level { get; set; }//레벨
            public string Chad { get; set; }//직업
            public int AttackPower { get; set; }//공격력
            public int Defense{  get; set; }//방어력
            public int Health {  get; set; }//체력
            public int Gold { get; set; }//골드
            
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
        
        static void StartText()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine("\n1.상태 보기");
            Console.WriteLine("2.인벤토리");
            Console.WriteLine("3.상점");
            
        }
        static void Main(string[] args)
        {
            Player player = new Player();
            List<Player> list = new List<Player>();
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
                        Console.WriteLine("\n0.나가기");
                        Console.WriteLine("\n원하시는 행동을 입력해주세요.\n>>");                                              
                        while(inputNumber!=0)
                        {
                            inputNumber = int.Parse(Console.ReadLine());
                            Console.WriteLine("잘못된 숫자를 입력했습니다. 다시 입력해주세요");
                        }
                        break;
                        
                    case 2:
                        Console.WriteLine("인벤토리입니다");
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
