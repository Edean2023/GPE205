using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public List<GameObject> roomPrefabs;
    public GameObject[,] grid;

    // sets the integer for columbs and rows
    public int cols;
    public int rows;

    // sets the float for the tile width and height 
    public float tileWidth = 50.0f;
    public float tileHeight = 50.0f;

    public GameObject spawnRoomPrefab;


    // Start is called before the first frame update
    void Start()
    {
        CreateLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    ////////////////////////////////////////////////////////////////////////////////////

    private void CreateLevel()
    {
        grid = new GameObject[cols, rows];

        int r_col = (int)Random.Range(0, cols), r_row = (int)Random.Range(0, rows);

        // for loops for all rooms
        for (int currentCol = 0; currentCol < cols; currentCol++)
        {
            for (int currentRow = 0; currentRow < rows; currentRow++)
            {
                GameObject tempRoom;

                if (currentCol == r_col && currentRow == r_row)
                {
                    tempRoom = Instantiate(spawnRoomPrefab);
                }
                else
                {
                    // Instantiate a room
                    tempRoom = Instantiate(RandomRoom());
                }

                // Add to the grid array
                grid[currentCol, currentRow] = tempRoom;
                // Move room into position
                tempRoom.transform.position = new Vector3(currentCol * tileWidth, 0, -currentRow * tileHeight);
                // Names the room
                tempRoom.name = "Room (" + currentCol + "," + currentRow + ")";
                // Make the room a child of this object
                tempRoom.GetComponent<Transform>().parent = this.gameObject.GetComponent<Transform>();


                Room roomScript = tempRoom.GetComponent<Room>();
                // manages the doors to the rooms
                if (currentCol != 0)
                {
                    roomScript.doorWest.SetActive(false);
                }

                if (currentCol != cols - 1)
                {
                    roomScript.doorEast.SetActive(false);
                }

                if (currentRow != 0)
                {
                    roomScript.doorNorth.SetActive(false);
                }

                if (currentRow != rows - 1)
                {
                    roomScript.doorSouth.SetActive(false);
                }


            }
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////

    // Destroy the level (Duh)
    public void DestroyLevel()
    {
        for (int currentRow = 0; currentRow < rows; currentRow++)
        {
            for (int currentCol = 0; currentCol < cols; currentCol++)
            {
                Destroy(grid[currentCol, currentRow]);
            }
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////

    private GameObject RandomRoom()
    {
        int roomIndex = Random.Range(0, roomPrefabs.Count);
        return roomPrefabs[roomIndex];
    }
}
