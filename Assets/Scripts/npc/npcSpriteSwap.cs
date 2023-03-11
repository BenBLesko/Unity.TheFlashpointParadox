using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// https://www.erikmoberg.net/article/unity3d-replace-sprite-programmatically-in-animation

public class npcSpriteSwap : MonoBehaviour
{
    public string SpriteSheetName; // The name of the Sprite Sheet to use

    private string LoadedSpriteSheetName; // The name of the currently loaded Sprite Sheet

    private Dictionary<string, Sprite> spriteSheet; // The dictionary containing all the sliced up sprites in the sprite sheet

    private SpriteRenderer spriteRenderer; // The Sprite Renderer

    private void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>(); // Get and cache the Sprite Renderer for this GameObject

        this.LoadSpriteSheet();
    }

    private void LateUpdate()
    {
        // Check if the Sprite Sheet Name has changed
        if (this.LoadedSpriteSheetName != this.SpriteSheetName)
        {
            this.LoadSpriteSheet(); // Load the new Sprite Sheet
        }

        this.spriteRenderer.sprite = this.spriteSheet[this.spriteRenderer.sprite.name]; // Swap out the sprite to be rendered by its name
    }

    // Loads the sprites from a Sprite Sheet
    private void LoadSpriteSheet()
    {
        // Load the sprites from a Sprite Sheet file 
        var sprites = Resources.LoadAll<Sprite>(this.SpriteSheetName);
        this.spriteSheet = sprites.ToDictionary(x => x.name, x => x);

        this.LoadedSpriteSheetName = this.SpriteSheetName; // Remember the name of the Sprite Sheet in case it is changed later
    }
}
