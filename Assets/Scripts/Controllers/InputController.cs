
using UniRx;
using UnityEngine;

namespace InnovecsTest
{
    public class InputController : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;
                MessageBroker.Default.Publish(new HeroClickedMessage { Position = mousePosition });
            }
        }
    }
}
