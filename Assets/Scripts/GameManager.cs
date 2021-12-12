using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // 싱글톤 패턴을 사용하기 위한 인스턴스 변수
    private static GameManager _instance;
    private AudioSource background;
    [SerializeField]
    private AudioClip[] bgClips;
    public List<GameObject> allies;
    public List<GameObject> enemies;
    private bool isChangedScene;
    public string currentScene = "GameStartScene";
    [SerializeField]
    private GameObject[] cardDeck;
    [SerializeField]
    private GameObject boss;
    bool createBool = false;
    bool positionBool = false;
    public bool BattleEnd = false;
    public string stageInfo;
    public List<GameObject> createdAllies;
    public List<GameObject> createdEnemies;
    public bool gameOver = false;
    // 인스턴스된 카드
    GameObject obj4;
    // 인스턴스에 접근하기 위한 프로퍼티
    public static GameManager Instance
    {
        get
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당해준다.
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        // 인스턴스가 존재하는 경우 새로생기는 인스턴스를 삭제한다.
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        // 아래의 함수를 사용하여 씬이 전환되더라도 선언되었던 인스턴스가 파괴되지 않는다.
        
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        

    }
    private void Update()
    {
        IsChangedScene();
        
        if (currentScene == "teamCompositionScene" && !createBool)
        {
            createBool = true;
            CreateAllies();
            
        }
        else if (currentScene == "BattleScene")
        {

            if(!BattleEnd)
            Battle();

            if (createdEnemies.Count == 0 || createdAllies.Count == 0)
            {
                
                BattleEnd = true;

                if (stageInfo == "boss")
                {
                    gameOver = true;
                    GameOver();
                }
                    

                if(obj4 != null)
                obj4.SetActive(true);
                
            }
        }
        else if( currentScene == "StageScene")
        {
            for(int i = 0; i<3; i++)
            {
                createdAllies[i].SetActive(false);
            }

            BattleEnd = false;
            positionBool = false;
            createdEnemies.Clear();
            
        }

    }

    private void CreateAllies()
    {
        
        GameObject obj1 = Instantiate(allies[0]) as GameObject;
        GameObject obj2 = Instantiate(allies[1]) as GameObject;
        GameObject obj3 = Instantiate(allies[2]) as GameObject;

        DontDestroyOnLoad(obj1);
        DontDestroyOnLoad(obj2);
        DontDestroyOnLoad(obj3);

        createdAllies.Add(obj1);
        createdAllies.Add(obj2);
        createdAllies.Add(obj3);
        obj1.transform.position = GameObject.Find("Pos1").transform.position;
        obj2.transform.position = GameObject.Find("Pos2").transform.position;
        obj3.transform.position = GameObject.Find("Pos3").transform.position;
        obj1.SetActive(true);
        obj2.SetActive(true);
        obj3.SetActive(true);
    }

    private void PositionAllies()
    {
            
            createdAllies[0].transform.position = GameObject.Find("positionOneForAlly").transform.position;
            createdAllies[1].transform.position = GameObject.Find("positionTwoForAlly").transform.position;
            createdAllies[2].transform.position = GameObject.Find("positionThreeForAlly").transform.position;
            
            for (int i = 0; i < 3; i++)
            {
                createdAllies[i].SetActive(true);
            }

    }

    private void PositionEnemies()
    {
        GameObject obj1;
        GameObject obj2;
        GameObject obj3;
        

        switch (stageInfo){

                case "stage1":
                    obj1 = Instantiate(enemies[0]) as GameObject;
                    obj2 = Instantiate(enemies[0]) as GameObject;
                    obj3 = Instantiate(enemies[0]) as GameObject;
                    obj4 = Instantiate(cardDeck[0]) as GameObject;
                    obj4.SetActive(false);
                    createdEnemies.Add(obj1);
                    createdEnemies.Add(obj2);
                    createdEnemies.Add(obj3);
                    for (int i =0; i<3; i++)
                    {
                        createdEnemies[i].SetActive(true);
                    }
                    obj4.transform.position = GameObject.Find("positionForCard").transform.position;
                    createdEnemies[0].transform.position = GameObject.Find("positionOneForEnemy").transform.position;
                    createdEnemies[1].transform.position = GameObject.Find("positionTwoForEnemy").transform.position;
                    createdEnemies[2].transform.position = GameObject.Find("positionThreeForEnemy").transform.position;
                    break;

                case "stage2":
                    obj1 = Instantiate(enemies[1]) as GameObject;
                    obj2 = Instantiate(enemies[1]) as GameObject;
                    obj3 = Instantiate(enemies[1]) as GameObject;
                    obj4 = Instantiate(cardDeck[1]) as GameObject;
                    obj4.SetActive(false);
                    createdEnemies.Add(obj1);
                    createdEnemies.Add(obj2);
                    createdEnemies.Add(obj3);
                    for (int i = 0; i < 3; i++)
                    {
                        createdEnemies[i].SetActive(true);
                    }
                    obj4.transform.position = GameObject.Find("positionForCard").transform.position;
                    createdEnemies[0].transform.position = GameObject.Find("positionOneForEnemy").transform.position;
                    createdEnemies[1].transform.position = GameObject.Find("positionTwoForEnemy").transform.position;
                    createdEnemies[2].transform.position = GameObject.Find("positionThreeForEnemy").transform.position;
                    break;

                case "stage3":
                    obj1 = Instantiate(enemies[2]) as GameObject;
                    obj2 = Instantiate(enemies[2]) as GameObject;
                    obj3 = Instantiate(enemies[2]) as GameObject;
                    obj4 = Instantiate(cardDeck[2]) as GameObject;
                    obj4.SetActive(false);
                    createdEnemies.Add(obj1);
                    createdEnemies.Add(obj2);
                    createdEnemies.Add(obj3);
                    for (int i = 0; i < 3; i++)
                    {
                        createdEnemies[i].SetActive(true);
                    }
                    obj4.transform.position = GameObject.Find("positionForCard").transform.position;
                    createdEnemies[0].transform.position = GameObject.Find("positionOneForEnemy").transform.position;
                    createdEnemies[1].transform.position = GameObject.Find("positionTwoForEnemy").transform.position;
                    createdEnemies[2].transform.position = GameObject.Find("positionThreeForEnemy").transform.position;
                    break;

                case "boss":
                    GameObject boss = Instantiate(enemies[3]) as GameObject;
                    createdEnemies.Add(boss);
                    boss.SetActive(true);
                    createdEnemies[0].transform.position = GameObject.Find("positionTwoForEnemy").transform.position;
                    break;

            
        }
    }

    private void PlayBackground()
    {

    }

    private void IsChangedScene()
    {
        if(currentScene != SceneManager.GetActiveScene().name)
        {
            currentScene = SceneManager.GetActiveScene().name;
        }
         
    }

    private void Battle()
    {
        if (createdAllies.Count > 0 && createdEnemies.Count > 0)
        {
            SortHostility();
        }
            

        if (!positionBool)
        {
            positionBool = true;
            PositionAllies();
            PositionEnemies();
            
        }
    }

    private void GameOver()
    {
        
        for(int i = 0; i < createdAllies.Count; i++)
        {
            Destroy(createdAllies[i]);
        }
        createdAllies.Clear();
        SceneManager.LoadScene("GameStartScene");
        
    }
    
    //내림차순
    public void SortHostility()
    {
        for(int i = createdAllies.Count - 1; i>=0 ; i--)
        {
            for(int j = 0; j<i; j++)
            {
                if(createdAllies[j].GetComponent<Charater>().hostility < createdAllies[j+1].GetComponent<Charater>().hostility)
                {
                    GameObject obj = createdAllies[j];
                    createdAllies[j] = createdAllies[j + 1];
                    createdAllies[j + 1] = obj;
                }
            }
        }

        for (int i = createdEnemies.Count - 1; i >= 0; i--)
        {
            for (int j = 0; j < i; j++)
            {
                if (createdEnemies[j].GetComponent<Charater>().hostility < createdEnemies[j + 1].GetComponent<Charater>().hostility)
                {
                    GameObject obj = createdEnemies[j];
                    createdEnemies[j] = createdEnemies[j + 1];
                    createdEnemies[j + 1] = obj;
                }
            }
        }
    }
    //private void CharacterState(GameObject _character, GameObject _enemy)
    //{
    //    var characterScript = _character.GetComponent<Charater>();
          
    //    if(characterScript.state == Charater.State.ATTACK)
    //    {
    //        characterScript.AttackEnemy(_enemy);
    //        characterScript.state = Charater.State.IDLE;
    //    }
    //    else if(characterScript.state == Charater.State.MOVE)
    //    {

    //    }
    //    else if(characterScript.state == Charater.State.DIE)
    //    {

    //    }
    //    else if(characterScript.state == Charater.State.DAMAGED)
    //    {

    //    }
        
    //}
}