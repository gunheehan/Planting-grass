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
        protected int 수명;
        public abstract void 숨쉬기();
    }
    class Plant : Life, IDamageable
    {
        public void Damege()
        {
        }

        public void Restore()
        {
        }

        public override void 숨쉬기()
        {
            print("휴하후하" + 수명 + "년 만큼 숨을 쉴 수 있습니다.");
        }
    }
    class Animal
    {
        private string 종;
        protected string 성별;
        public float 무게;
        protected string 서식지;
        protected string 주식;

        public Animal()
        {
            print("동물이 태어났다.");
        }
        public Animal(string 종)
        {
            this.종 = 종;
            print(종 + "이 태어났다.");
        }
        //메서드 > 자식 객체에서 접근가능
        public void 숨쉬기() { print("숨을 쉰다"); }
        //가상 메서드 > 자식 객체에서 구현하여 사용
        public virtual void 자기() { }

    }
    class Elephant : Animal
    {
        public float 코길이;
        public float 상아길이;

        public Elephant(string 종) : base(종)
        {
        }
        public Elephant(string 종, float 코길이, float 상아길이) : base(종)
        {
            base.주식 = "풀";
            this.코길이 = 코길이;
            this.상아길이 = 상아길이;
            print("코길이는 " + 코길이 + "이고 상아길이는 " + 상아길이);
        }
    }
    class Lion : Animal
    {
        public float 갈귀길이;
    }
    // Start is called before the first frame update
    void Start()
    {
        Elephant elephant = new Elephant("코끼리");
        elephant.무게 = 100f;

        //Lion lion = new Lion();
        // lion.종 = "사자";

        Animal a1 = new Elephant("코끼리", 100f, 30f);
        //Animal a2 = new Lion();
    }
}