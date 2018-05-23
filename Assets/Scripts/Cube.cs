using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube {
    
    // Define colors for the six sides of the rubiks cube and a base color
    public static Color BLUE { get { return Color.blue; } }
    public static Color RED { get { return Color.red; } }
    public static Color GREEN { get { return Color.green; } }
    public static Color YELLOW { get { return Color.yellow; } }
    public static Color BLACK { get { return Color.black; } }
    public static Color WHITE { get { return Color.white; } }
    public static Color ORANGE { get { return new Color(1.0F, 0.5F, 0.0F); } }
    
    // List of all colors
    public List<Color> colors_ = new List<Color>();
    
    /* Dictionary for all of the sides of the cube
    * I decided that 0 would be the top and 5 would be the bottom and 1 through 5 would be the face  * sides going clockwise around the cube starting at the front.
    */
    public Dictionary<string, int> side_dict_ = new Dictionary<string, int>() {
        {"TOP", 0},
        {"FRONT", 1},
        {"LEFT", 2},
        {"BACK", 3},
        {"RIGHT", 4},
        {"BOTTOM", 5},
    };
    
	// Argumentless constructor for the cube
    public Cube()
    {
        for (int i = 0; i < 6; i++) {
            AddColor(BLACK);
        }
    }
    
    // Cube constructor given a list of colors
    public Cube(List<Color> colors) {
        for (int i = 0; i < 6; i++) {
            AddColor(BLACK);
        }
        for (int i = 0; i < colors.Count; i++) {
            set_color(i, colors[i]);
        }
    }
    
    public List<Color> get_colors() {
        List<Color> tempcolors = new List<Color>();
        for (int i = 0; i < colors_.Count; i++) {
            tempcolors.Add(colors_[i]);
        }
        return tempcolors;
    }
    
    public void set_colors(List<Color> colors) {
        for (int i = 0; i < 6; i ++) {
            set_color(i, colors[i]);
        }
    }
    
    /*  Since a face piece must only have one non-black side, an edge piece must have two non-black
    * sides and a corner pieces must have three non-black sides, the identity of a given cube can be
    * ascertained by the number of non-black faces on the cube
    */
    public int get_color_count() {
        int count = 0;
        for (int i = 0; i < 6; i++) {
            if (get_color(i) != BLACK) {
                count ++;
            }
        }
        return count;
    }
    
    public void yTurn() {
        List<Color> old_colors = get_colors();
        set_color("FRONT", old_colors[side_dict_["LEFT"]]);
        set_color("RIGHT", old_colors[side_dict_["FRONT"]]);
        set_color("BACK", old_colors[side_dict_["RIGHT"]]);
        set_color("LEFT", old_colors[side_dict_["BACK"]]);
    }
    
    public void xTurn() {
        List<Color> old_colors = get_colors();
        set_color("TOP", old_colors[side_dict_["FRONT"]]);
        set_color("BACK", old_colors[side_dict_["TOP"]]);
        set_color("BOTTOM", old_colors[side_dict_["BACK"]]);
        set_color("FRONT", old_colors[side_dict_["BOTTOM"]]);
    }
    
    public void zTurn() {
        List<Color> old_colors = get_colors();
        set_color("TOP", old_colors[side_dict_["LEFT"]]);
        set_color("RIGHT", old_colors[side_dict_["TOP"]]);
        set_color("BOTTOM", old_colors[side_dict_["RIGHT"]]);
        set_color("LEFT", old_colors[side_dict_["BOTTOM"]]);
    }
    
    // getter and setter methods for the color of a side
    public Color get_color(string side) {
        return colors_[side_dict_[side]];
    }
    
    // overloaded getter and setter methods using int instead of string
    public Color get_color(int side) {
        return colors_[side];
    }
    
    public void set_color(string side, Color color) {
        colors_[side_dict_[side]] = color;
    }
    
    public void set_color(int side, Color color) {
        colors_[side] = color;
    }
    
    public void AddColor(Color color) {
        colors_.Add(color);
    }
}
