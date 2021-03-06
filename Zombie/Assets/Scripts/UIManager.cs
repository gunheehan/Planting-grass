using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리자 관련 코드
using UnityEngine.UI; // UI 관련 코드

/*
 * 싱글톤 (Singleton)
 * 반드시 씬 안에 하나의 객체만 존재하도록 하는 개발 패턴
 * 
 * 1) instance 객체를 통해 멤버에 접근
 * 
 * instance 객체의 특징
 *      1-1) static - 정적 메모리에 저장. 한번 호출하는 순간 무한하게 메모리를 사용 가능.
 *          UIManager.instance로 접근시 정적 메모리를 반드시 참조하게 됨.
 *      1-2) 싱글톤 클래스(UIManager)를 컴포넌트로 넣어 사용.
 *      
 *      
 * 2) 동적할당과 비교
 *      2-1) 객체가 있어야 함.                      <-> X
 *      2-2) 동적 할당된 주소를 알아야 함.          <-> X
 *      2-3) 접근 지정자를 만족해야 함.             <-> X
 *      Fire() 메서드를 쓰기 편하게! -> 개발 편의성
 * 
 * 3) 매니저(Manager)로 사용
 *      3-1) 매니저는 한 씬에 하나 존재
 *      3-2) 매니저가 가지고 있는 Component들은 다른 오브젝트들과 독립적임.
 */
// 필요한 UI에 즉시 접근하고 변경할 수 있도록 허용하는 UI 매니저
public class UIManager : MonoBehaviour {
    // 싱글톤 접근용 프로퍼티
    public static UIManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<UIManager>();
            }

            return m_instance;
        }
    }

    private static UIManager m_instance; // 싱글톤이 할당될 변수

    public Text ammoText; // 탄약 표시용 텍스트
    public Text scoreText; // 점수 표시용 텍스트
    public Text waveText; // 적 웨이브 표시용 텍스트
    public GameObject gameoverUI; // 게임 오버시 활성화할 UI 

    // 탄약 텍스트 갱신
    public void UpdateAmmoText(int magAmmo, int remainAmmo) {
        ammoText.text = magAmmo + "/" + remainAmmo;
    }

    // 점수 텍스트 갱신
    public void UpdateScoreText(int newScore) {
        scoreText.text = "Score : " + newScore;
    }

    // 적 웨이브 텍스트 갱신
    public void UpdateWaveText(int waves, int count) {
        waveText.text = "Wave : " + waves + "\nEnemy Left : " + count;
    }

    // 게임 오버 UI 활성화
    public void SetActiveGameoverUI(bool active) {
        gameoverUI.SetActive(active);
    }

    // 게임 재시작
    public void GameRestart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}