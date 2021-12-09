using Gameplay.Helpers;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int score = 0;

    public void ApplyExp()
    {
        GlobalParams.Instance.ApplyScore(score);    
    }
}