using UnityEngine;
using System.Collections;

public class MovimientoPorZona : MonoBehaviour
{
    public Transform zonaMovimiento;
    public float velocidad = 8f;
    public float rangoDetencion = 0.1f;
    public float tiempoEspera = 2f;
    public Vector3 objetivo;
    public bool movimiento = true;

    void Start()
    {
        StartCoroutine(MovimientoPorTiempo());        
    }

    private IEnumerator MovimientoPorTiempo(){
        ElegirNuevoDestino();

        while(true){
            yield return new WaitForSeconds(tiempoEspera);
            ElegirNuevoDestino();
        }
    }

    private void ElegirNuevoDestino(){
        //elegir la posición hacia donde se dirige la gallina
        Vector3 centro = zonaMovimiento.position;
        Vector3 escala = zonaMovimiento.localScale;

        float x = Random.Range(centro.x - escala.x /2, centro.x + escala.x /2);
        float y = Random.Range(centro.y - escala.y /2, centro.y + escala.y /2);
        float z =  transform.position.z;

        objetivo = new Vector3(x,y,z);
        movimiento = true;

    }

    void Update()
    {
        if(movimiento){
            transform.position =  Vector3.MoveTowards( transform.position, objetivo, velocidad* Time.deltaTime);

            if(Vector3.Distance(transform.position, objetivo) < rangoDetencion){
                movimiento = false;
            }
        }
    }
}
