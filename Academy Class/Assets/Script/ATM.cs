using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATM : MonoBehaviour
{
    public GameObject Log_in;
    public GameObject Log_in2;
    public GameObject Log_in_page;
    public GameObject Return;
    public GameObject welcome;
    public GameObject Log_in_ID;
    public GameObject sign_ID;
    public GameObject Warning;
    public GameObject Warning2;
    public GameObject Remittance_text;
    public Text t_account;
    public Text t_salary;
    public GameObject money;
    //List<string> ID = new List<string>();
    List<Member_information> IDS = new List<Member_information>();

    int ID_index = 0; // �α��ν� �ش� ȸ�� ������ �������� ���� ����

    void Start()
    {
        Log_in.SetActive(true);
        Log_in2.SetActive(false);
        Log_in_page.SetActive(false);
        Return.SetActive(false);
        Warning.SetActive(false);
    }

    public void Deposite() // �Ա�ó���� ���� �Լ�
    {
        int get_money = int.Parse(money.GetComponent<InputField>().text);
        if (IDS[ID_index].Salary != 0 && IDS[ID_index].Salary >= get_money && get_money > 0)
        {
            IDS[ID_index].Salary -= get_money;
            IDS[ID_index].Passbook += get_money;
            t_salary.GetComponent<Text>().text = IDS[ID_index].Salary.ToString();
            t_account.GetComponent<Text>().text = IDS[ID_index].Passbook.ToString();
            money.GetComponent<InputField>().text = string.Empty;
        }
        else
            Warning.SetActive(true);
    }

    public void Withdarw() // ���ó���� ���� �Լ�
    {
        int get_money = int.Parse(money.GetComponent<InputField>().text);
        if (IDS[ID_index].Passbook != 0 && IDS[ID_index].Passbook >= get_money && get_money > 0)
        {
            IDS[ID_index].Salary += get_money;
            IDS[ID_index].Passbook -= get_money;
            t_salary.GetComponent<Text>().text = IDS[ID_index].Salary.ToString();
            t_account.GetComponent<Text>().text = IDS[ID_index].Passbook.ToString();
            money.GetComponent<InputField>().text = string.Empty;
        }
        else
            Warning.SetActive(true);

    }

    public void button_sign_in() // �ʱ� �α���â
    {
        Log_in_ID.GetComponent<InputField>().text = string.Empty;
        Log_in2.SetActive(false);
        Return.SetActive(false);
        Log_in_page.SetActive(false);
        Log_in.SetActive(true);
    }

    public void button_sign() // ȸ������â
    {
        Log_in.SetActive(false);
        Return.SetActive(false);
        Log_in2.SetActive(true);
        Warning2.SetActive(false);
        sign_ID.GetComponent<InputField>().text = string.Empty;
    }

    public void button_return() // �α��� ������ ���� ������ ���� â
    {
        welcome.GetComponent<InputField>().text = string.Empty;
        Return.SetActive(true);
        Log_in2.SetActive(false);
        Log_in.SetActive(false);
    }

    public void warning_down() // ����� �ݾ��� ���� ������ ���� ���
    {
        money.GetComponent<InputField>().text = string.Empty;
        Warning.SetActive(false);
    }

    public void warning2_down() // ������ �̸��� �ߺ��� �� ���� ���
    {
        sign_ID.GetComponent<InputField>().text = string.Empty;
        Warning2.SetActive(false);
    }

    public void Remittances() // �۱��� ���� �Լ�
    {
        int get_money = int.Parse(money.GetComponent<InputField>().text);
        int Remittance_idx = 0;
        string Remittance_name = Remittance_text.GetComponent<InputField>().text;
        for (int i = 0; i < IDS.Count; i++)
        {
            if (IDS[i].ID == Remittance_name)
                Remittance_idx = i;
        }
        if (IDS[ID_index].Salary != 0 && IDS[ID_index].Salary >= get_money && get_money > 0)
        {
            if (string.IsNullOrEmpty(IDS[Remittance_idx].ID) || string.IsNullOrEmpty(Remittance_name) || IDS[Remittance_idx].ID == IDS[ID_index].ID)
                Warning.SetActive(true);
            else
            {
                IDS[ID_index].Salary -= get_money;
                IDS[Remittance_idx].Passbook += get_money;
                t_salary.GetComponent<Text>().text = IDS[ID_index].Salary.ToString();
                money.GetComponent<InputField>().text = string.Empty;
            }
        }

        else
            Warning.SetActive(true);
    }

    public void sign_member() // ȸ�����Խ� �������� ���� �� �ʱ� â���� ���ư��� �Լ�
    {

        if (string.IsNullOrEmpty(sign_ID.GetComponent<InputField>().text))
        {
            Log_in.SetActive(true);
            Log_in2.SetActive(false);
        }
        else
        {
            string id = sign_ID.GetComponent<InputField>().text;
            int IDS_idx = IDS.Count;
            bool ID_TF = true;
            for (int i = 0; i < IDS_idx; i++)
            {
                if (IDS[i].ID == id)
                    ID_TF = false;
            }
            if (ID_TF)
            {
                IDS.Insert(IDS_idx, new Member_information() { ID = id });
                sign_ID.GetComponent<InputField>().text = string.Empty;
                Log_in.SetActive(true);
                Log_in2.SetActive(false);
            }
            else
                Warning2.SetActive(true);
        }
    }

    public void button_Log_In_success() // �α��� ������ ���� â
    {
        int len = IDS.Count;
        bool login = false;
        for (int i = 0; i < len; i++)
        {
            if (IDS[i].ID == Log_in_ID.GetComponent<InputField>().text)
            {
                login = true;
                ID_index = i;
            }
        }

        if (login == true)
        {
            welcome.GetComponent<InputField>().text = IDS[ID_index].ID + " ��";
            t_salary.GetComponent<Text>().text = IDS[ID_index].Salary.ToString();
            t_account.GetComponent<Text>().text = IDS[ID_index].Passbook.ToString();
            money.GetComponent<InputField>().text = string.Empty;
            Remittance_text.GetComponent<InputField>().text = string.Empty;
            Log_in_page.SetActive(true);
            Log_in.SetActive(false);
            Warning.SetActive(false);
        }
        else
        {
            Log_in_ID.GetComponent<InputField>().text = string.Empty;
            button_return();
        }
    }
}

public class Member_information
{ // ȸ������ ���� �⺻ ���������� ������ Ŭ����
    public string ID;
    public int Salary = 50000;
    public int Passbook = 0;
}