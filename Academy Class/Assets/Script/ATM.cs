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

    int ID_index = 0; // 로그인시 해당 회원 정보를 가져오기 위한 변수

    void Start()
    {
        Log_in.SetActive(true);
        Log_in2.SetActive(false);
        Log_in_page.SetActive(false);
        Return.SetActive(false);
        Warning.SetActive(false);
    }

    public void Deposite() // 입금처리를 위한 함수
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

    public void Withdarw() // 출금처리를 위한 함수
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

    public void button_sign_in() // 초기 로그인창
    {
        Log_in_ID.GetComponent<InputField>().text = string.Empty;
        Log_in2.SetActive(false);
        Return.SetActive(false);
        Log_in_page.SetActive(false);
        Log_in.SetActive(true);
    }

    public void button_sign() // 회원가입창
    {
        Log_in.SetActive(false);
        Return.SetActive(false);
        Log_in2.SetActive(true);
        Warning2.SetActive(false);
        sign_ID.GetComponent<InputField>().text = string.Empty;
    }

    public void button_return() // 로그인 정보가 맞지 않을시 띄우는 창
    {
        welcome.GetComponent<InputField>().text = string.Empty;
        Return.SetActive(true);
        Log_in2.SetActive(false);
        Log_in.SetActive(false);
    }

    public void warning_down() // 입출금 금액이 옳지 않을때 띄우는 경고문
    {
        money.GetComponent<InputField>().text = string.Empty;
        Warning.SetActive(false);
    }

    public void warning2_down() // 가입자 이름이 중복될 때 띄우는 경고문
    {
        sign_ID.GetComponent<InputField>().text = string.Empty;
        Warning2.SetActive(false);
    }

    public void Remittances() // 송금을 위한 함수
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

    public void sign_member() // 회원가입시 가입정보 저장 및 초기 창으로 돌아가는 함수
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

    public void button_Log_In_success() // 로그인 성공시 띄우는 창
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
            welcome.GetComponent<InputField>().text = IDS[ID_index].ID + " 님";
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
{ // 회원들의 최초 기본 가입정보를 저장한 클래스
    public string ID;
    public int Salary = 50000;
    public int Passbook = 0;
}