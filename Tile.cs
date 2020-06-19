using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class Tile
{
    
    public enum Type {Water, Ground, Ant, AntHill, AntWithFood, Food};

    public Type type;

    public static readonly List<Type> InaccessableTypes = new List<Tile.Type>()
    {
        Type.Ant,
        Type.AntWithFood,
        Type.Food,
        Type.Water
    };

    public static readonly List<Type> AllTileTypes = new List<Type>()
    {
        Type.Water,
        Type.Ground,
        Type.Ant,
        Type.AntHill,
        Type.AntWithFood,
        Type.Food
    };

    public static readonly List<Type> AccessableTypes = AllTileTypes.Where(x => !InaccessableTypes.Contains(x)).ToList();

}


