using UnityEngine;

public static class DifficulityManager
{
   public static float secondsToMaxDiff = 60f;

   public static float GetDifficultyPercent()
   {
      return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDiff);
   }
}
