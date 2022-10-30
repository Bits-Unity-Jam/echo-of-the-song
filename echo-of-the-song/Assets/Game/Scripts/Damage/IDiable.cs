using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDiable
{
    public void Die();
    public event Action OnDie;
}
