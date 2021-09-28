using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ParkingBrake
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class ParkingBrake : MonoBehaviour
    {
        private KeyBinding _brakeKey;
        private bool fixKey = false;

        private void Start()
        {
            _brakeKey = GameSettings.BRAKES;
        }

        private void Update()
        {    
            if (_brakeKey.GetKey() && Input.GetKey(KeyCode.LeftAlt)) {
                //ScreenMessages.PostScreenMessage("Parking brake triggered", 3);
                FlightGlobals.ActiveVessel.ActionGroups.ToggleGroup(KSPActionGroup.Brakes);
                fixKey = true;
            }
            if (fixKey && !_brakeKey.GetKey())
            {
                FlightGlobals.ActiveVessel.ActionGroups.SetGroup(KSPActionGroup.Brakes, true);
                fixKey = false;
            }

            /*bool testKey = Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.T);
            if (testKey){
                ScreenMessages.PostScreenMessage("ParkingBrake test key pressed", 3);
            }*/
        }
    }
}