using System.Collections;
using UnityEngine;

namespace Code.Infrastucture
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}