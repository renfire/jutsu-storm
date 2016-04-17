using UnityEngine;
using System.Collections;

public class MeleEnemy : MonoBehaviour {

	void Awake () {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
	
}
