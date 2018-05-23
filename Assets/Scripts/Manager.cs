using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

	public RubiksCubePrefab rubiks_cube_prefab_;
    
    private IEnumerator coroutine;
    
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.U)) {
            if (coroutine != null) {
                StopCoroutine(coroutine);
            }
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
                coroutine = animate_rubiks_cube('u', -1);
            } else {
                coroutine = animate_rubiks_cube('u', 1);
            }
            StartCoroutine(coroutine);
        } else if (Input.GetKeyDown(KeyCode.L)) {
            if (coroutine != null) {
                StopCoroutine(coroutine);
            }
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
                coroutine = animate_rubiks_cube('l', -1);
            } else {
                coroutine = animate_rubiks_cube('l', 1);
            }
            StartCoroutine(coroutine);
        } else if (Input.GetKeyDown(KeyCode.F)) {
            if (coroutine != null) {
                StopCoroutine(coroutine);
            }
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
                coroutine = animate_rubiks_cube('f', -1);
            } else {
                coroutine = animate_rubiks_cube('f', 1);
            }
            StartCoroutine(coroutine);
        } else if (Input.GetKeyDown(KeyCode.R)) {
            if (coroutine != null) {
                StopCoroutine(coroutine);
            }
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
                coroutine = animate_rubiks_cube('r', -1);
            } else {
                coroutine = animate_rubiks_cube('r', 1);
            }
            StartCoroutine(coroutine);
        } else if (Input.GetKeyDown(KeyCode.B)) {
            if (coroutine != null) {
                StopCoroutine(coroutine);
            }
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
                coroutine = animate_rubiks_cube('b', -1);
            } else {
                coroutine = animate_rubiks_cube('b', 1);
            }
            StartCoroutine(coroutine);
        } else if (Input.GetKeyDown(KeyCode.D)) {
            if (coroutine != null) {
                StopCoroutine(coroutine);
            }
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
                coroutine = animate_rubiks_cube('d', -1);
            } else {
                coroutine = animate_rubiks_cube('d', 1);
            }
            StartCoroutine(coroutine);
        } else if (Input.GetKeyDown(KeyCode.M)) {
            if (coroutine != null) {
                StopCoroutine(coroutine);
            }
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
                coroutine = animate_rubiks_cube('m', -1);
            } else {
                coroutine = animate_rubiks_cube('m', 1);
            }
            StartCoroutine(coroutine);
        } else if (Input.GetKeyDown(KeyCode.E)) {
            if (coroutine != null) {
                StopCoroutine(coroutine);
            }
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
                coroutine = animate_rubiks_cube('e', -1);
            } else {
                coroutine = animate_rubiks_cube('e', 1);
            }
            StartCoroutine(coroutine);
        } else if (Input.GetKeyDown(KeyCode.S)) {
            if (coroutine != null) {
                StopCoroutine(coroutine);
            }
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
                coroutine = animate_rubiks_cube('s', -1);
            } else {
                coroutine = animate_rubiks_cube('s', 1);
            }
            StartCoroutine(coroutine);
        } else if (Input.GetKeyDown(KeyCode.X)) {
            if (coroutine != null) {
                StopCoroutine(coroutine);
            }
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
                coroutine = animate_rubiks_cube('x', -1);
            } else {
                coroutine = animate_rubiks_cube('x', 1);
            }
            StartCoroutine(coroutine);
        } else if (Input.GetKeyDown(KeyCode.Y)) {
            if (coroutine != null) {
                StopCoroutine(coroutine);
            }
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
                coroutine = animate_rubiks_cube('y', -1);
            } else {
                coroutine = animate_rubiks_cube('y', 1);
            }
            StartCoroutine(coroutine);
        } else if (Input.GetKeyDown(KeyCode.Z)) {
            if (coroutine != null) {
                StopCoroutine(coroutine);
            }
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
                coroutine = animate_rubiks_cube('z', -1);
            } else {
                coroutine = animate_rubiks_cube('z', 1);
            }
            StartCoroutine(coroutine);
        } else if (Input.GetKeyDown(KeyCode.Delete)) {
            if (coroutine != null) {
                StopCoroutine(coroutine);
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    
    public IEnumerator animate_rubiks_cube(char turn, int dir) {
        transform.rotation = Quaternion.identity;
        transform.position = Vector3.zero;
        float total_rotation = 0;
        float delta = 0;
        bool clockwise = true;
        if (dir == -1) {
            clockwise = false;
        }
        switch (turn) {
            case 'u' :
                while (Mathf.Abs(total_rotation) < 90) {
                    delta = dir * 40 * Time.deltaTime;
                    total_rotation += delta;
                    for (int i = 0; i < 3; i++) { for (int j = 0; j < 3; j++) { rubiks_cube_prefab_.cube_prefab_matrix_[i][2][j].transform.RotateAround(transform.position, transform.up, delta); } }
                    yield return null;
                }
                rubiks_cube_prefab_.rubiks_cube_.uTurn(clockwise);
                break;
            case 'l' :
                while (Mathf.Abs(total_rotation) < 90) {
                    delta = -1 * dir * 40 * Time.deltaTime;
                    total_rotation += delta;
                    for (int i = 0; i < 3; i++) { for (int j = 0; j < 3; j++) { rubiks_cube_prefab_.cube_prefab_matrix_[0][i][j].transform.RotateAround(transform.position, transform.right, delta); } }
                    yield return null;
                }
                rubiks_cube_prefab_.rubiks_cube_.lTurn(clockwise);
                break;
            case 'f' :
				while (Mathf.Abs(total_rotation) < 90) {
					delta = -1 * dir * 40 * Time.deltaTime;
					total_rotation += delta;
					for (int i = 0; i < 3; i++) { for (int j = 0; j < 3; j++) { rubiks_cube_prefab_.cube_prefab_matrix_[i][j][0].transform.RotateAround(transform.position, transform.forward, delta); } }
					yield return null;
				}
                rubiks_cube_prefab_.rubiks_cube_.fTurn(clockwise);
                break;
            case 'r' :
                while (Mathf.Abs(total_rotation) < 90) {
                    delta = dir * 40 * Time.deltaTime;
                    total_rotation += delta;
                    for (int i = 0; i < 3; i++) { for (int j = 0; j < 3; j++) { rubiks_cube_prefab_.cube_prefab_matrix_[2][i][j].transform.RotateAround(transform.position, transform.right, delta); } }
                    yield return null;
                }
                rubiks_cube_prefab_.rubiks_cube_.rTurn(clockwise);
                break;
            case 'b' :
                while (Mathf.Abs(total_rotation) < 90) {
                    delta = dir * 40 * Time.deltaTime;
                    total_rotation += delta;
                    for (int i = 0; i < 3; i++) { for (int j = 0; j < 3; j++) { rubiks_cube_prefab_.cube_prefab_matrix_[i][j][2].transform.RotateAround(transform.position, transform.forward, delta); } }
                    yield return null;
                }
                rubiks_cube_prefab_.rubiks_cube_.bTurn(clockwise);
                break;
            case 'd' :
                while (Mathf.Abs(total_rotation) < 90) {
                    delta = -1 * dir * 40 * Time.deltaTime;
                    total_rotation += delta;
                    for (int i = 0; i < 3; i++) { for (int j = 0; j < 3; j++) { rubiks_cube_prefab_.cube_prefab_matrix_[i][0][j].transform.RotateAround(transform.position, transform.up, delta); } }
                    yield return null;
                }
                rubiks_cube_prefab_.rubiks_cube_.dTurn(clockwise);
                break;
            case 'm' :
                while (Mathf.Abs(total_rotation) < 90) {
                    delta = -1 * dir * 40 * Time.deltaTime;
                    total_rotation += delta;
                    for (int i = 0; i < 3; i++) { for (int j = 0; j < 3; j++) { rubiks_cube_prefab_.cube_prefab_matrix_[1][i][j].transform.RotateAround(transform.position, transform.right, delta); } }
                    yield return null;
                }
                rubiks_cube_prefab_.rubiks_cube_.mTurn(clockwise);
                break;
            case 'e' :
                while (Mathf.Abs(total_rotation) < 90) {
                    delta = -1 * dir * 40 * Time.deltaTime;
                    total_rotation += delta;
                    for (int i = 0; i < 3; i++) { for (int j = 0; j < 3; j++) { rubiks_cube_prefab_.cube_prefab_matrix_[i][1][j].transform.RotateAround(transform.position, transform.up, delta); } }
                    yield return null;
                }
                rubiks_cube_prefab_.rubiks_cube_.eTurn(clockwise);
                break;
            case 's' :
                while (Mathf.Abs(total_rotation) < 90) {
                    delta = -1 * dir * 40 * Time.deltaTime;
                    total_rotation += delta;
                    for (int i = 0; i < 3; i++) { for (int j = 0; j < 3; j++) { rubiks_cube_prefab_.cube_prefab_matrix_[i][j][1].transform.RotateAround(transform.position, transform.forward, delta); } }
                    yield return null;
                }
                rubiks_cube_prefab_.rubiks_cube_.sTurn(clockwise);
                break;
            case 'x' :
                while (Mathf.Abs(total_rotation) < 90) {
                    delta = -1 * dir * 40 * Time.deltaTime;
                    total_rotation += delta;
                    rubiks_cube_prefab_.transform.RotateAround(transform.position, transform.right, delta);
                    yield return null;
                }
                rubiks_cube_prefab_.rubiks_cube_.xTurn(clockwise);
                break;
            case 'y' :
                while (Mathf.Abs(total_rotation) < 90) {
                    delta = -1 * dir * 40 * Time.deltaTime;
                    total_rotation += delta;
                    rubiks_cube_prefab_.transform.RotateAround(transform.position, transform.up, delta);
                    yield return null;
                }
                rubiks_cube_prefab_.rubiks_cube_.yTurn(clockwise);
                break;
            case 'z' :
                while (Mathf.Abs(total_rotation) < 90) {
                    delta = -1 * dir * 40 * Time.deltaTime;
                    total_rotation += delta;
                    rubiks_cube_prefab_.transform.RotateAround(transform.position, transform.forward, delta);
                    yield return null;
                }
                rubiks_cube_prefab_.rubiks_cube_.zTurn(clockwise);
                break;
            default :
                break;
        }
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                for (int k = 0; k < 3; k++) {
                    rubiks_cube_prefab_.cube_prefab_matrix_[i][j][k].transform.position = new Vector3((i - 1), (j - 1), (k - 1)) * 1.05f;
                    rubiks_cube_prefab_.cube_prefab_matrix_[i][j][k].transform.rotation = Quaternion.identity;
                }
            }
        }
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                for (int k = 0; k < 3; k++) {
                    rubiks_cube_prefab_.cube_prefab_matrix_[i][j][k].GetComponent<CubePrefab>().refreshCubes(rubiks_cube_prefab_.rubiks_cube_.cube_matrix_[i][j][k]);
                }
            }
        }
    }
}
