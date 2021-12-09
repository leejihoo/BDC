using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    // �̱��� ������ ����ϱ� ���� �ν��Ͻ� ����
    private static GameManager _instance;
    private AudioSource background;
    [SerializeField]
    private AudioClip[] bgClips;
    [SerializeField]
    private GameObject[] allies;
    [SerializeField]
    private GameObject[] enemies;
    private bool isChangedScene;
    private string currentScene;
    [SerializeField]
    private GameObject[] cardDeck;
    [SerializeField]
    private GameObject boss;

    // �ν��Ͻ��� �����ϱ� ���� ������Ƽ
    public static GameManager Instance
    {
        get
        {
            // �ν��Ͻ��� ���� ��쿡 �����Ϸ� �ϸ� �ν��Ͻ��� �Ҵ����ش�.
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
        // �ν��Ͻ��� �����ϴ� ��� ���λ���� �ν��Ͻ��� �����Ѵ�.
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        // �Ʒ��� �Լ��� ����Ͽ� ���� ��ȯ�Ǵ��� ����Ǿ��� �ν��Ͻ��� �ı����� �ʴ´�.
        DontDestroyOnLoad(gameObject);
    }

    private void CreateAllies()
    {

    }

    private void PositionAllies()
    {

    }

    private void PositionEnemies()
    {

    }

    private void PlayBackground()
    {

    }

    private void IsChangedScene()
    {

    }

    private void Battle()
    {

    }

    private void RewardCardSelect()
    {

    }

    private void GameOver()
    {

    }
}