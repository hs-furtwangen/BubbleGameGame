using UnityEngine;

public class Player : MonoBehaviour
{
    Ray ray;

    Ray fanRay;
	RaycastHit hit;

    bool gotBubble = false;
    public GameObject bubble;
    public GameObject bubbleSpawn;

    public GameObject dart;
    public GameObject dartSpawn;
    public GameObject fanArea;
    public GameObject air;
    GameObject currentBubble;
    GameObject currentDart;
	
	void Update()
	{
        if(gotBubble && currentBubble != null){
            MakeAndShootBubble();
        }

		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit))
		{
			if(Input.GetMouseButtonUp(0)){
                //print(hit.collider.name);
                if(hit.collider.name.Contains("ColorPot")){
                    gotBubble = true;
                    currentBubble = Instantiate(bubble, bubbleSpawn.transform.position, bubbleSpawn.transform.rotation, bubbleSpawn.transform);
                    //print( bubble.transform.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial.GetColor("_Color"));
                    switch(hit.collider.name){
                        case string s when s.Contains("Yellow"):
                            currentBubble.transform.GetChild(0).GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.yellow);
                            break;
                        case string s when s.Contains("Red"):
                            currentBubble.transform.GetChild(0).GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.red);
                            break;
                        case string s when s.Contains("Blue"):
                            currentBubble.transform.GetChild(0).GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.blue);
                            break;
                        default:
                            print("Color not found.");
                            break;
                    }
                    currentBubble.GetComponent<Bubble>().myColor = currentBubble.transform.GetChild(0).GetComponent<MeshRenderer>().material.GetColor("_BaseColor");
                    currentBubble.name = "currentBubble";

                }
            }
				
		}
        
        ThrowDart();
        RotateFan();
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
            currentBubble.GetComponent<Rigidbody>().AddForce(transform.forward * 0.01f);
            //currentBubble.AddComponent<ConstantForce>();            
            //currentBubble.GetComponent<ConstantForce>().force = transform.InverseTransformDirection(-transform.right*1);
               
        }
    }

    void ThrowDart(){
        //Throw Dart if mousebutton released
       if(Input.GetMouseButtonUp(1)){
            currentDart = Instantiate(dart, dartSpawn.transform.position, dartSpawn.transform.rotation, dartSpawn.transform);
            currentDart.transform.SetParent(air.transform);
            currentDart.AddComponent<Rigidbody>();
            currentDart.GetComponent<Rigidbody>().mass = 0.1f;
            currentDart.GetComponent<Rigidbody>().useGravity = false;
            currentDart.GetComponent<Rigidbody>().AddForce(transform.forward * 30f);     
        }
    }

    void RotateFan(){
        if(Input.mouseScrollDelta.y != 0){
            fanArea.GetComponent<CapsuleCollider>().enabled = true;
        } else {
            fanArea.GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}
