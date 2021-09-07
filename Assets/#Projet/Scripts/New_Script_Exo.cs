using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_Script_Exo : MonoBehaviour
{

    public bool mouseOver = false;
    // public int id= -1;
    // public Level_Manager manager;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
      
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
}