using System.IO.Pipes;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Player player;
    
    private Plane aimPlane = new Plane(Vector3.up, new Vector3());
   
    // Update is called once per frame
    void Update()
    {
        player.SetThrottle(Input.GetAxis("Vertical"));
        player.Turn(Input.GetAxis("Horizontal"));
        player.Shooting(Input.GetButton("Fire1"));

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float enter = 0.0f;
        if (aimPlane.Raycast(ray, out enter))
        {
            var mousePosInAimPlane = ray.GetPoint(enter);
            player.aimAt(mousePosInAimPlane);
        }
        
    }
}
