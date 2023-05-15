using System.Collections.Generic;
using UnityEngine;


public class OpenStone : MonoBehaviour
{
    public GameObject _player;
    Animator _ani;
    protected bool _isPlayerEnter;
    public bool isPlayerEnter { get { return _isPlayerEnter; } set { _isPlayerEnter = value; } }
    
    GameObject _monster;
    List<Monster> monsters = new List<Monster>();
    [SerializeField] GameObject _hpBar;
    [SerializeField] GameObject _moncon;
    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _monster = Resources.Load("Prefabs/Slime") as GameObject; //as GameObject ����ȯ
        _ani = GetComponent<Animator>();
        isPlayerEnter = false;
    }
  
    void Update()
    {
        if(isPlayerEnter==true) 
        {
            _ani.SetTrigger("Open");
            makeMonster();
        }

    }

    void makeMonster()
    {
        if (!isPlayerEnter) return;
        int ran = Random.Range(0, 1);
        if (ran<0)
        {
            Debug.Log("Not Monster");
            
        }
        else if (ran<1)
        {
          _moncon.SetActive(true);
            _hpBar.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerEnter = false;

    }

}
