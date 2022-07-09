using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaEnemy : MonoBehaviour
{
    public float puntos = 0;
    public float enemigovida = 20;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Perdera vida al chocar con los enemigos
        if (collision.gameObject.tag == "bala")
        {
            enemigovida = enemigovida -  10;
           
            //vidat.text = "Vida =" + vida;
            Debug.Log(enemigovida);
            
            Destroy(collision.gameObject);
            if (enemigovida <= 0)
            {
                puntos = puntos + 5;
                Destroy(this.gameObject);
                Debug.Log(puntos);
                //SceneManager.LoadScene("GameOver");
            }
        }
    }
}
