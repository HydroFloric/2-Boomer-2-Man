using UnityEngine;

namespace ModularOptions {
	/// <summary>
	/// Little utility script for disabling Options Menu in Start, after initialization (which happens during Awake).
	/// </summary>
	[AddComponentMenu("Modular Options/Misc/Disable On Start")]
	public class DisableOnStart : MonoBehaviour {
        [SerializeField] private intSO coins;
        void Start(){
			coins.coin = 0;
			gameObject.SetActive(false);
			

        }
	}
}
