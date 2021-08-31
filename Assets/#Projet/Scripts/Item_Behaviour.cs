using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Behaviour : MonoBehaviour
{

    public bool mouseOver = false;
    public int id= -1;
    public Level_Manager manager;
    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0)&& mouseOver) 
        {
            Debug.Log($"Click: {id}");
            manager.RevealMaterial(id);
        }
    }
    void OnMouseOver() 
    {
        transform.localScale = new Vector3(1,2,1);
        mouseOver = true;
    }
    void OnMouseExit()
    {
        transform.localScale = Vector3.one;
        mouseOver = false;
    }
}