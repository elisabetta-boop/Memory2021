using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Display_Time : MonoBehaviour
{
    public TextMeshProUGUI tmpText;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        float time = PlayerPrefs.GetFloat("timer",0f);
        tmpText.text = "Time:\n" + time.ToString("N2");
        if (time <= 10f) 
        {
            animator.SetBool("Win", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
