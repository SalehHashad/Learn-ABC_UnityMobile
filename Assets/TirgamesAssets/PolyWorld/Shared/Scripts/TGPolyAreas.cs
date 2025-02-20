using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TGPolyWorld
{
    [ExecuteInEditMode]
    public class TGPolyAreas : MonoBehaviour
    {
        [System.Serializable]
        public class PolyArea
        {
            public string Name;
            public string TagName;
            public List<Transform> ShowItems = new List<Transform>();
            public List<Transform> HideItems = new List<Transform>();
        }

        public List<PolyArea> Areas = new List<PolyArea>();
        [SerializeField, Range(0, 2)] // Adjust the range to your needs
        private int activeAreaID=0;
        // Property to get and set ActiveAreaID
        public int ActiveAreaID
        {
            get { return activeAreaID; }
            set
            {
                if (activeAreaID != value)
                {
                    activeAreaID = value; // Ensure the value stays within the range
                    SetActiveArea(activeAreaID);
                }
            }
        }

        public int DefaultArea=0;


        // Start is called before the first frame update
        void Start()
        {
            ActiveAreaID = DefaultArea;
        }

        // Update is called once per frame
        void Update()
        {
        }

        // This method will be called when ActiveAreaID is changed in the Inspector
        private void OnValidate()
        {
            SetActiveArea(activeAreaID);
        }

        public void CheckTriggerArea(Collider col)
        {
            int i= 0;
            foreach (PolyArea area in Areas) {
                if (area.TagName != "") {
                    if (col.CompareTag(area.TagName))
                    {
                        ActiveAreaID=i;
                        return;
                    }
                }
                i++;
            }

        }


        private void SetActiveArea(int areaID)
        {
            if (areaID < Areas.Count)
            {
                foreach (Transform item in Areas[areaID].ShowItems)
                {
                    item.gameObject.SetActive(true);
                }

                foreach (Transform item in Areas[areaID].HideItems)
                {
                    item.gameObject.SetActive(false);
                }
            }
        }


    }


}