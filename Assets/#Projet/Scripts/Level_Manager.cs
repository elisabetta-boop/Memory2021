using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Level_Manager : MonoBehaviour
{
    private int row;
    private int col;

    public float gapRow = 1.5f;

    public float gapCol = 1.5f;

    [Range(0f,5f)]
    public float timeBeforeReset = 1f;
    public bool resetOnGoing = false;
    public GameObject item_Prefab;
    public Item_Behaviour[] items;
    public Material[] colors;
    public Material defaultColor;
    public List<int> selected = new List<int>();
    public List<int> matches = new List<int>();
    private Dictionary<int,Material> itemMaterial = new Dictionary<int, Material>();
    public UnityEvent whenPlayerWins;
    private float timer = 0;
    


    // Start is called before the first frame update
    void Start()
    {
        row = PlayerPrefs.GetInt("row",3);
        col = PlayerPrefs.GetInt("col",4);

        items = new Item_Behaviour[row*col];
        int index = 0;

        for (int x=0; x <col ; x++) 
        {
            for(int z=0; z<row; z++) 
            {
                Vector3 position = new Vector3(x*gapCol,0,z*gapRow);
                GameObject item = Instantiate(item_Prefab, position, Quaternion.identity);
                
                item.GetComponent<Renderer>().material = defaultColor;
                
                items[index] = item.GetComponent<Item_Behaviour>();
                items[index].id = index;
                items[index].manager = this;
                index++;
            }
        }
        GiveMaterial();
    }
    private void GiveMaterial() 
    { 
        List<int> possibilities = new List<int>();
        
        for(int i=0; i<row*col; i++) 
        {
            possibilities.Add(i);
        }
        for(int i=0; i< colors.Length; i++) 
        {
            if (possibilities.Count < 2) break;
            
            int idPos = Random.Range(0,possibilities.Count);
            int id1 = possibilities[idPos];
            possibilities.RemoveAt(idPos);

            idPos = Random.Range(0,possibilities.Count);
            int id2 = possibilities[idPos];
            possibilities.RemoveAt(idPos);

            itemMaterial.Add(id1, colors[i]);
            itemMaterial.Add(id2, colors[i]); 
        }
    }

    private IEnumerator ResetMaterials(int id1, int id2) 
    {
        resetOnGoing = true;
        yield return new WaitForSeconds(timeBeforeReset);
        ResetMaterial(id1);
        ResetMaterial(id2);
        resetOnGoing = false;
    }
    private IEnumerator Win() 
    {
        yield return new WaitForSeconds(timeBeforeReset);
        // if (whenPlayerWins != null) { whenPlayerWins.Invoke();}
        whenPlayerWins?.Invoke();
        print("OKAY you WON!!!!!");
        // PlayerPrefs.SetFloat("time", timer);
        
        // print(timer);
        
    }
    public void RevealMaterial(int id) 
    {
        if (resetOnGoing == false  && !selected.Contains(id) && !matches.Contains(id))
        {
            selected.Add(id);
            Material material = itemMaterial[id];
            items[id].GetComponent<Renderer>().material = itemMaterial[id];
            items[id].HasBeenSelected(true);
        }
    }
    private void ResetMaterial(int id) 
    {
        items[id].GetComponent<Renderer>().material = defaultColor;
        items[id].HasBeenSelected(false);
    }

    // public static void UpdateScore()
    // {
    //     if(time < PlayerPrefs.GetFloat("Highscore",timer))
    //     {
    //         PlayerPrefs.SetFloat("Highscore", Timer.time);
    //     }
    // }
    void Update()
    {
        timer += Time.deltaTime;
        // print(timer);
        

        if(selected.Count == 2) 
        {
            print("ciao");
            if (itemMaterial[selected[0]] == itemMaterial[selected[1]]) 
            {
                Debug.Log("Bingo!");
                matches.Add(selected[0]);
                matches.Add(selected[1]);
                items[selected[0]].HasBeenMatch();
                items[selected[1]].HasBeenMatch();

                if (matches.Count >= row*col) 
                {
                    PlayerPrefs.SetFloat("timer", timer);
                    StartCoroutine(Win());
                    

                }}
            else //ici ne sont pas correct
            {
                print("miao_startcoroutine");
                StartCoroutine(ResetMaterials(selected[0], selected[1]));
                
            }
            selected.Clear();
        }
    }
}

