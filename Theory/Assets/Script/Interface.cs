using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{

    public void Restore();
    public void Damege();

}
public class Interface : MonoBehaviour
{
    abstract class Life
    {
        protected int ����;
        public abstract void ������();
    }
    class Plant : Life, IDamageable
    {
        public void Damege()
        {
        }

        public void Restore()
        {
        }

        public override void ������()
        {
            print("��������" + ���� + "�� ��ŭ ���� �� �� �ֽ��ϴ�.");
        }
    }
    class Animal
    {
        private string ��;
        protected string ����;
        public float ����;
        protected string ������;
        protected string �ֽ�;

        public Animal()
        {
            print("������ �¾��.");
        }
        public Animal(string ��)
        {
            this.�� = ��;
            print(�� + "�� �¾��.");
        }
        //�޼��� > �ڽ� ��ü���� ���ٰ���
        public void ������() { print("���� ����"); }
        //���� �޼��� > �ڽ� ��ü���� �����Ͽ� ���
        public virtual void �ڱ�() { }

    }
    class Elephant : Animal
    {
        public float �ڱ���;
        public float ��Ʊ���;

        public Elephant(string ��) : base(��)
        {
        }
        public Elephant(string ��, float �ڱ���, float ��Ʊ���) : base(��)
        {
            base.�ֽ� = "Ǯ";
            this.�ڱ��� = �ڱ���;
            this.��Ʊ��� = ��Ʊ���;
            print("�ڱ��̴� " + �ڱ��� + "�̰� ��Ʊ��̴� " + ��Ʊ���);
        }
    }
    class Lion : Animal
    {
        public float ���ͱ���;
    }
    // Start is called before the first frame update
    void Start()
    {
        Elephant elephant = new Elephant("�ڳ���");
        elephant.���� = 100f;

        //Lion lion = new Lion();
        // lion.�� = "����";

        Animal a1 = new Elephant("�ڳ���", 100f, 30f);
        //Animal a2 = new Lion();
    }
}