using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poursuite : MonoBehaviour
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
    public GameObject Cible; //Cible à poursuivre
    public Vector3 positionChat; //Position du chat
    public Vector3 positionCible; //Position de la souris
    public float vitesse; //Vitesse du chat
    public Vector3 SC; //Vecteur de direction entre le chat et la souris
    public float normeSC; //Norme du vecteur SC


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

        vitesse = 0.005f; //Initialisation de la vitesse

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

        // ====================================================================================================
        //                     PPPP    OOO   U   U  RRRR    SSS   U   U  III  TTTTT  EEEEE
        //      /              P   P  O   O  U   U  R   R  S      U   U   I     T    E                      /
        //     /     *         P   P  O   O  U   U  R   R   SSS   U   U   I     T    EEE           *       /
        //    /     ***        PPPP   O   O  U   U  RRRR       S  U   U   I     T    E            ***     /
        //   /       *         P      O   O  U   U  R  R       S  U   U   I     T    E             *     /
        //  /                  P       OOO    UUU   R   R  SSSS    UUU   III    T    EEEEE              /
        // ====================================================================================================
        /* POURSUITE */

        //Mise en place du suivi des yeux du chat en fonction de la souris
        Quaternion rotation = Quaternion.LookRotation(transform.position - Cible.transform.position, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2);

        //Récupération de la position du chat
        positionChat = this.transform.position;

        //Récupération de la position de la souris
        positionCible = Cible.transform.position;

        //Calcul du vecteur de direction entre le chat et la souris
        SC = positionCible - positionChat;

        //Calcul de la norme du vecteur SC
        normeSC = SC.magnitude;

        //Déplacement du chat en mode poursuive (C(t + dt) = ((C(t)) + ((vitesse) * (SC / normeSC))))
        this.transform.position = this.transform.position + vitesse * SC / normeSC;
        
    }
}
