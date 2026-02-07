using UnityEngine;

namespace InventoryFramework
{
    public class InventoryMenuController : MonoBehaviour
    {
        [Header("Menu")]
        public GameObject inventoryRoot;
        public KeyCode toggleKey = KeyCode.E;
        public bool startOpen = false;

        [Header("Cursor")]
        public bool showCursorWhenOpen = true;
        public bool lockCursorWhenClosed = true;

        private bool isOpen;

        void Awake()
        {
            SetOpen(startOpen);
        }

        void Update()
        {
            if (Input.GetKeyDown(toggleKey))
            {
                SetOpen(!isOpen);
            }
        }

        public void SetOpen(bool open)
        {
            isOpen = open;

            if (inventoryRoot != null)
            {
                inventoryRoot.SetActive(isOpen);
            }
            else
            {
                Debug.LogWarning("InventoryMenuController: inventoryRoot is not assigned.");
            }

            ApplyCursorState();
        }

        private void ApplyCursorState()
        {
            if (isOpen && showCursorWhenOpen)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else if (!isOpen && lockCursorWhenClosed)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}
