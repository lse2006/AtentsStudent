//using : 어떤 추가적인 기능을 사용할 것인지를 표시하는 것
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namepace : 이름이 겹치는 것을 방지하기 위해 구분지어 놓는 용도
namespace _01_Console
{
    //접근제한자(Access Modifier)
    //public : 누구든지 접근할 수 있다.
    //private : 자기 자신만 접근할 수 있다.
    //internal : 같은 어셈블리안에서는 public 다른 어셈블리면 private

    //클래스 : 특정한 오브젝트를 표현하기 위해 그 오브젝트가 가져야 할 데이터와 기능을 모아놓은 것
    internal class Character    //Charcter클래스를 public으로 선언
    {
        //멤버 변수 >> 이 클래스에서 사용되는 데이터
        private string name;
        private int hp = 100;
        private int maxHP = 100;
        private int strenth = 10;
        private int dexterity = 5;
        private int intellegence = 7;

        protected Random rand;

        //Rondom random = new Random();
        //for (int i = 0; i<100; i++)
        //{
        //  int randNum = random.Next();
        //  //% : 앞에 숫자를 뒤의 숫자로 나눈 나머지값을 돌려주는 연산자. 모듈레이트 연산, 나머지 연산
        //  // 10 % 3 하면 결과는 1
        //  // % 연산의 결과는 항상 0~(뒤 숫자-1)로 나온다.
        //  Console.WriteLine($"랜덤 넘버 : {randNum}");
        //}
        private string[] nameArray = { "너굴맨", "개굴맨", "슈퍼맨", "아이언맨", "맨투맨" };    //nammeArray 에 기본값 설정(선언과 할당을 동시에)

        //배열 : 같은 종류(데이터 타입)의 데이터를 한번에 여러개 가지는 유형의 변수
        //int[] intArray;   // 인티저를 여러개 가질 수 있는 배열
        //intArray = new int[5];    //인티저를 5개 가질 수 있도록 할당


        //<summary>
        //HP 표시/설정용 프로퍼티
        //<summary>
        public int HP
        {
            get //이 프로퍼티를 읽을 때 호출되는 부분. get만 만들면 읽기 전용같은 효과가 있다.
            {
                return hp;
            }

            private set  //이 프로퍼티에 값을 넣을 때 호출되는 부분. set에 private를 붙이면 쓰는건 나만 가능.
            {

                hp = value;
                if (hp > maxHP) //hp에 값이 들어갈 때 최대치가 넘으면 최대치로 설정
                {
                    hp = maxHP; //hp
                }
                if (hp <= 0)
                {
                    //사망 처리용 함수 호출
                    Console.WriteLine($"{name}이 사망");
                }
            }
        }

        /// <summary>
        /// 기본 생성자
        /// </summary>
        public Character()
        {
            Console.WriteLine("생성자 호출");
            //Console.WriteLine("생성자 호출");
            rand = new Random(DateTime.Now.Millisecond);    //랜덤 클레스 시드값 설정.
            int randomNumber = rand.Next();                 //랜덤 클래스 이용해서 0~21억 사이의 숫자를 랜덤으로 선택
            randomNumber %= 5; // randomNumber = randomNumber % 5  //랜덤으로 고른 숫자를 0~4로 변경
            name = nameArray[randomNumber];                 // 0~4로 변경한 값을 인덱스로 사용하여 이름 배열에서 이름 선택

            GenerateStatus();   //스테이터스 랜덤으로 설정
            PrintStaus();  //설정한 내용 출력하기
           
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="newName">Character의 이름</param>
        public Character(string newName)
        {
            //Console.WriteLine($"생성자 호출 - {newName}");
            rand = new Random(DateTime.Now.Millisecond);
            name = newName; //이름은 파라메터로 입력 받은 것을 사용.

            GenerateStatus();   //스테이터스 랜덤으로 설정
            PrintStaus();  //설정한 내용 출력하기
        }

        //멤버 함수 >> 이 클래스가 가지는 기능

        /// <summary>
        /// 스테이더스를 랜덤으로 설정해주는 함수
        /// </summary>
        private virtual void GenerateStatus()
        {
            maxHP = rand.Next(100, 201);    //100에서 200 중 랜덤으로 선택
            hp = maxHP;

            strenth = rand.Next(20) + 1;    //1~20사이를 랜덤하게 선택
            dexterity = rand.Next(20) + 1;
            intellegence = rand.Next(20) + 1;
        }


        /// <summary>
        /// target을 공격하는 함수
        /// </summary>
        /// <param name="target">공격대상</param>
        public virtual void Attack(Character target)
        {
            int damage = strenth;   //데미지는 힘 기반
            Console.WriteLine($"{name}이 {target.name}에게 공격을 합니다.(공격력 : {damage})");
            target.TakeDamage(damage);  //target에게 데미지 전달
        }

        /// <summary>
        /// 데미지를 받는 함수
        /// </summary>
        /// <param name="damage">받은 순수 데미지</param>
        public virtual void TakeDamage(int damage)
        {
            HP -= damage;   //데미지 만큰 HP감소, 추가 로직 없음.
            Console.WriteLine($"{name}이 {damage}만큼의 피해를 입었습니다.");
        }

        /// <summary>
        /// 스테이터스창 출력
        /// </summary>
        public virtual void PrintStaus()
        {
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine($"┃ 이름\t:\t{name}");
            Console.WriteLine($"┃ HP\t:\t{hp,4} / {maxHP,4}");
            Console.WriteLine($"┃ 힘\t:\t{strenth,2}");
            Console.WriteLine($"┃ 민첩\t:\t{dexterity,2}");
            Console.WriteLine($"┃ 지능\t:\t{intellegence,2}");
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
        }
    }
}