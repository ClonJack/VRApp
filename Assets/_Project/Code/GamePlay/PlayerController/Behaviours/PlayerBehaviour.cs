using BNG;
using TriInspector;
using UnityEngine;

namespace _Project.Code.GamePlay.PlayerController
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [field: Title("Bng Reference"), SerializeField]
        public ScreenFader ScreenFader { get; private set; }
    }
}