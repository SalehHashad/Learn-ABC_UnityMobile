using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TGPolyWorld
{
    public class TGPolyAreasPlayer : MonoBehaviour
    {
        public TGPolyAreas PolyAreas;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }


        private void OnTriggerEnter(Collider other)
        {
            if (PolyAreas)
            {
                PolyAreas.CheckTriggerArea(other);
            }
        }


    }

}
