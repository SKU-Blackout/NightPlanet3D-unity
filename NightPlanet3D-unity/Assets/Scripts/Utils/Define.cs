using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum Scene
    {
        Unknown,
        Sample,
        Tutorial,

    }

    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,//사운드 종류의 총 갯수를 알기위함
    }

    public enum UIEvent
    {
        Click,
        Drag,
    }

    public enum MouseEvent
    {
        Press,
        Click,
    }

    public enum ItemID
    {
        wood,
        fabric,
        lighter,
        Count,
    }

}
