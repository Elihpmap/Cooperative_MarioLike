using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlateform : MonoBehaviour
{
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
            this.transform.position = new Vector3(this.transform.position.x, Mathf.PingPong(Time.time * deltaDepla / TimeDeplacement, deltaDepla) + (posIni - LeftDeplacement), this.transform.position.z);
        else
        {
            if (posIni < 0)
            {
                this.transform.position = new Vector3((Mathf.PingPong(Time.time * deltaDepla / TimeDeplacement, deltaDepla) + (Mathf.Abs(posIni) - LeftDeplacement)) * -1, this.transform.position.y, this.transform.position.z);
            }
            else
            {
                this.transform.position = new Vector3(Mathf.PingPong(Time.time * deltaDepla / TimeDeplacement, deltaDepla) + (posIni - LeftDeplacement), this.transform.position.y, this.transform.position.z);
            }
        }
    }

}
