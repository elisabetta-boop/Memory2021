using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Behaviour : MonoBehaviour
{

    public bool mouseOver = false;
    public int id= -1;
    public Level_Manager manager;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
        
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
        // transform.localScale = new Vector3(1,2,1);
        mouseOver = true;
        animator.SetBool("MouseOver", true);
    }
    void OnMouseExit()
    {
        // transform.localScale = Vector3.one;
        mouseOver = false;
        animator.SetBool("MouseOver", false);
    }
    public void HasBeenSelected(bool selected) 
    {
        animator.SetBool("ItemSelected", selected);
        // animator.SetBool("MouseOver", false);
    }
    public void HasBeenMatch() 
    {
        animator.SetBool("Item_Match", true);
    }
}