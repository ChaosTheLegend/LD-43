using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapons : ScriptableObject {

    public Sprite Ui;
    public Sprite sprite;
    public string Name;
    public float Damage;
    public float Knockback;
    public enum Elements {Ruby,Sapphire,Emerald}
    public Elements element;
    public enum Type {bow,sword,spear }
    public Type _type;
}
