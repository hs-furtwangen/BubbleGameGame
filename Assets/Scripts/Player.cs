using UnityEngine;

public class Player : MonoBehaviour
{
    Ray ray;
	RaycastHit hit;

    bool gotBubble = false;
    public GameObject bubble;
    public GameObject bubbleSpawn;
    public GameObject air;
    GameObject currentBubble;
	
	void Update()
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit))
		{
			if(Input.GetMouseButtonDown(0)){
                //print(hit.collider.name);
                if(hit.collider.name.Contains("ColorPot")){
                    gotBubble = true;
                    print( bubble.transform.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial.GetColor("_Color"));
                    switch(hit.collider.name){
                        case string s when s.Contains("Yellow"):
                            bubble.transform.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial.SetColor("_BaseColor", Color.yellow);
                            break;
                        case string s when s.Contains("Red"):
                            bubble.transform.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial.SetColor("_BaseColor", Color.red);
                            break;
                        case string s when s.Contains("Blue"):
                            bubble.transform.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial.SetColor("_BaseColor", Color.blue);
                            break;
                        default:
                            print("Color not found.");
                            break;
                    }
                    Vector3 bubblePos = new Vector3(0,2,0);
                    currentBubble = Instantiate(bubble, bubbleSpawn.transform.position, bubbleSpawn.transform.rotation, bubbleSpawn.transform);
                    currentBubble.name = "currentBubble";

                }
            }
				
		}

        if(gotBubble){
            MakeAndShootBubble();
        }
	}

    void MakeAndShootBubble(){
       if(Input.GetMouseButton(0) && currentBubble.transform.localScale.x<1){
           currentBubble.transform.localScale = new Vector3(currentBubble.transform.localScale.x+Time.deltaTime,currentBubble.transform.localScale.y+Time.deltaTime,currentBubble.transform.localScale.z+Time.deltaTime);
           currentBubble.transform.localPosition = new Vector3(currentBubble.transform.localPosition.x,currentBubble.transform.localPosition.y,currentBubble.transform.localPosition.z+Time.deltaTime);
       }
        
        //Shoots Bubble if mousebutton released
       if(Input.GetMouseButtonUp(0)){
           gotBubble = false;
            currentBubble.transform.SetParent(air.transform);
            currentBubble.AddComponent<Rigidbody>();
            currentBubble.GetComponent<Rigidbody>().mass = 0.001f;
            currentBubble.GetComponent<Rigidbody>().useGravity = false;
            currentBubble.GetComponent<Rigidbody>().AddForce(transform.forward * 1);
            //currentBubble.AddComponent<ConstantForce>();            
            //currentBubble.GetComponent<ConstantForce>().force = transform.InverseTransformDirection(-transform.right*1);
               
        }
    }
}
