using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

static class StaticScript
{
    public static int score = 0;
    public static bool playingOrNot = false;
    public static float timePrevious=0;
    public static float timeElapsed=0;
    public static int _poopsUsed=0;
    public static int enemies_killed=0;
    public static int no_of_enemies = 3;
    public static float timeLeft = 0;
    public static bool timerOn = false;
    public static int no_of_poops = 10;
    public static int health = 100;
    public static int level = 0;
    public static int success_or_fail=-1;
    public static int lines_drawn=0;
    public static int lines_limit = 3;
    public static int no_color_switches=0;
    public static int no_of_erasers = 3;

    public static int tutorialStep = 0;
}
