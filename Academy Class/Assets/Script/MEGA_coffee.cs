using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MEGA_coffee : MonoBehaviour
{
    class MEGA
    {
        string[] �޴� = new string[] { "�Ƹ޸�ī��", "īǪġ��", "ī���ī", "�ݵ���", "���̽�Ƽ", "���̵�", "ī���", "�ް�����", "����ٳ���", "��ũ����" };
        int[] ���� = new int[] { 1500, 2700, 3700, 3300, 3000, 3500, 2700, 3800, 3800, 3900 };
        int[] ���� = new int[] { 500, 1000, 1200, 1000, 800, 1300, 1100, 1500, 1700, 1400 };
        string �������;
        public int money = 0;


        int Fix_Menu = 100;

        public MEGA(string �޴�, string �������)
        {
            if (�޴� != "�ܱ�")
            {
                this.������� = �������;
                Setting_coffee(�޴�);
            }
            else
                MEGA_Money();
        }
        public MEGA(string �޴�)
        {
            if (�޴� == "�ܱ�")
                MEGA_Money();
            else
            {
                Setting_coffee(�޴�);
            }
        }

        void MEGA_Money()
        {
            print("���� ������ �� �ܱ��� " + money + "�� �Դϴ�.");
        }

        void Setting_coffee(string menu)
        {
            int menu_len = this.�޴�.Length;
            Fix_Menu = 100;
            for (int i = 0; i < menu_len; i++)
            {
                if (menu == this.�޴�[i])
                {
                    Fix_Menu = i;
                    MEGA_Information m = new MEGA_Information(�޴�[Fix_Menu], ����[Fix_Menu], �������, ����[Fix_Menu], Fix_Menu);
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
        string �޴�;
        int ����;
        string �������;
        int ����;
        int Fix;
        System.DateTime ������;
        string �����̸� = "���ް�Ŀ��";
        string ������ȭ��ȣ = "02-012-3456";

        public MEGA_Information(string �޴�, int ����, string �������, int ����, int Fix)
        {
            this.�޴� = �޴�;
            this.���� = ����;
            this.������� = �������;
            this.���� = ����;
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
                print("������ : �߸��� ���� |0|||" + �����̸� + "|" + ������ȭ��ȣ);
                return 0;
            }

            else
            {
                ������ = System.DateTime.Now;
                print("������ : " + �޴� + "|" + ���� + "|" + ������� + "|" + ������ + "|" + �����̸� + "|" + ������ȭ��ȣ);
                return ���� - ����;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        MEGA m1 = new MEGA("�Ƹ޸�ī��", "����");
        MEGA m2 = new MEGA("īǪġ��", "ī��");
        MEGA m3 = new MEGA("���̵�", "����");
        MEGA m4 = new MEGA("ī���", "ī��");
        MEGA m5 = new MEGA("��ũ����", "����");
        MEGA m6 = new MEGA("��ũ����", "����");
        MEGA m7 = new MEGA("�Ƹ޸�ī��", "����");
        MEGA m8 = new MEGA("īǪġ��", "ī��");
        MEGA m9 = new MEGA("���̵�", "����");
        MEGA m10 = new MEGA("ī���", "ī��");
        MEGA m11 = new MEGA("��ũ����", "����");
        MEGA m12 = new MEGA("�Ƹ޸�ī��", "����");
        MEGA m13 = new MEGA("īǪġ��", "ī��");
        MEGA m14 = new MEGA("���̵�", "����");
        MEGA m15 = new MEGA("ī���", "ī��");
        MEGA m16 = new MEGA("��ũ����", "����");
        MEGA m17 = new MEGA("�Ƹ޸�ī��", "����");
        MEGA m18 = new MEGA("īǪġ��", "ī��");
        MEGA m19 = new MEGA("���̵�", "����");
        MEGA m20 = new MEGA("ī���", "ī��");
        MEGA m21 = new MEGA("��ũ����", "����");
        MEGA m22 = new MEGA("�ܱ�", "����");

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