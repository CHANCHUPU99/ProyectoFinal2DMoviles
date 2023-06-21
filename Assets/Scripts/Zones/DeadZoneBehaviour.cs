using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
//using static UnityEngine.RuleTile.TilingRuleOutput;

public class DeadZoneBehaviour : MonoBehaviour
{
    public Transform transform1;
    public Transform transform2;
    public Transform transform3;
    public Transform transform4;
    public Transform transform5;
    public Transform transform6;
    public Transform transform7;
    public Transform transform8;
    public Transform transform9;
    public Transform transform10;
    public Transform transform11;
    public Transform transform12;
    public Transform transform13;
    public Transform transform14;
    public Transform transform15;
    public Transform transform16;
    public Transform transform17;
    public Transform transform18;
    public Transform transform19;
    public Transform transform20;
    public Transform transform21;
    public Transform transform22;
    public Transform transform23;
    public Transform transform24;
    public Transform transform25;
    public Transform transform26;
    public Transform transform27;
    public Transform transform28;
    public Transform transform29;
    public Transform transform30;
    public Transform transform31;
    public static DeadZoneBehaviour instance;
    public Queue<GameObject> enemyPool;
    public List<Transform> deadZonesTransforms;

    public int sectionIndex;
    [SerializeField] private GameObject enemy;
    private int enemiesLimit = 9;
    private bool m_canInstantiate = true;
    private float timeToSpawn = 1.5f;
    
    private void Awake() {

        instance = this; 
    }
    private void Start() {
        deadZonesTransforms = new List<Transform>();
        enemyPool = new Queue<GameObject>();
       
        Transform[] transformsToAdd = new Transform[31] { transform1, transform2,transform3, transform4, transform5, transform6, transform7, transform8, transform9,
        transform10, transform11, transform12, transform13, transform14, transform15, transform16, transform17, transform18, transform19, transform20, transform21, transform22,transform23,transform24,transform25,transform26,transform27,transform28,transform29,transform30,transform31};
        for (int i = 0; i < 22; i++) {
            deadZonesTransforms.Add(transformsToAdd[i]);
        }

        for(int i =0; i < enemiesLimit; i++) {
            enemyPool.Enqueue(Instantiate(enemy, deadZonesTransforms[0].transform.position, Quaternion.identity));
        }
        StartCoroutine(enemySpawning());
    }
    

    //private void setTransforms() {

