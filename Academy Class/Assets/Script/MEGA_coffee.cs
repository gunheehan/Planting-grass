using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MEGA_coffee : MonoBehaviour
{
    class MEGA
    {
        string[] 메뉴 = new string[] { "아메리카노", "카푸치노", "카페모카", "콜드브루", "아이스티", "에이드", "카페라떼", "메가초코", "딸기바나나", "퐁크러쉬" };
        int[] 가격 = new int[] { 1500, 2700, 3700, 3300, 3000, 3500, 2700, 3800, 3800, 3900 };
        int[] 원가 = new int[] { 500, 1000, 1200, 1000, 800, 1300, 1100, 1500, 1700, 1400 };
        string 결제방식;
        public int money = 0;


        int Fix_Menu = 100;

        public MEGA(string 메뉴, string 결제방식)
        {
            if (메뉴 != "잔금")
            {
                this.결제방식 = 결제방식;
                Setting_coffee(메뉴);
            }
            else
                MEGA_Money();
        }
        public MEGA(string 메뉴)
        {
            if (메뉴 == "잔금")
                MEGA_Money();
            else
            {
                Setting_coffee(메뉴);
            }
        }

        void MEGA_Money()
        {
            print("저희 매장의 총 잔금은 " + money + "원 입니다.");
        }

        void Setting_coffee(string menu)
        {
            int menu_len = this.메뉴.Length;
            Fix_Menu = 100;
            for (int i = 0; i < menu_len; i++)
            {
                if (menu == this.메뉴[i])
                {
                    Fix_Menu = i;
                    MEGA_Information m = new MEGA_Information(메뉴[Fix_Menu], 가격[Fix_Menu], 결제방식, 원가[Fix_Menu], Fix_Menu);
                    money += m.Print();
                    break;
                }
            }

            if (Fix_Menu == 100)
            {
                _ = new MEGA_Information(Fix_Menu);
            }
        }
    }
    class MEGA_Information
    {
        string 메뉴;
        int 가격;
        string 결제방식;
        int 원가;
        int Fix;
        System.DateTime 결제일;
        string 지점이름 = "당산메가커피";
        string 지점전화번호 = "02-012-3456";

        public MEGA_Information(string 메뉴, int 가격, string 결제방식, int 원가, int Fix)
        {
            this.메뉴 = 메뉴;
            this.가격 = 가격;
            this.결제방식 = 결제방식;
            this.원가 = 원가;
            this.Fix = Fix;
        }

        public MEGA_Information(int Fix)
        {
            this.Fix = Fix;
            Print();
        }
        public int Print()
        {
            if (Fix == 100)
            {
                print("영수증 : 잘못된 결제 |0|||" + 지점이름 + "|" + 지점전화번호);
                return 0;
            }

            else
            {
                결제일 = System.DateTime.Now;
                print("영수증 : " + 메뉴 + "|" + 가격 + "|" + 결제방식 + "|" + 결제일 + "|" + 지점이름 + "|" + 지점전화번호);
                return 가격 - 원가;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        MEGA m1 = new MEGA("아메리카노", "현금");
        MEGA m2 = new MEGA("카푸치노", "카드");
        MEGA m3 = new MEGA("에이드", "현금");
        MEGA m4 = new MEGA("카페라떼", "카드");
        MEGA m5 = new MEGA("퐁크러쉬", "현금");
        MEGA m6 = new MEGA("뽕크러쉬", "현금");
        MEGA m7 = new MEGA("아메리카노", "현금");
        MEGA m8 = new MEGA("카푸치노", "카드");
        MEGA m9 = new MEGA("에이드", "현금");
        MEGA m10 = new MEGA("카페라떼", "카드");
        MEGA m11 = new MEGA("퐁크러쉬", "현금");
        MEGA m12 = new MEGA("아메리카노", "현금");
        MEGA m13 = new MEGA("카푸치노", "카드");
        MEGA m14 = new MEGA("에이드", "현금");
        MEGA m15 = new MEGA("카페라떼", "카드");
        MEGA m16 = new MEGA("퐁크러쉬", "현금");
        MEGA m17 = new MEGA("아메리카노", "현금");
        MEGA m18 = new MEGA("카푸치노", "카드");
        MEGA m19 = new MEGA("에이드", "현금");
        MEGA m20 = new MEGA("카페라떼", "카드");
        MEGA m21 = new MEGA("퐁크러쉬", "현금");
        MEGA m22 = new MEGA("잔금", "현금");

        /*money += m1.Print();
        money += m2.Print();
        money += m3.Print();
        money += m4.Print();
        money += m5.Print();
        money += m6.Print();
        money += m7.Print();
        money += m8.Print();
        money += m9.Print();
        money += m10.Print();
        money += m11.Print();
        money += m12.Print();
        money += m13.Print();
        money += m14.Print();
        money += m15.Print();
        money += m16.Print();
        money += m17.Print();
        money += m18.Print();
        money += m19.Print();
        money += m20.Print();
        money += m21.Print();*/
    }
}