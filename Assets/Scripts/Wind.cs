using UnityEngine;

public class Wind : MonoBehaviour
{
    public float pushForce = 7f;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody playerRb = other.GetComponent<Rigidbody>();

            if (playerRb != null)
            {
                // Вектор направления, в котором смотрит игрок
                Vector3 playerDirection = other.transform.forward;

                // Скалярное произведение для определения направления
                float dotProduct = Vector3.Dot(playerDirection, Vector3.forward); // Направление вперед

                if (dotProduct > 0) // Игрок движется вперед
                {
                    // Толкать влево
                    Vector3 leftPush = -other.transform.right * pushForce;
                    playerRb.linearVelocity = new Vector3(leftPush.x, playerRb.linearVelocity.y, leftPush.z); // Изменяем скорость по оси X
                }
                else if (dotProduct < 0) // Игрок движется назад
                {
                    // Толкать вправо
                    Vector3 rightPush = other.transform.right * pushForce;
                    playerRb.linearVelocity = new Vector3(rightPush.x, playerRb.linearVelocity.y, rightPush.z); // Изменяем скорость по оси X
                }
            }
        }
    }
}
