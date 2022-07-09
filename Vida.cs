using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Vida : MonoBehaviour
{

    public TMP_Text pvida;
    public float vida = 100;

    Raycast raycast;
    // Start is called before the first frame update
    void Start()
    {
       
        pvida.text = ""+vida;
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Perdera vida al chocar con los enemigos
        if (collision.gameObject.tag == "BEnemy")
        {
            vida = vida - 10;
            pvida.text = "" + vida;
            Debug.Log(vida);
            if (vida <= 0)
            {
                SceneManager.LoadScene("Derrota");
            }

         
        }

        if (collision.gameObject.tag == "Botiquin")
        {
            vida = vida + 50;
            pvida.text = "" + vida;
            Debug.Log(vida);
            Destroy(collision.gameObject);


        }






    }
}
