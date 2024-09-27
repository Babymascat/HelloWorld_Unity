using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{

    // ====================================================================================================
    //                     V   V    A    RRRR   III    A    BBB    L      EEEEE   SSS
    //      /              V   V   A A   R   R   I    A A   B  B   L      E      S                      /
    //     /     *         V   V  A   A  R   R   I   A   A  BBBB   L      EEE     SSS          *       /
    //    /     ***         V V   AAAAA  RRRR    I   AAAAA  B   B  L      E          S        ***     /
    //   /       *          V V   A   A  R  R    I   A   A  B   B  L      E          S         *     /
    //  /                    V    A   A  R   R  III  A   A  BBBB   LLLLL  EEEEE  SSSS               /
    // ====================================================================================================
    // Déclaration des variables
    public float vitesse;
    public Rigidbody rb;


    // ==========================================================================
    //                      SSS   TTTTT    A    RRRR   TTTTT
    //      /              S        T     A A   R   R    T                    /
    //     /     *          SSS     T    A   A  R   R    T           *       /
    //    /     ***            S    T    AAAAA  RRRR     T          ***     /
    //   /       *             S    T    A   A  R  R     T           *     /
    //  /                  SSSS     T    A   A  R   R    T                /
    // ==========================================================================
    // Start est appelé avant la première frame de mise à jour
    void Start()
    {

        /* Initialisation des variables de lancement */
        vitesse = 0.01f;  // Initialisation de la vitesse
        rb = GetComponent<Rigidbody>(); // Récupération du rigidbody du joueur
        Debug.Log(rb); // Sert a débugger un code pour voir si il est bien exécuté ici ont vérifie si le rigidbody est bien récupéré
        
    }

    // =================================================================================
    //                     U   U  PPPP   DDD      A    TTTTT  EEEEE
    //      /              U   U  P   P  D  D    A A     T    E                      /
    //     /     *         U   U  P   P  D   D  A   A    T    EEE           *       /
    //    /     ***        U   U  PPPP   D   D  AAAAA    T    E            ***     /
    //   /       *         U   U  P      D  D   A   A    T    E             *     /
    //  /                   UUU   P      DDD    A   A    T    EEEEE              /
    // =================================================================================
    // Update est appelé une fois par frame
    void Update()
    {

        // ========================================================================================
        //                     FFFFF  L      EEEEE   CCC   H   H  EEEEE   SSS
        //      /              F      L      E      C   C  H   H  E      S                      /
        //     /     *         FFF    L      EEE    C      HHHHH  EEE     SSS          *       /
        //    /     ***        F      L      E      C      H   H  E          S        ***     /
        //   /       *         F      L      E      C   C  H   H  E          S         *     /
        //  /                  F      LLLLL  EEEEE   CCC   H   H  EEEEE  SSSS               /
        // ========================================================================================
        
        /* Déplacement de base avec les flèches */
        // Translation
        if (Input.GetKey(KeyCode.DownArrow))  // Reculer
        {
            transform.Translate(Vector3.forward * vitesse);
        }
        if (Input.GetKey(KeyCode.UpArrow))  // Avancer
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                vitesse = vitesse * 5;
                transform.Translate(Vector3.back * vitesse);
            }else{
                transform.Translate(Vector3.back * vitesse);
            }
        }
        // Rotation
        if (Input.GetKey(KeyCode.LeftArrow))  // Gauche
        {
            transform.Rotate(Vector3.up, -1);
        }
        if (Input.GetKey(KeyCode.RightArrow))  // Droite
        {
            transform.Rotate(Vector3.up, 1);
        }



        // ===================================================================
        //                     ZZZZZ   QQQ    SSS   DDD
        //      /                 Z   Q   Q  S      D  D                   /
        //     /     *           Z    Q   Q   SSS   D   D         *       /
        //    /     ***         Z     Q Q Q      S  D   D        ***     /
        //   /       *         Z      Q  Q       S  D  D          *     /
        //  /                  ZZZZZ   QQ Q  SSSS   DDD                /
        // ===================================================================
        /* Déplacement avancé avec zqsd et le suivie de la souris */
        if (Input.GetKey(KeyCode.Z)) //Avancer
        {

            // Sprint
            if(Input.GetKey(KeyCode.LeftShift))
            {
                vitesse = vitesse * 5;
                transform.Translate(Vector3.back * vitesse);
            }else{
                transform.Translate(Vector3.back * vitesse);
            }   

            // Mouvement rotative grace au pointeur de la souris et au clic gauche
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Input.GetMouseButton(0)){
                if (Physics.Raycast(ray, out hit))
                {
                    Vector3 positionSouris = hit.point;
                    positionSouris.y = transform.position.y;
                    Quaternion rotation = Quaternion.LookRotation(transform.position - positionSouris, Vector3.up);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2);
                }
            }
        }
        if (Input.GetKey(KeyCode.S)) //Reculer
        {
            transform.Translate(Vector3.forward * vitesse);

            // Mouvement rotative grace au pointeur de la souris et au clic gauche
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Input.GetMouseButton(0)){
                if (Physics.Raycast(ray, out hit))
                {
                    Vector3 positionSouris = hit.point;
                    positionSouris.y = transform.position.y;
                    Quaternion rotation = Quaternion.LookRotation(transform.position - positionSouris, Vector3.up);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2);
                }
            }
        }
        if (Input.GetKey(KeyCode.Q)) //Gauche
        {
            transform.Translate(Vector3.right * vitesse);
        }
        if (Input.GetKey(KeyCode.D)) //Droite
        {
            transform.Translate(Vector3.left * vitesse);
        }

        

        // ===================================================================
        //                      SSS     A    U   U  TTTTT
        //      /              S       A A   U   U    T                    /
        //     /     *          SSS   A   A  U   U    T           *       /
        //    /     ***            S  AAAAA  U   U    T          ***     /
        //   /       *             S  A   A  U   U    T           *     /
        //  /                  SSSS   A   A   UUU     T                /
        // ===================================================================
        // Verifier si le joueur est au sol
        if (Physics.Raycast(transform.position, Vector3.down, 1.1f)) 
        {
            // Mouvement de saut
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Ajout d'une force vers le haut avec un mode d'impulsion pour simuler le saut
                rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            }
        }



    }
}
