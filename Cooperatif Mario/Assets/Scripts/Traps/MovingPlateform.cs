using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlateform : MonoBehaviour
{
    public GameObject plateform;

    public float LeftDeplacement, RightDeplacement, TimeDeplacement;
    public DirectionPlateform direction;

    public enum DirectionPlateform { Verticale, Horizontale };

    private float deltaDepla;
    [SerializeField] private float posIni;

    private void Start()
    {
        deltaDepla = LeftDeplacement + RightDeplacement;
        if (direction == DirectionPlateform.Verticale)
            posIni = this.transform.position.y;
        else
            posIni = this.transform.position.x;
    }
    // Update is called once per frame
    void Update()
    {
        if (direction == DirectionPlateform.Verticale)
            plateform.transform.position = new Vector3(plateform.transform.position.x, Mathf.PingPong(Time.time * deltaDepla / TimeDeplacement, deltaDepla) + (posIni - LeftDeplacement), plateform.transform.position.z);
        else
        {
            if (posIni < 0)
            {
                plateform.transform.position = new Vector3((Mathf.PingPong(Time.time * deltaDepla / TimeDeplacement, deltaDepla) + (Mathf.Abs(posIni) - LeftDeplacement)) * -1, plateform.transform.position.y, plateform.transform.position.z);
            }
            else
            {
                plateform.transform.position = new Vector3(Mathf.PingPong(Time.time * deltaDepla / TimeDeplacement, deltaDepla) + (posIni - LeftDeplacement), plateform.transform.position.y, plateform.transform.position.z);
            }
        }
    }

}
