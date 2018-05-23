using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubiksCube {

	public List<List<List<Cube>>> cube_matrix_;
    
    public RubiksCube() {
        cube_matrix_ = new List<List<List<Cube>>>();
        
        for (int i = 0; i < 3; i++) {
            List<List<Cube>> cube_rows_ = new List<List<Cube>>();
            for (int j = 0; j < 3; j++) {
                List<Cube> cube_columns_ = new List<Cube>();
                for (int k = 0; k < 3; k++) {
                    Cube cube = new Cube();
                    cube_columns_.Add(cube);
                }
                cube_rows_.Add(cube_columns_);
            }
            cube_matrix_.Add(cube_rows_);
        }
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                cube_matrix_[i][j][0].set_color("FRONT", Cube.RED);
                cube_matrix_[2][i][j].set_color("RIGHT", Cube.BLUE);
                cube_matrix_[0][i][j].set_color("LEFT", Cube.GREEN);
                cube_matrix_[i][j][2].set_color("BACK", Cube.ORANGE);
                cube_matrix_[i][2][j].set_color("TOP", Cube.WHITE);
                cube_matrix_[i][0][j].set_color("BOTTOM", Cube.YELLOW);
            }
        }
    }
    
    public List<List<Cube>> getCubeXYSlice(int pos, bool reference) {
        List<List<Cube>> slice = new List<List<Cube>>();
        for (int i = 0; i < 3; i++) {
            List<Cube> row = new List<Cube>();
            for(int j = 0; j < 3; j++) {
                if (reference) {
                    row.Add(cube_matrix_[i][j][pos]);
                } else {
                    Cube tempcube = new Cube(cube_matrix_[i][j][pos].get_colors());
                    row.Add(tempcube);
                }
            }
            slice.Add(row);
        }
        return slice;
    }
    
    public List<List<Cube>> getCubeYZSlice(int pos, bool reference) {
        List<List<Cube>> slice = new List<List<Cube>>();
        for (int i = 0; i < 3; i++) {
            List<Cube> row = new List<Cube>();
            for(int j = 0; j < 3; j++) {
                if (reference) {
                    row.Add(cube_matrix_[pos][i][j]);
                } else {
                    Cube tempcube = new Cube(cube_matrix_[pos][i][j].get_colors());
                    row.Add(tempcube);
                }
            }
            slice.Add(row);
        }
        return slice;
    }
    
    public List<List<Cube>> getCubeXZSlice(int pos, bool reference) {
        List<List<Cube>> slice = new List<List<Cube>>();
        for (int i = 0; i < 3; i++) {
            List<Cube> row = new List<Cube>();
            for(int j = 0; j < 3; j++) {
                if (reference) {
                    row.Add(cube_matrix_[i][pos][j]);
                } else {
                    Cube tempcube = new Cube(cube_matrix_[i][pos][j].get_colors());
                    row.Add(tempcube);
                }
            }
            slice.Add(row);
        }
        return slice;
    }
    
    public List<Cube> linearize(List<List<Cube>> slice) {
        List<Cube> linear_slice = new List<Cube>();
        for (int i = 0; i < 3; i++) {
            linear_slice.Add(slice[0][i]);
        }
        linear_slice.Add(slice[1][2]);
        for (int i = 2; i >= 0; i--) {
            linear_slice.Add(slice[2][i]);
        }
        linear_slice.Add(slice[1][0]);
        
        return linear_slice;
    }
    
    public void fTurn(bool clockwise) {
        int iterations;
        if (clockwise) {
            iterations = 1;
        } else {
            iterations = 3;
        }
        for (int i = 0; i < iterations; i++) {
            List<Cube> old_linear_front = linearize(getCubeXYSlice(0, false));
            List<Cube> current_linear_front = linearize(getCubeXYSlice(0, true));
            for (int j = 0; j < 8; j++) {
                current_linear_front[(j + 2) % 8].set_colors(old_linear_front[j].get_colors());
                current_linear_front[(j + 2) % 8].zTurn();
            }
        }
    }
    
    public void sTurn(bool clockwise) {
        int iterations;
        if (clockwise) {
            iterations = 1;
        } else {
            iterations = 3;
        }
        for (int i = 0; i < iterations; i++) {
            List<Cube> old_linear_front = linearize(getCubeXYSlice(1, false));
            List<Cube> current_linear_front = linearize(getCubeXYSlice(1, true));
            for (int j = 0; j < 8; j++) {
                current_linear_front[(j + 2) % 8].set_colors(old_linear_front[j].get_colors());
                current_linear_front[(j + 2) % 8].zTurn();
            }
        }
    }
    
    public void bTurn(bool clockwise) {
        int iterations;
        if (clockwise) {
            iterations = 1;
        } else {
            iterations = 3;
        }
        for (int i = 0; i < iterations; i++) {
            List<Cube> old_linear_front = linearize(getCubeXYSlice(2, false));
            List<Cube> current_linear_front = linearize(getCubeXYSlice(2, true));
            for (int j = 0; j < 8; j++) {
                current_linear_front[j].set_colors(old_linear_front[(j + 2) % 8].get_colors());
                current_linear_front[j].zTurn();
                current_linear_front[j].zTurn();
                current_linear_front[j].zTurn();
            }
        }
    }
    
    public void rTurn(bool clockwise) {
        int iterations;
        if (clockwise) {
            iterations = 1;
        } else {
            iterations = 3;
        }
        for (int i = 0; i < iterations; i++) {
            List<Cube> old_linear_front = linearize(getCubeYZSlice(2, false));
            List<Cube> current_linear_front = linearize(getCubeYZSlice(2, true));
            for (int j = 0; j < 8; j++) {
                current_linear_front[j].set_colors(old_linear_front[(j + 2) % 8].get_colors());
                current_linear_front[j].xTurn();
            }
        }
    }
    
    public void mTurn(bool clockwise) {
        int iterations;
        if (clockwise) {
            iterations = 1;
        } else {
            iterations = 3;
        }
        for (int i = 0; i < iterations; i++) {
            List<Cube> old_linear_front = linearize(getCubeYZSlice(1, false));
            List<Cube> current_linear_front = linearize(getCubeYZSlice(1, true));
            for (int j = 0; j < 8; j++) {
                current_linear_front[(j + 2) % 8].set_colors(old_linear_front[j].get_colors());
                current_linear_front[(j + 2) % 8].xTurn();
                current_linear_front[(j + 2) % 8].xTurn();
                current_linear_front[(j + 2) % 8].xTurn();
            }
        }
    }

    public void lTurn(bool clockwise) {
        int iterations;
        if (clockwise) {
            iterations = 1;
        } else {
            iterations = 3;
        }
        for (int i = 0; i < iterations; i++) {
            List<Cube> old_linear_front = linearize(getCubeYZSlice(0, false));
            List<Cube> current_linear_front = linearize(getCubeYZSlice(0, true));
            for (int j = 0; j < 8; j++) {
                current_linear_front[(j + 2) % 8].set_colors(old_linear_front[j].get_colors());
                current_linear_front[(j + 2) % 8].xTurn();
                current_linear_front[(j + 2) % 8].xTurn();
                current_linear_front[(j + 2) % 8].xTurn();
            }
        }
    }
    
    public void uTurn(bool clockwise) {
        int iterations;
        if (clockwise) {
            iterations = 1;
        } else {
            iterations = 3;
        }
        for (int i = 0; i < iterations; i++) {
            List<Cube> old_linear_front = linearize(getCubeXZSlice(2, false));
            List<Cube> current_linear_front = linearize(getCubeXZSlice(2, true));
            for (int j = 0; j < 8; j++) {
                current_linear_front[(j + 2) % 8].set_colors(old_linear_front[j].get_colors());
                current_linear_front[(j + 2) % 8].yTurn();
                current_linear_front[(j + 2) % 8].yTurn();
                current_linear_front[(j + 2) % 8].yTurn();
            }
        }
    }
    
    public void eTurn(bool clockwise) {
        int iterations;
        if (clockwise) {
            iterations = 1;
        } else {
            iterations = 3;
        }
        for (int i = 0; i < iterations; i++) {
            List<Cube> old_linear_front = linearize(getCubeXZSlice(1, false));
            List<Cube> current_linear_front = linearize(getCubeXZSlice(1, true));
            for (int j = 0; j < 8; j++) {
                current_linear_front[j].set_colors(old_linear_front[(j + 2) % 8].get_colors());
                current_linear_front[j].yTurn();
            }
        }
    }
    
    public void dTurn(bool clockwise) {
        int iterations;
        if (clockwise) {
            iterations = 1;
        } else {
            iterations = 3;
        }
        for (int i = 0; i < iterations; i++) {
            List<Cube> old_linear_front = linearize(getCubeXZSlice(0, false));
            List<Cube> current_linear_front = linearize(getCubeXZSlice(0, true));
            for (int j = 0; j < 8; j++) {
                current_linear_front[j].set_colors(old_linear_front[(j + 2) % 8].get_colors());
                current_linear_front[j].yTurn();
            }
        }
    }
    
    public void zTurn(bool clockwise) {
        fTurn(clockwise);
        sTurn(clockwise);
        bTurn(!clockwise);
    }
    
    public void xTurn(bool clockwise) {
        lTurn(clockwise);
        mTurn(clockwise);
        rTurn(!clockwise);
    }
    
    public void yTurn(bool clockwise) {
        dTurn(clockwise);
        eTurn(clockwise);
        uTurn(!clockwise);
    }
}