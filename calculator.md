# Planting-grass
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
    public Text calculation;
    public Text result;
    public List<GameObject> button = new List<GameObject>();

    public Transform btnParent;
    public Button[] buttons;

    double now_text;
    double middle_text = 0;
    string operation;
    void Start()
    {
        calculation.text += "0";
        result.text += "0";
        
        buttons = btnParent.GetComponentsInChildren<Button>();

        for(int i = 0; i < buttons.Length; i++)
        {
            int num = i;
            buttons[i].onClick.AddListener(()=> {                
                Button_controller(num);
            });
        }
    }

    void Button_controller(int num)
    {
        if (calculation.text == "0")
            calculation.text = string.Empty;
       
        if(string.IsNullOrEmpty(operation))
        {
            calculation.text += num.ToString();
            now_text = double.Parse(calculation.text);         
        }
        else
        {
            calculation.text += num.ToString();
            middle_text = double.Parse(calculation.text);
        }

    }

    void calculate_together(string operate)
    {
        if (string.IsNullOrEmpty(operation))
        {
            operation = operate;
            calculation.text = string.Empty;
        }
        else
        {
            Middle_value();
            operation = operate;
            calculation.text = string.Empty;
        }
    }

    public void Add()
    {
        calculate_together("+");
    }

    public void Minus()
    {
        calculate_together("-");
    }

    public void Mul()
    {
        calculate_together("*");
    }

    public void Div()
    {
        calculate_together("/");
    }

    public void Middle_value()
    {
        switch(operation)
        {
            case "+":
                now_text += middle_text;
                break;

            case "-":
                now_text -= middle_text;
                break;

            case "*":
                now_text *= middle_text;
                break;

            case "/":
                now_text /= middle_text;
                break;
        }
        middle_text = 0;
        operation = string.Empty;
    }

    public void Result_Enter()
    {
        if(middle_text != 0)
        {
            switch (operation)
            {
                case "+":
                    now_text += middle_text;
                    break;

                case "-":
                    now_text -= middle_text;
                    break;

                case "*":
                    now_text *= middle_text;
                    break;

                case "/":
                    now_text /= middle_text;
                    break;
            }
            result.text = now_text.ToString();
            now_text = 0;
            middle_text = 0;
            calculation.text = string.Empty;
            operation = string.Empty;
        }
        else
        {
            result.text = now_text.ToString();
            calculation.text = string.Empty;
            now_text = 0;
            middle_text = 0;
        }
    }
}
