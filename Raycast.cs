using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Raycast : MonoBehaviour
{
    public GameObject BalaPrin;
    public GameObject SpawnBala;
    public float range = 10f;

    public TMP_Text bala;
    public float balas = 30;

    public TMP_Text cargador;
    public float ccargador = 3;

    private bool disparando = false;
    //public GameObject efectoOri;


    //private Recoil Recoil_Script;




    // Start is called before the first frame update
    void Start()
    {
        bala.text = "" + balas;
        cargador.text = "" + ccargador;

        //Recoil_Script = transform.Find("CameraRot/CameraRecoil").GetComponent<Recoil>();
        
    }

    // Update is called once per frame
    void Update()
    {

        //Cuando aprete el mouse saldran las balas y si toca a Enemy lo destruira
        if (Input.GetKey(KeyCode.Mouse0) && disparando == false)
        {
            StartCoroutine(DisparoC());
            RaycastHit resultRayo;

             //Recoil
            //Recoil_Script.RecoilFire();

            if (Physics.Raycast(this.transform.position, this.transform.forward, out resultRayo, 1000))
            {
                Instantiate(BalaPrin, SpawnBala.transform.position, this.transform.rotation);
                

                //Instantiate(efectoOri, resultRayo.point, this.transform.rotation);

                //Debug.Log(resultRayo.transform.name);
                //if (resultRayo.transform.CompareTag("Enemy"))
                //{
                //    Destroy(resultRayo.transform.gameObject);

                //}

            }
        }
    }

    IEnumerator DisparoC()
    {
        disparando = true;
        balas = balas - 1;
        bala.text = "" + balas;
        yield return new WaitForSeconds(0.15f);
        disparando = false;

        if (balas <= 0)
        {
            Debug.Log(3);
            balas = 30;
            ccargador = ccargador-1;
            cargador.text = "" + ccargador;
            bala.text = "" + balas;
            if (ccargador <= 0)
            {
                Debug.Log(1);
                //balas = 0;
                ccargador = 0;
                cargador.text = "" + ccargador;
                
                //bala.text = "" + balas;
                if (balas <= 30 )
                {
                    disparando = true;
                    balas = 0;
                    Debug.Log(2);                 
                    Debug.Log("encuentra balas");                  
                    ccargador = 0;
                    cargador.text = "" + ccargador;
                    bala.text = "" + balas;
                   
                }

            }
        }
        // Sí nos quedamos sin cargadores y sin balas no seguira disparando 
       

       
        
      

      
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "disco")
        {

            ccargador = ccargador + 1;
            cargador.text = "" + ccargador;
            balas = 30;
            bala.text = "" + balas;
            Debug.Log("balas");
            Destroy(other.gameObject);
            //para que pueda volver a disprar
            disparando = false;

        }

        
        
        
    }

    

 /*   private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * range);
        } */
    }
