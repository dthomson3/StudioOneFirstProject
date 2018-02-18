using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public static class GlobalEventManager {
    public static UnityEventChangeStage ChangeStage = new UnityEventChangeStage();
}
public class ChangeStage
{
}

public class UnityEventChangeStage : UnityEvent<ChangeStage> { }
