# Planting-grass
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button_controller : MonoBehaviour
{
    public GameObject Log_in;
    public GameObject Log_in2;
    public GameObject Log_in_page;
    public GameObject Return;
    public GameObject welcome;
    public GameObject Log_in_ID;
    public GameObject sign_ID;
    public Text t_account;
    public Text t_salary;
    public GameObject money;
    List<string> ID = new List<string>();
    int i;
    int account = 0;
    int salary = 50000;

    // Start is called before the first frame update
    void Start()
    {
        Log_in.SetActive(true);
        Log_in2.SetActive(false);
        Log_in_page.SetActive(false);
        Return.SetActive(false);
    }

    public void Deposite()
    {
        int get_money = int.Parse(money.GetComponent<InputField>().text);
        int out_money = int.Parse(t_account.GetComponent<Text>().text);
        if (salary!=0 && salary >= get_money && get_money > 0)
        {
            string set_money;
            salary -= get_money;
            out_money += get_money;
            set_money = out_money.ToString();
            t_salary.GetComponent<Text>().text = salary.ToString();
            t_account.GetComponent<Text>().text = set_money;
            money.GetComponent<InputField>().text = string.Empty;
        }
    }

    public void Withdarw()
    {
        int get_money = int.Parse(money.GetComponent<InputField>().text);
        int out_money = int.Parse(t_account.GetComponent<Text>().text);
        if (out_money != 0 && out_money >= get_money && get_money > 0)
        {
            string set_money;
            salary += get_money;
            out_money -= get_money;
            set_money = out_money.ToString();
            t_salary.GetComponent<Text>().text = salary.ToString();
            t_account.GetComponent<Text>().text = set_money;
            money.GetComponent<InputField>().text = string.Empty;
        }

    }

    public void button_sign_in()
    {
        Log_in_ID.GetComponent<InputField>().text = string.Empty;
        Log_in2.SetActive(false);
        Return.SetActive(false);
        Log_in_page.SetActive(false);
        Log_in.SetActive(true);
    }

    public void button_sign()
    {
        Log_in.SetActive(false);
        Return.SetActive(false);
        Log_in2.SetActive(true);
    }

    public void button_return()
    {
        welcome.GetComponent<InputField>().text = string.Empty;
        Return.SetActive(true);
        Log_in2.SetActive(false);
        Log_in.SetActive(false);
    }

    public void sign_member()
    {
        
        if (string.IsNullOrEmpty(sign_ID.GetComponent<InputField>().text))
        {
            Log_in.SetActive(true);
            Log_in2.SetActive(false);
        }
        else
        {
            ID.Add(sign_ID.GetComponent<InputField>().text);
            sign_ID.GetComponent<InputField>().text = string.Empty;
            Log_in.SetActive(true);
            Log_in2.SetActive(false);
           
        }
    }

    public void button_Log_In_success()
    {
        /*string comparison = "한건희";

        if (comparison == Log_in_ID.GetComponent<InputField>().text)
        {
            welcome.GetComponent<InputField>().text = Log_in_ID.GetComponent<InputField>().text + " 님";
            Log_in_page.SetActive(true);
            Log_in.SetActive(false);
        }

        else
        {
            Log_in_ID.GetComponent<InputField>().text = string.Empty;
            button_return();
        }
        }*/

        int len = ID.Count;
        int ID_index = 0;
        bool login = false;
        for (int i = 0; i < len; i++)
        {
            if (ID[i] == Log_in_ID.GetComponent<InputField>().text)
            {
                login = true;
                ID_index = i;
            }
        }

        if (login == true)
        {
            welcome.GetComponent<InputField>().text = ID[ID_index] + " 님";
            t_salary.GetComponent<Text>().text = salary.ToString();
            t_account.GetComponent<Text>().text = "0";
            Log_in_page.SetActive(true);
            Log_in.SetActive(false);
        }
        else
        {
            Log_in_ID.GetComponent<InputField>().text = string.Empty;
            button_return();
        }
    }
}
