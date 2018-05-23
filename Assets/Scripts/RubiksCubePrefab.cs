using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubiksCubePrefab : MonoBehaviour {
    
    public GameObject cube_prefab_;
    
    public RubiksCube rubiks_cube_;
    
    public List<List<List<GameObject>>> cube_prefab_matrix_;

	// Use this for initialization
	void Start () {
        rubiks_cube_ = new RubiksCube();
        
        cube_prefab_matrix_ = new List<List<List<GameObject>>>();
        for (int i = 0; i < 3; i++) {
            List<List<GameObject>> prefab_rows_ = new List<List<GameObject>>();
            for (int j = 0; j < 3; j++) {
                List<GameObject> prefab_columns_ = new List<GameObject>();
                for (int k = 0; k < 3; k++) {
                    GameObject temp_cube_prefab_ = Instantiate(cube_prefab_, Vector3.zero, Quaternion.identity) as GameObject;
                    temp_cube_prefab_.transform.SetParent(transform);
                    temp_cube_prefab_.transform.position = new Vector3((i - 1), (j -1), (k - 1)) * 1.05f;
                    prefab_columns_.Add(temp_cube_prefab_);
                }
                prefab_rows_.Add(prefab_columns_);
            }
            cube_prefab_matrix_.Add(prefab_rows_);
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++)             {
                for (int k = 0; k < 3; k++) {
                    cube_prefab_matrix_[i][j][k].GetComponent<CubePrefab>().refreshCubes(rubiks_cube_.cube_matrix_[i][j][k]);
                }
            }
        }
	}
}
