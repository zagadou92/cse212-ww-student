using System;
using System.Collections.Generic;

public class Maze
{
    private readonly int _width;
    private readonly int _height;
    private readonly int[] _mazeMap;

    // Constructeur calqué à 100% sur l'instanciation de vos tests : (width, height, mazeMap)
    public Maze(int width, int height, int[] mazeMap)
    {
        _width = width;
        _height = height;
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Vérifie si les coordonnées données représentent la case finale (valeur 2)
    /// </summary>
    public bool IsEnd(int x, int y)
    {
        int index = (y * _width) + x;
        return _mazeMap[index] == 2;
    }

    /// <summary>
    /// Détermine si un déplacement vers (x, y) est valide dans la grille.
    /// </summary>
    public bool IsValidMove(int x, int y, List<ValueTuple<int, int>> currPath)
    {
        // 1. Contrôle des limites de la grille
        if (x < 0 || x >= _width || y < 0 || y >= _height)
        {
            return false;
        }

        // 2. Contrôle de collision avec les murs (0 = Wall)
        int index = (y * _width) + x;
        if (_mazeMap[index] == 0)
        {
            return false;
        }

        // 3. Empêche de revenir sur une case déjà présente dans le chemin
        if (currPath.Contains((x, y)))
        {
            return false;
        }

        return true;
    }
}
