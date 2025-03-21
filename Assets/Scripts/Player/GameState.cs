using UnityEngine;

namespace TinyBoat
{
    
    public static class GameState
    {
        public static float windRotation = 180.0f;

        public enum States
        {
            menu,
            gameplay,
            endgame
        };

        public static States State = States.menu;

        public static int BestScore = 0;
        public static int Score = 0;

        public static int PointsMultiplier = 1;

        static GameState()
        {
        }

        public static void SetWindRotation(float rotation)
        {
            windRotation = Mathf.Clamp(rotation, 0.0f, 180.0f);
        }

        public static void AddPoints(int points)
        {
            Score += points * PointsMultiplier;
            if (Score > BestScore)
            {
                BestScore = Score;
            }
        }
    }
}
