using Game.Scripts.Moves;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using Zenject;

public class LoseScreen : MonoBehaviour
{
    public void Open()
    {
        gameObject.SetActive(true);
    }
}
