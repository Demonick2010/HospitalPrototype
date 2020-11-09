using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Needed variables ------ //
    private int _score;
    private float _lifePoints;
    // ----------------------- //

    // Access methods -------- //
    public int Score
    {
        get { return _score; }
        set { _score = value; }
    }
    public float LifePoints
    {
        get { return _lifePoints; }
        set { _lifePoints = value; }
    }
    // ----------------------- //
}
