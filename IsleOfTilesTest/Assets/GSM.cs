using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSM : MonoBehaviour {
    public int x = 1;

    private void Awake() {
        God.GSM = this;
    }
}
