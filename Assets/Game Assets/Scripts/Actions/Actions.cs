using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Actions 
{
    public static Action<EnemyBehaviour> OnEnemyKilled;
    public static Action<float> OnPlayerDamaged;
    public static Action<int, EndGameUI> AchievementCheck;
}
