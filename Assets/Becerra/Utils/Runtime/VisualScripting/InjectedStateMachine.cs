﻿using Becerra.Utils.VisualScripting.CustomEvents;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Becerra.Game.VisualScripting
{
    [RequireComponent(typeof(StateMachine))]
    public class InjectedStateMachine : MonoBehaviour
    {
        [Inject]
        private void OnInjected(DiContainer zenject)
        {
            var machine = GetComponent<StateMachine>();
            var reference = GraphReference.New(machine, true);

            reference.graph.InjectGraph(zenject);

            EventBus.Trigger<bool>(InjectedEvent.EventName, this.gameObject, true);
        }
    }
}