    //    for (int i = 0; i < 22; i++) {
    //        deadZonesTransforms.Add(transformsToAdd[i]);
    //    }
    //}
    IEnumerator enemySpawning() {
        Debug.LogWarning("entro al switch");
        while (GameManager.s_instance.getGameState() != GameState.GameOver) {
            yield return new WaitForSeconds(timeToSpawn);
            if (GameManager.s_instance.getGameState() != GameState.Playing) {
                continue;
            }
            switch (sectionIndex) {
                case 1:
                    if (GameManager.s_instance.levelIndex == 0) {
                        if (sectionIndex == 1) {
                            GameObject temp = enemyPool.Dequeue();
                            enemyPool.Enqueue(temp);
                            temp.transform.position = deadZonesTransforms[1].transform.position;
                            Debug.Log("entro caso 1");
                            m_canInstantiate = false;
                        }
                    }
            
            if (GameManager.s_instance.levelIndex == 1) {
                if (sectionIndex == 1) {               
                    enemy.transform.position = deadZonesTransforms[0].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[1].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[2].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[3].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[4].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[5].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                }
            }
            if (GameManager.s_instance.levelIndex == 3) {
                if (sectionIndex == 1) {
                    //while (enemyPool.Count > 0) {
                    //    GameObject enemy = enemyPool.Dequeue();
                    //    Destroy(enemy);
                    //}
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[0].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[1].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[2].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    if (enemyPool.Count > enemiesLimit) {
                        m_canInstantiate = false;
                    }
                }
            }
            break;
                case 2:
            if (GameManager.s_instance.levelIndex == 1) {
                if (sectionIndex == 2) {               
                    Debug.Log("entro caso 2");
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[2].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[3].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[4].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[5].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                }
            }
            if (GameManager.s_instance.levelIndex == 2) {
                if (sectionIndex == 2) {
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[4].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[5].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[6].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[7].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[8].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[9].transform.position;
                    enemy = enemyPool.Dequeue();
                    if (enemyPool.Count > enemiesLimit) {
                        m_canInstantiate = false;
                    }
                }
            }
            if (GameManager.s_instance.levelIndex == 3) {
                if (sectionIndex == 2) {
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[3].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[4].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[5].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[6].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    if (enemyPool.Count > enemiesLimit) {
                        m_canInstantiate = false;
                    }
                }
            }
            break;
                case 3:
                    if (GameManager.s_instance.levelIndex == 1) {
                if (sectionIndex == 3) {
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[6].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[7].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[8].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[13].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    if (enemyPool.Count > enemiesLimit) {
                        m_canInstantiate = false;
                    }
                }
            }
            if (GameManager.s_instance.levelIndex == 2) {
                if (sectionIndex == 3) {
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[10].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[11].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[12].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[13].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[14].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    if (enemyPool.Count > enemiesLimit) {
                        m_canInstantiate = false;
                    }
                }
            }
            if (GameManager.s_instance.levelIndex == 3) {
                if (sectionIndex == 3) {
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[7].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[8].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[9].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[10].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    if (enemyPool.Count > enemiesLimit) {
                        m_canInstantiate = false;
                    }
                }
            }
            break;
                case 4:
                    if (GameManager.s_instance.levelIndex == 1) {
                if (sectionIndex == 4) {
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[11].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[12].transform.position;
                    enemy = enemyPool.Dequeue();
                    if (enemyPool.Count > enemiesLimit) {
                        m_canInstantiate = false;
                    }
                }
            }
            if (GameManager.s_instance.levelIndex == 2) {
                if (sectionIndex == 4) {
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[15].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[16].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[17].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[18].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[19].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[20].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[21].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[22].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[23].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    if (enemyPool.Count > enemiesLimit) {
                        m_canInstantiate = false;
                    }
                }
            }
            if (GameManager.s_instance.levelIndex == 3) {
                if (sectionIndex == 4) {
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[11].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[12].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    if (enemyPool.Count > enemiesLimit) {
                        m_canInstantiate = false;
                    }
                }
            }
            break;
                case 5:
                    if (GameManager.s_instance.levelIndex == 1) {
                if (sectionIndex == 5) {
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[9].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[10].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    if (enemyPool.Count > enemiesLimit) {
                        m_canInstantiate = false;
                    }
                }
            }
            if (GameManager.s_instance.levelIndex == 2) {
                if (sectionIndex == 5) {
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[24].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[25].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[26].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[26].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    if (enemyPool.Count > enemiesLimit) {
                        m_canInstantiate = false;
                    }
                }
            }
            if (GameManager.s_instance.levelIndex == 3) {
                if (sectionIndex == 5) {
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[13].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[14].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[15].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    if (enemyPool.Count > enemiesLimit) {
                        m_canInstantiate = false;
                    }
                }
            }
            break;
                case 6:
                    if (GameManager.s_instance.levelIndex == 1) {
                if (sectionIndex == 6) {
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[14].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[15].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[16].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[17].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    if (enemyPool.Count > enemiesLimit) {
                        m_canInstantiate = false;
                    }
                }
            }
            if (GameManager.s_instance.levelIndex == 2) {
                if (sectionIndex == 6) {
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[28].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[29].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[20].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    if (enemyPool.Count > enemiesLimit) {
                        m_canInstantiate = false;
                    }
                }
            }
            if (GameManager.s_instance.levelIndex == 3) {
                if (sectionIndex == 6) {
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[16].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[17].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[18].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[19].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[20].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    if (enemyPool.Count > enemiesLimit) {
                        m_canInstantiate = false;
                    }
                }
            }
            break;
                case 7:
                    if (GameManager.s_instance.levelIndex == 1) {
                if (sectionIndex == 7) {
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[18].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[19].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[20].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[21].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                }
            }
            if (GameManager.s_instance.levelIndex == 3) {
                if (sectionIndex == 7) {
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[21].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[22].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[23].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[24].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[25].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    enemy.transform.position = deadZonesTransforms[26].transform.position;
                    enemy = enemyPool.Dequeue();
                    enemyPool.Enqueue(enemy);
                    if (enemyPool.Count > enemiesLimit) {
                        m_canInstantiate = false;
                    }
                }
            }

            break;
            default:
                    print("Incorrect index");
            break;
        }
            
        }

        }

                      
    }



