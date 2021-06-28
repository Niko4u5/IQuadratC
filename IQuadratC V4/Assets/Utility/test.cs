using System;
using UnityEngine;

namespace Utility
{
    public class test : MonoBehaviour
    {
        [SerializeField] private PublicEventWithVar e;
        [SerializeField] private PublicInt i;

        private void OnEnable()
        {
            int id = e.Register(onRaise);
            e.Raise(i);
        }

        private void onRaise(PublicInt  variable)
        {
            int nr = variable.value;
        }
    }
}