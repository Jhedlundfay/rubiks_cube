using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePrefab : MonoBehaviour {

	public List<GameObject> cubes_ = new List<GameObject>();
    
    public void refreshCubes(Cube c) {
        for (int i = 0; i < 6; i++) {
            Renderer renderer_ = cubes_[i].GetComponent<Renderer>();
            renderer_.enabled = true;
            renderer_.material.color = c.get_colors()[i];
        }
    }
}
